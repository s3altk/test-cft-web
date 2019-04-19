CREATE TABLE [Apps]
(
    [Id] UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    [Name] NVARCHAR(100) UNIQUE,
    [Created] DATE NULL
)
GO

CREATE TABLE [Requests]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(100),
    [Finished] DATE NOT NULL,
    [Description] NVARCHAR(500) NULL,
    [Email] NVARCHAR(100) NOT NULL,
    [AppId] UNIQUEIDENTIFIER NOT NULL,
    
    FOREIGN KEY (AppId) REFERENCES [Apps] (Id)
)
GO

INSERT INTO [Apps] ([Id], [Name])
VALUES ('b5517523-eac3-457c-a30d-f3046099c0e9', 'CFT-Bank'),
       ('f09043f8-d71f-4a94-af14-dddf1fafc99d', 'CFT-AML'),
       ('c451859d-1801-43e7-856f-b14950c8ee66', 'CFT-Retail Bank'),
       ('129754fc-4e84-43b1-8c7a-3603b3e0b44d', 'CFT-Insurance Company'),
       ('975e8f0c-771c-4213-9612-31cf5129a133', 'CFT-Management Accounting'),
       ('91dec534-4f0f-47f3-9c91-2170e3e0ee41', 'CFT-Processing Center')
GO

SELECT * FROM [Apps]
GO

DELETE FROM [Apps]
GO 

INSERT INTO [Requests] ([Name], [Finished], [Email], [AppId])
VALUES ('Add sorting of requests', '2019-04-01', 'tka4off@mail.com', 'b5517523-eac3-457c-a30d-f3046099c0e9'),
       ('Add filtering of requests', '2019-04-02', 'nikoir@mail.com', 'b5517523-eac3-457c-a30d-f3046099c0e9'),
       ('Add paging of requests', '2019-04-03', 'wos21@mail.com', 'f09043f8-d71f-4a94-af14-dddf1fafc99d'),
       ('Add editing of requests', '2019-04-04', 'baki001@mail.com', 'f09043f8-d71f-4a94-af14-dddf1fafc99d'),
       ('Add transfer of requests', '2019-04-05', 'ironman777@mail.com', 'c451859d-1801-43e7-856f-b14950c8ee66'),
       ('Add searching of requests', '2019-04-06', 'deny4@mail.com', 'c451859d-1801-43e7-856f-b14950c8ee66'),
       ('Add viewing of requests', '2019-04-07', 'malysh66@mail.com', 'c451859d-1801-43e7-856f-b14950c8ee66'),
       ('Add deleting of requests', '2019-04-08', 'tka4off@mail.com', '129754fc-4e84-43b1-8c7a-3603b3e0b44d'),
       ('Add button for creating a new request', '2019-04-12', 'baki001@mail.com', '129754fc-4e84-43b1-8c7a-3603b3e0b44d'),
       ('Add button for editing the current request', '2019-04-25', 'ironman777@mail.com', '975e8f0c-771c-4213-9612-31cf5129a133'),
       ('Add field of last app updated date', '2019-04-18', 'malysh66@mail.com', '975e8f0c-771c-4213-9612-31cf5129a133'),
       ('Add input form for creting a new request', '2019-04-19', 'wos21@mail.com', '91dec534-4f0f-47f3-9c91-2170e3e0ee41'),
       ('Add input form for app reporting', '2019-04-20', 'deny4@mail.com', '91dec534-4f0f-47f3-9c91-2170e3e0ee41')
GO

SELECT * FROM [Requests]
GO

DELETE FROM [Requests]
GO 