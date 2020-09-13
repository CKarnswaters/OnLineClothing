DROP DATABASE onlineclothing;
CREATE DATABASE onlineclothing;

USE onlineclothing;

CREATE TABLE Categories (
	ID int NOT NULL AUTO_INCREMENT,
    Category varchar(25) NOT NULL,
    PRIMARY KEY(ID)
);

CREATE TABLE Items (
	ID int NOT NULL AUTO_INCREMENT,
    CategoryID int NOT NULL,
    Title varchar(100) NOT NULL,
    Price decimal,
    ItemDescription varchar(1000),
    Image varchar(100),
    PRIMARY KEY(ID),
    CONSTRAINT FK_ItemCategory FOREIGN KEY (CategoryID) REFERENCES Categories(ID)
);

CREATE TABLE Login (
	ID int NOT NULL AUTO_INCREMENT,
    Rights varchar(10) NOT NULL,
    UserName varchar(15) NOT NULL,
    PasswordSalt varchar(15) NOT NULL,
    PasswordHash varchar(100) NOT NULL,
    PRIMARY KEY(ID)
);

CREATE TABLE Users (
	ID int NOT NULL AUTO_INCREMENT,
    LoginID int NOT NULL,
    FirstName varchar(25) NOT NULL,
    LastName varchar(25) NOT NULL,
    Address varchar(50) NOT NULL,
    City varchar(25) NOT NULL,
    ZipCode char(5) NOT NULL,
    PRIMARY KEY(ID),
    CONSTRAINT FK_UserLoginUsers FOREIGN KEY (LoginID) REFERENCES Login(ID)
);

CREATE TABLE Cart (
	ID int NOT NULL AUTO_INCREMENT,
    LoginID int NOT NULL,
    ItemID int NOT NULL,
    Quantity int NOT NULL,
    PRIMARY KEY(ID),
    CONSTRAINT FK_UserLoginCart FOREIGN KEY (LoginID) REFERENCES Login(ID),
    CONSTRAINT FK_ItemCart FOREIGN KEY (ItemID) REFERENCES Items(ID)
);

CREATE TABLE OrderHistory (
	ID int NOT NULL AUTO_INCREMENT,
    LoginID int NOT NULL,
    ItemID int NOT NULL,
    Quantity int NOT NULL,
    OrderDate datetime NOT NULL,
    Total decimal NOT NULL,
    PRIMARY KEY (ID),
    CONSTRAINT FK_UserLoginHistory FOREIGN KEY (LoginID) REFERENCES Login(ID),
    CONSTRAINT FK_ItemHistory FOREIGN KEY (ItemID) REFERENCES Items(ID)
);


    