import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { actionCreators } from '../store/Sportsbook';

class FetchData extends Component {
  componentDidMount = () => {
      this.props.setHubConnection();
  };
  
  componentWillMount() {
    // This method runs when the component is first added to the page
    const startDateIndex = parseInt(this.props.match.params.startDateIndex, 10) || 0;
    this.props.requestSelections(startDateIndex);
  }

  componentWillReceiveProps(nextProps) {
    // This method runs when incoming props (e.g., route params) change
    const startDateIndex = parseInt(nextProps.match.params.startDateIndex, 10) || 0;
    this.props.requestSelections(startDateIndex);
  }

  render() {
    return (
        <div>
            <h1>Ｍini Sportsbook</h1>
            <p>This component auto-refresh when SignalR push game data</p>
            {renderMarketlines(this.props)}
        </div>
    );
  }
}

function renderMarketlines(props) {
    function printTableTd(key,selections,index) {
        if (typeof selections.updown === "undefined") {
            return (<td className="col-2 text-center" key={key}>{selections.odds[index]}</td>);
        }

        return (<td className={`col-2 text-center ${selections.updown[index]}`} key={key}>{selections.odds[index]}</td>);
    }
    return (
      <div className="container table-responsive-sm">
      {props.games.map(function(marketlines,i)
          {
              return (
                  <table className='table table-hover' key={"table_"+i}>
                      <thead className='thead-dark'>
                      <tr className="d-flex">
                          <th className="col-6"></th>
                          <th className="col-2 text-center">Spread</th>
                          <th className="col-2 text-center">Total</th>
                          <th className="col-2 text-center">Moneyline</th>
                      </tr>
                      </thead>
                      <tbody>
                      <tr className="d-flex">
                          <td className="col-6 " key={`teamNames_A_${i}`}>{marketlines.teamNames[0]}</td>
                          {printTableTd(`spreadSelectionOdds_A_${i}`,marketlines.spreadSelectionOdds,0)}
                          {printTableTd(`totalSelectionOdds_A_${i}`,marketlines.totalSelectionOdds,0)}
                          {printTableTd(`moneylineSelectionOdds_A_${i}`,marketlines.moneylineSelectionOdds,0)}
                          {/*<td className={`col-2 text-center ${marketlines.spreadSelectionOdds.updown[0]}`} key={`spreadSelectionOdds_A_${i}`}>{marketlines.spreadSelectionOdds.odds[0]}</td>*/}
                          {/*<td className={`col-2 text-center ${marketlines.totalSelectionOdds.updown[0]}`} key={`totalSelectionOdds_A_${i}`}>{marketlines.totalSelectionOdds.odds[0]}</td>*/}
                          {/*<td className={`col-2 text-center ${marketlines.moneylineSelectionOdds.updown[0]}`} key={`moneylineSelectionOdds_A_${i}`}>{marketlines.moneylineSelectionOdds.odds[0]}</td>*/}
                      </tr>
                      <tr className="d-flex">
                          <td className="col-6" key={`teamNames_B_${i}`}>{marketlines.teamNames[1]}</td>
                          {printTableTd(`spreadSelectionOdds_B_${i}`,marketlines.spreadSelectionOdds,1)}
                          {printTableTd(`totalSelectionOdds_B_${i}`,marketlines.totalSelectionOdds,1)}
                          {printTableTd(`moneylineSelectionOdds_B_${i}`,marketlines.moneylineSelectionOdds,1)}
                          {/*<td className={`col-2 text-center ${marketlines.spreadSelectionOdds.updown[1]}`} key={`spreadSelectionOdds_B_${i}`}>{marketlines.spreadSelectionOdds.odds[1]}</td>*/}
                          {/*<td className={`col-2 text-center ${marketlines.totalSelectionOdds.updown[1]}`} key={`totalSelectionOdds_B_${i}`}>{marketlines.totalSelectionOdds.odds[1]}</td>*/}
                          {/*<td className={`col-2 text-center ${marketlines.moneylineSelectionOdds.updown[1]}`} key={`moneylineSelectionOdds_B_${i}`}>{marketlines.moneylineSelectionOdds.odds[1]}</td>*/}
                      </tr>
                      </tbody>
                  </table>);
      }
      )}
      </div>
    );
}

export default connect(
  state => state.sportsbook,
  dispatch => bindActionCreators(actionCreators, dispatch)
)(FetchData);
