# Hello World Sample #

1. Restore nuget packages

        dotnet restore

2. Uncomment *BasicActorCreationUsingTell()* and comment *BasicActorCreationUsingAsk* execute application to demo **Tell**

        dotnet run 

    or

        dotnet run -c Release

3. Same as above, but uncomment *BasicActorCreationUsingAsk* and comment *BasicActorCreationUsingTell()* execute application to demo **Ask**