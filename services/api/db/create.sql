CREATE DATABASE MotionPictureDbContext;
GO
USE MotionPictureDbContext;
GO
CREATE TABLE [MotionPictures] (
    [ID] int NOT NULL IDENTITY,
    [Name] nvarchar(50) NOT NULL,
    [Description] nvarchar(500) NULL,
    [ReleaseYear] int NOT NULL,
    CONSTRAINT [PK_MotionPictures] PRIMARY KEY ([ID])
);
GO
