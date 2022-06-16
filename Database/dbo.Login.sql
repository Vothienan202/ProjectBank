CREATE TABLE [dbo].[Login] (
    [userID]      INT            NOT NULL,
    [bankID]      INT            NOT NULL,
    [username]    NVARCHAR (MAX) NULL,
    [password]    NVARCHAR (MAX) NULL,
    [phoneNumber] NCHAR (10)     NULL,
    [CCCD]        INT            NULL,
    [address]     NVARCHAR (MAX) NULL,
    [sex]         NVARCHAR (50)  NULL,
    [bank]        NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([bankID] ASC)
);

