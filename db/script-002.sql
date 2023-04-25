--TASK: Database Performance

--Commands to create function for frequently used query and add index to improve the performence of the query.
--Also contains the command to check the query plan and time taken for execution.

-- Function to fetch moves corresponding provided piece and date range
CREATE OR REPLACE FUNCTION Chessgame.get_game_ids(
  startD timestamp,  --startdate
  endD timestamp,  --enddate
  pieceName varchar(20)
)
RETURNS TABLE (gameid smallint) AS $$
BEGIN
  RETURN QUERY
  SELECT g.gameid
  FROM Chessgame.game g
  JOIN Chessgame.move m ON m.gameid  = g.gameid
  WHERE m.piece = pieceName
  AND m.date > startD
  AND m.date < endD;
END;
$$ LANGUAGE plpgsql;

-- Command to check the query plan and time taken for execution of the query
explain analyse SELECT count(*) FROM Chessgame.get_game_ids('2022-01-01', '2022-01-20', 'BlackRook');

-- Command to create index
CREATE INDEX index_move_piece_date ON  Chessgame.move (piece, date);
