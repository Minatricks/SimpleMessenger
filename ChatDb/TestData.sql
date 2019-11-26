INSERT INTO dbo.Users VALUES
('Dima',1,1,1),
('Anna',1,1,1),
('Denis',1,1,1),
('Vanya',1,1,1)

INSERT INTO dbo.UserProfiles(Id) VALUES
(1),
(2),
(3),
(4)

INSERT INTO dbo.Messages(TextMessage,DateAndTime,IdSender,IdRecipient) VALUES
('Hi i am Anna','10.12.1998',2,1),
('Hi i am Anna 2','10.12.2002',2,1),
('Hi i am Vanya','10.12.2002',3,1),
('Hi i am Denis','10.12.2002',4,1)

INSERT INTO dbo.Contacts(MyId,ContactId) VALUES
(1,2),
(1,3),
(1,4)

