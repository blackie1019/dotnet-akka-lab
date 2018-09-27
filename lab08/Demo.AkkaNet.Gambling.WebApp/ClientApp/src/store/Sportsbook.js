import {HubConnectionBuilder, LogLevel} from "@aspnet/signalr";

const requestSelectionsDataType = 'REQUEST_SELECTIONSDATA';
const receiveSelectionsDataType = 'RECEIVE_SELECTIONSDATA';
const setHubConnectionDataType = 'SET_HUBCONNECTIONDATA';
const updateGamesDataType = 'UPDATE_GAMESDATA';
const initialState = {
    startDateIndex:'',
    message: '',
    messages: [],
    hubConnection:null,
    games:[],
    isLoading:false
};

export const actionCreators = {
    requestSelections: startDateIndex => async (dispatch, getState) => {    
        if (startDateIndex === getState().sportsbook.startDateIndex) {
          // Don't issue a duplicate request (we already have or are loading the requested data)
          return;
        }
        
        dispatch({ type: requestSelectionsDataType, startDateIndex });
        
        const url = `api/GameData/SelectionsOdds?startDateIndex=${startDateIndex}`;
        
        const response = await fetch(url);
        const games = await response.json();
        
        dispatch({ type: receiveSelectionsDataType, startDateIndex, games });
    },
    
    setHubConnection: () => async (dispatch, getState) => {

            const hubConnection = new HubConnectionBuilder()
                .withUrl("/hubs/game")
                .configureLogging(LogLevel.Information)
                .build();
        
            await dispatch({type: setHubConnectionDataType, hubConnection});
            getState().sportsbook.hubConnection
            .start()
            .then(() => console.log('Connection started!'))
            .catch(err => console.log('Error while establishing connection :('));

            getState().sportsbook.hubConnection.on('updateGames', (games) => {
                if(getState().sportsbook.games.length>0) {
                    games.map(function (newMarketlines, i) {
                        let currentMarketlines = getState().sportsbook.games[i];
                        newMarketlines.spreadSelectionOdds.updown =[];
                        newMarketlines.totalSelectionOdds.updown = [];
                        newMarketlines.moneylineSelectionOdds.updown = [];

                        for(let index=0;index<2;index++) {
                            if (currentMarketlines.spreadSelectionOdds.odds[index] > newMarketlines.spreadSelectionOdds.odds[index]) {
                                newMarketlines.spreadSelectionOdds.updown[index] = "text-danger";
                            } else if (currentMarketlines.spreadSelectionOdds.odds[index] < newMarketlines.spreadSelectionOdds.odds[index]) {
                                newMarketlines.spreadSelectionOdds.updown[index] = "text-success ";
                            } else {
                                newMarketlines.spreadSelectionOdds.updown[index] = "";
                            }

                            if (currentMarketlines.totalSelectionOdds.odds[index] > newMarketlines.totalSelectionOdds.odds[index]) {
                                newMarketlines.totalSelectionOdds.updown[index] = "text-danger";
                            } else if (currentMarketlines.totalSelectionOdds.odds[index] < newMarketlines.totalSelectionOdds.odds[index]) {
                                newMarketlines.totalSelectionOdds.updown[index] = "text-success ";
                            } else {
                                newMarketlines.totalSelectionOdds.updown[index] = "";
                            }

                            if (currentMarketlines.moneylineSelectionOdds.odds[index] > newMarketlines.moneylineSelectionOdds.odds[index]) {
                                newMarketlines.moneylineSelectionOdds.updown[index] = "text-danger";
                            } else if (currentMarketlines.moneylineSelectionOdds.odds[index] < newMarketlines.moneylineSelectionOdds.odds[index]) {
                                newMarketlines.moneylineSelectionOdds.updown[index] = "text-success ";
                            } else {
                                newMarketlines.moneylineSelectionOdds.updown[index] = "";
                            }
                        }
                    });
                }
                
                dispatch({ type: 'UPDATE_GAMESDATA', games});
            });
    }
};

export const reducer = (state, action) => {
  state = state || initialState;

  if (action.type === requestSelectionsDataType) {
    return {
      ...state,
      startDateIndex: action.startDateIndex,
      isLoading: true
    };
  }

  if (action.type === receiveSelectionsDataType) {
    return {
      ...state,
      startDateIndex: action.startDateIndex, 
      games: action.games,
      isLoading: false
    };
  }
  
    if (action.type === setHubConnectionDataType) {
        return {
            ...state,
            hubConnection: action.hubConnection
        };
    }

    if (action.type === updateGamesDataType) {
        return {
            ...state,
            games: action.games
        };
    }
    
  return state;
};
