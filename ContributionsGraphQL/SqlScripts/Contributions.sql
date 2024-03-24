USE [NproDB]
GO

CREATE TABLE dbo.Contributions
	(
	ContributionID INT IDENTITY NOT NULL,
	TaskID         INT NOT NULL,
	UserID         INT NOT NULL,
	TimeSpent      VARCHAR (10) NOT NULL,
	Description    VARCHAR (1000) NOT NULL,
	PRIMARY KEY (ContributionID)
	)
GO



INSERT INTO dbo.Contributions (TaskID, UserID, TimeSpent, Description)
VALUES (1, 5, '3.5', 'Testing')
GO

INSERT INTO dbo.Contributions (TaskID, UserID, TimeSpent, Description)
VALUES (2, 8, '4.6', 'Test Demo')
GO

