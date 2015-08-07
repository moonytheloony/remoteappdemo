CREATE TABLE [dbo].[EmployeeSalary] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (20) NOT NULL,
    [Pay]  MONEY         NOT NULL, 
    CONSTRAINT [PK_EmployeeSalary] PRIMARY KEY ([Id])
);

