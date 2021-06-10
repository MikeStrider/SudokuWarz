UPDATE Users SET [yourTurn] = 1 WHERE [name] = '';

DELETE FROM Users WHERE [name] = 'Steve';

UPDATE Users SET yourTurn = 0;

INSERT INTO Users ([name], seat, yourTurn) VALUES ('Steve', 1, 1);

# this is great

# anod another 
