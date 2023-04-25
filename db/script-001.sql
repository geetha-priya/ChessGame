--TASK: Database Schema

--Commands to create database scheme to store data for the Chess website.
--Also contains the commands to insert sample data.

CREATE TABLE Player (
    PlayerId BIGINT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    EmailAddress VARCHAR(100),
    CreatedDate TIMESTAMP NOT NULL
);

-- Insert players
INSERT INTO chessgame.player
(playerid, "name", emailaddress, createddate)
VALUES(1, 'player-1', 'player-1@gmail.com', '2022-01-01 10:00:00.000'),
(2, 'player-2', 'player-2@gmail.com', '2022-01-02 10:00:00.000'),
(3, 'player-3', 'player-3@gmail.com', '2022-01-03 12:00:00.000'),
(4, 'player-4', 'player-4@gmail.com', '2022-01-01 12:00:00.000');

CREATE TABLE Game (
    GameId SMALLINT PRIMARY KEY,
    StartDate TIMESTAMP NOT NULL,
    WhitePlayerId BIGINT NOT NULL,
    BlackPlayerId BIGINT NOT NULL,
    FOREIGN KEY (WhitePlayerId) REFERENCES Player (PlayerId),
    FOREIGN KEY (BlackPlayerId) REFERENCES Player (PlayerId)
);

-- Insert games
INSERT INTO chessgame.game
(gameid, startdate, whiteplayerid, blackplayerid)
VALUES(1, '2022-01-02 12:00:00.000', 1, 2),
(2, '2022-01-03 01:00:00.000', 3, 4);

CREATE TABLE Move (
    GameId SMALLINT NOT NULL,
    PlayerColor BOOLEAN NOT NULL,
    Date TIMESTAMP NOT NULL,
    Piece VARCHAR(20) NOT NULL,
    StartPosition INTEGER NOT NULL,
    EndPosition INTEGER,
    FOREIGN KEY (GameId) REFERENCES Game (GameId)
);

-- Insert random moves of both white and black players for game 1
INSERT INTO ChessGame.Move (GameId, PlayerColor, Date, Piece, StartPosition, EndPosition)
SELECT 1 AS GameId,
       false AS PlayerColor, --white color
       TIMESTAMP '2022-01-02 12:00:00.000' + (i % 10) * INTERVAL '1 minute' AS Date,
       CASE WHEN i % 2 = 0 THEN 'WhitePawn'
            WHEN i % 4 = 1 THEN 'WhiteKnight'
            WHEN i % 6 = 2 THEN 'WhiteBishop'
            WHEN i % 8 = 3 THEN 'WhiteRook'
            WHEN i % 10 = 4 THEN 'WhiteQueen'
            ELSE 'WhiteKing'
       END AS Piece,
       i AS StartPosition,
       i+2 AS EndPosition
FROM generate_series(1, 1000) AS i

UNION ALL

SELECT 1 AS GameId,
       true AS PlayerColor,
       TIMESTAMP '2022-01-02 02:00:00.000' + (i % 10) * INTERVAL '2 minute' AS Date,
       CASE WHEN i % 2 = 0 THEN 'BlackPawn'
            WHEN i % 4 = 1 THEN 'BlackKnight'
            WHEN i % 6 = 2 THEN 'BlackBishop'
            WHEN i % 8 = 3 THEN 'BlackRook'
            WHEN i % 10 = 4 THEN 'BlackQueen'
            ELSE 'BlackKing'
       END AS Piece,
       i AS StartPosition,
       i+3 AS EndPosition
FROM generate_series(1, 500) AS i;

-- Insert random moves of both white and black players for game 2
INSERT INTO ChessGame.Move (GameId, PlayerColor, Date, Piece, StartPosition, EndPosition)
SELECT 2 AS GameId,
       false AS PlayerColor, --white color
       TIMESTAMP '2022-01-02 12:00:00.000' + (i % 10) * INTERVAL '1 minute' AS Date,
       CASE WHEN i % 2 = 0 THEN 'WhitePawn'
            WHEN i % 4 = 1 THEN 'WhiteKnight'
            WHEN i % 6 = 2 THEN 'WhiteBishop'
            WHEN i % 8 = 3 THEN 'WhiteRook'
            WHEN i % 10 = 4 THEN 'WhiteQueen'
            ELSE 'WhiteKing'
       END AS Piece,
       i AS StartPosition,
       i+2 AS EndPosition
FROM generate_series(1, 87) AS i

UNION ALL

SELECT 2 AS GameId,
       true AS PlayerColor,
       TIMESTAMP '2022-01-02 02:00:00.000' + (i % 10) * INTERVAL '2 minute' AS Date,
       CASE WHEN i % 2 = 0 THEN 'BlackPawn'
            WHEN i % 4 = 1 THEN 'BlackKnight'
            WHEN i % 6 = 2 THEN 'BlackBishop'
            WHEN i % 8 = 3 THEN 'BlackRook'
            WHEN i % 10 = 4 THEN 'BlackQueen'
            ELSE 'BlackKing'
       END AS Piece,
       i AS StartPosition,
       i+3 AS EndPosition
FROM generate_series(1, 46) AS i;


-- Query that returns the count of all moves grouped by player for all games played in January 2022.
-- Your query should return the following columns:
-- ·       Player Name
-- ·       Count of Moves

select p.name as "Player Name", count(*) as "Count of Moves"
from ChessGame.move m 
join ChessGame.game g on m.GameId = g.gameid
join chessgame.player p on (p.playerid  = g.whiteplayerid and m.playercolor = false) or  (p.playerid  = g.blackplayerid and  m.playercolor = true)
group by p.playerid
ORDER BY COUNT(*) DESC;