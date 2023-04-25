## CHESS GAME

### TASK: Data Model
C# classes for the Chess Game can be found in `/src/model` folder.

Please refer inline comments for more description on individual classes.

![Screenshot from 2023-04-25 18-26-24](https://user-images.githubusercontent.com/19142608/234245180-f8aa3fab-50ca-4275-bee4-8f3124825118.png)

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
I have tested with sample data(around 1001694 moves) and observed a reasonable performance improvement from ~350ms to ~100ms.

![Screenshot from 2023-04-25 18-31-33](https://user-images.githubusercontent.com/19142608/234245380-266db75d-8026-4dc4-a40c-124410c82ef7.png)

![Screenshot from 2023-04-25 18-32-13](https://user-images.githubusercontent.com/19142608/234245444-dc908eeb-7ba5-412a-9eff-f919971ccadd.png)



### TASK: Work Queue
Implementation of INextBestMoveRequestQueue can be found in `/src/nextBestMoveQueue.cs` file.

### TASK: Testing
Unit tests can be found in `/tests/nextBestMoveTests.cs` 

Please note, I have identified an issue (the original code checks for subscription as opoosed to NO subscriotion) and fixed it to make the code behave as expected.

`if (!player.HasSubscription)` // originally it was `if (player.HasSubscription)`

`{`

    throw new Exception( "This feature requires a subscription");

`}`
