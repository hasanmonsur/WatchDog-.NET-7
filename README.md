# ![WatchDog Logo](https://github.com/IzyPro/WatchDog/blob/main/WatchDog/src/WatchPage/images/watchdogWhiteLogo.png)
# Real Time Log Monitoring by WatchDog


## Introduction

WatchDog is a Realtime Message, Event, HTTP (Request & Response) and Exception logger and viewer for ASP.Net Core Web Apps and APIs. It allows developers log and view messages, events, http requests made to their web application and also exception caught during runtime in their web applications, all in Realtime.
It leverages `SignalR` for real-time monitoring and `LiteDb` a Serverless MongoDB-like database with no configuration with the option of using your external MSSQL, MySQl or Postgres databases.

# ![Request & Response Viewer](https://github.com/IzyPro/WatchDog/blob/main/watchlog.png)

## General Features

- RealTime HTTP Request and Response Logger
- RealTime Exception Logger
- In-code message and event logging
- User Friendly Logger Views
- Search Option for HTTP and Exception Logs
- Filtering Option for HTTP Logs using HTTP Methods and StatusCode
- Logger View Authentication
- Auto Clear Logs Option

## What's New

- In-code logger for messages and events

## Fixes

- Fixed Middleware order
- Fixed Index pages not showing on MVC Apps


## Support
- .NET 7 and newer

# Install Watchdog in your project
just add watchdog project at your solution and add project dependency by watchdog project


## Usage
To enable WatchDog to listen for requests, use the WatchDog middleware provided by WatchDog.

Add WatchDog Namespace in `Startup.cs`

```c#
using WatchDog;
```

### Setup Logging to External Db (MSSQL, MySQL & PostgreSQL) `Optional`
Add Database Connection String and Choose SqlDriver Option

```c#
services.AddWatchDogServices(opt => 
{
   opt.IsAutoClear = false; 
   opt.SetExternalDbConnString = "Server=localhost;Database=testDb;User Id=postgres;Password=root;"; 
   opt.SqlDriverOption = WatchDogSqlDriverEnum.PostgreSql; 
});
```

#### Add list of routes you want to ignore by the logger: `Optional`

```c#
app.UseWatchDogExceptionLogger();

...

app.UseWatchDog(opt => 
{ 
   opt.WatchPageUsername = "admin"; 
   opt.WatchPagePassword = "Qwerty@123"; 
   opt.Blacklist = "Test/testPost, weatherforecast";
 });
```

### Log Messages/Events  in code level log monitoring
```
WatchLogger.Log("...TestGet Started...");
```
# ![In-code log messages](https://github.com/IzyPro/WatchDog/blob/main/in-code.jpeg)


### View Logs and Exception
Start your server and head to `/watchdog` to view the logs.
>Example: https://myserver.com/watchdog or https://localhost:[your-port]/watchdog


## Contribution
Feel like something is missing? Fork the repo and send a PR.

Encountered a bug? Fork the repo and send a PR.

Alternatively, open an issue and we'll get to it as soon as we can.

## Credit
Kelechi Onyekwere -  [Github](https://github.com/Khelechy) [Twitter](https://twitter.com/khelechy1337)

Israel Ulelu - [Github](https://github.com/IzyPro) [Twitter](https://twitter.com/IzyPro_)
