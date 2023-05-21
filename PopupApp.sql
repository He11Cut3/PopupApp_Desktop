-- Создание базы --

create database PopupApp_db
go

-- Конец --

-- Использовать для базы --

use PopupApp_db
go

create table PopupApp_Own
(
PopupApp_Own_id int primary key identity(1,1),
PopupApp_Treaty_id int,
)
create table PopupApp_User
(
PopupApp_User_id int primary key identity(1,1),
PopupApp_User_Login nvarchar(50),
PopupApp_User_Password nvarchar(50),
)
create table PopupApp_Treaty
(
PopupApp_Treaty_id int primary key identity(1,1),
PopupApp_Treaty_Name nvarchar(150),
PopupApp_Treaty_Number_Treaty nvarchar(150),
PopupApp_Treaty_Location nvarchar(50),
PopupApp_Treaty_Start_Date nvarchar(50),
PopupApp_Treaty_End_Date nvarchar(50),
PopupApp_Treaty_Coming nvarchar(50),
PopupApp_Treaty_Services nvarchar(50),
PopupApp_Treaty_Counterparty nvarchar(50),
PopupApp_Treaty_File_Name nvarchar(50),
PopupApp_Treaty_File varbinary(max),
PopupApp_Treaty_Cost nvarchar(50),
PopupApp_Treaty_Status nvarchar(50),
)