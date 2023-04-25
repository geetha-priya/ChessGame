## CHESS GAME

### TASK: Data Model
C# classes for the Chess Game can be found in `/src/model` folder.

Please refer inline comments for more description on individual classes.

### TASK: WebAPI
Implementation for the requested APIs can be found in `/src/contollers/gameController.cs`

Run the following command to start the Web APIs - `dotnet run` from `/src` folder.

APIs can be accessed on localhost at http://localhost:5071/swagger/index.html

### TASK: Database Schema

Please note - I have used postgresql for this task as I do not have SQL Server. 
It is fairly simple process to migrate from postgres to SQL server given the SQL server environment.
`/db/script-001.sql` contains
1. Commands to create tables
2. Insert test data
3. Query to fetch requested data

### TASK: Database Performance
I have added index to improve the DB performance.
Commands can be found in `/db/script-002.sql`

I have tested with sample data(around 1001694 moves) and observed a reasonable performance improvement from ~350ms to ~90ms.

### TASK: Work Queue
Implementation of INextBestMoveRequestQueue can be found in `/src/nextBestMoveQueue.cs` file.

### TASK: Testing
Unit tests can be found in `/tests/nextBestMoveTests.cs` 

Please note, I have identified an issue (the original code checks for subscription as opoosed to NO subscriotion) and fixed it to make the code behave as expected.

`if (!player.HasSubscription)` // originally it was `if (player.HasSubscription)`

`{`

    throw new Exception( "This feature requires a subscription");

`}`