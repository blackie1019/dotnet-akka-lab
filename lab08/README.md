# MiniSportsbook #

1. Restore nuget packages

        dotnet restore

2. Execute Web application

        dotnet run 

    or

        dotnet run -c Release
3. Once the web work, you can manually update odds from [https://localhost:5001/api/GameData/SelectionsOdds](https://localhost:5001/api/GameData/SelectionsOdds)
4. Execute Console application 

        dotnet run 

    or

        dotnet run -c Release
5. In the Console input, enter:

        /game

    This command will trigger auto-push odds to web.