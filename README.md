# dotnet-akka-lab
Code Lab for Reactive Programming with Akka.NET and .NET Core

[Download slide](https://www.slideshare.net/chentientsai/reactive-application-with-akkanet-net-core)

Live course will open on 9/29 [Study4.TW .NET Conf 2018 - 使用 Akka.NET
建立響應式應用程式](http://study4.tw/Activity/Details/20)

*Agenda*
- :bicyclist: Reactive Manifesto & Architecture 
- :bullettrain_front: Akka.NET & .NET Core
- :rocket: Put it into REAL : Integrating React & SignalR


## :white_check_mark: Lab01 - HelloWorld ##

This is a basic Akka.NET sample for Tpye and Untype actor.

### Demo Features ###

- Akka.NET Hello world
- UntypedActor and ReceiveActor(TypeActor)
- Tell, Ask, Forward
 
### Technical Stacks ###

- .NET Core
- Akka.NET

[Project Link](/lab01)

## :white_check_mark: Lab02 - Akka.NET MessageDelivery ##

This is an example for actor life-cyle

### Demo Features ###
- Actor LifeCycle
- Stop & GracefulStop Actor

### Technical Stacks ###

- .NET Core
- Akka.NET

[Project Link](/lab02)

## :white_check_mark: Lab03 - MusicPlayer with Akka.NET ##

This is an example to demo the ActorSystem and Supervision on Akka.NET

### Demo Features ###

- Multiple Actor and Actor's data
- ActorSystem path
- Actor behavior - Become()
- Supervision

### Technical Stacks ###

- .NET Core
- Akka.NET

[Project Link](/lab03)

## :white_check_mark: Lab04 Routers of Akka.NET ##

This is an example to demo Routers of Akka.NET

### Demo Features ###

- Round Robin
- Random routing
- Shortest Mailbox queue
- Consistent Hashing 

### Technical Stacks ###

- .NET Core
- Akka.NET

[Project Link](/lab04)

## :white_check_mark:  Lab05 Chat Room ##

This is a sample to demo Akka.Remote

### Demo Features ###

- Akka.Remote
- Akka Configuration(hocon file)

### Technical Stacks ###

- .NET Core
- Akka.NET
- Akka.Remote

[Project Link](/lab05)

## :white_check_mark: Lab06 Akka.Cluster ##

Ａ demo to show how to setup Cluster.

### Demo Features ###

- Actor.Cluster combine multiple Actor System
- Load Actor System and cluster setting from configuration(hocon file) 

### Technical Stacks ###

- .NET Core
- Akka.NET
- Akka.Remote
- Akka.Cluster

[Project Link](/lab06)

## :white_check_mark: Lab07 Akka.NET & ASP.NET Core ##

Simple ASP.NET Core with Akka.NET

### Demo Features ###

- Actor model integrate with ASP.NET Core

### Technical Stacks ###

- .NET Core
- Akka.NET
- ASP.NET Core

[Project Link](/lab07)

## :white_check_mark: Lab08 MiniSportsbook ##

An example to demo how to integate Akka.NET to push messaing from clinet console.

### Demo Features ###

- Client generate game data to Web from Akka.Remote
- Use Akka.Scheduler to fire game data when target interval
- ASP.NET Core build multiple Actors
- ASP.NET Core use IHostedService play as console
- Use SignalR push data to Client
- Change Akka.Serializer from Json.NET to Hyperion

### Technical Stacks ###

- .NET Core
- Akka.NET
- Akka.Remote
- Akka.Scheduler
- Hyperion
- ASP.NET Core
- ASP.NET Core SignalR
- React & Redux
- Bootstrap

[Project Link](/lab08)
