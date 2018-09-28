# Akka.NET MessageDelivery # 

1. Restore nuget packages

        dotnet restore

2. Uncomment *system.Stop()*, comment *emailSender.GracefulStop()* and related lines. Execute application to demo **Incorrect** way of stop actor system.

        dotnet run 

    or

        dotnet run -c Release

3. Same as above, but Uncomment *emailSender.GracefulStop()* and related lines, comment *system.Stop()*. Execute application to demo **Correct** way of stop actor system.