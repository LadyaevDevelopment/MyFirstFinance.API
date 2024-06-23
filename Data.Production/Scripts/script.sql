create database MyFirstFinance
alter database MyFirstFinance set recovery simple
go

use MyFirstFinance;

create table Users(
	[Id] uniqueidentifier not null constraint PK_Users primary key default NEWID(),
	[FirstName] nvarchar(100) not null,
	[MiddleName] nvarchar(100) null,
	[LastName] nvarchar(100) not null,
	[RegistrationDate] datetime not null,
	[StatusId] int not null,
	[PhoneNumber] nvarchar(20) not null,
	[Email] nvarchar(50) null,
	[AvatarPath] nvarchar(max) null
);
go

create table ConfirmationCodes(
	[Id] uniqueidentifier not null constraint PK_ConfirmationCodes primary key default NEWID(),
	[UserId] uniqueidentifier not null constraint FK_ConfirmationCodes_UserId foreign key references Users(Id),
	[Code] nvarchar(10) not null,
	[CreationDate] datetime not null,
	[StatusId] int not null
);
go

create table PolicyDocuments(
	[Id] uniqueidentifier not null constraint PK_PolicyDocuments primary key default NEWID(),
	[Title] nvarchar(100) not null,
	[Path] nvarchar(max) not null
);
go

create table Countries(
	[Id] uniqueidentifier not null constraint PK_Countries primary key default NEWID(),
	[Name] nvarchar(250) not null,
	[Iso2Code] nvarchar(2) not null constraint UQ_Countries_Iso2Code unique,
	[PhoneNumberCode] nvarchar(10) not null,
	[FlagImagePath] nvarchar(max) not null
);
go

create table CountryPhoneNumberMasks(
	[Id] uniqueidentifier not null constraint PK_CountryPhoneNumberMasks primary key default NEWID(),
	[CountryId] uniqueidentifier not null constraint FK_CountryPhoneNumberMasks_CountryId foreign key references Countries(Id),
	[Mask] nvarchar(20) not null
);
go

create table UserResidenceAddresses(
	[Id] uniqueidentifier not null constraint PK_Users primary key default NEWID(),
	[CountryId] uniqueidentifier not null constraint FK_UserResidenceAddresses_CountryId foreign key references Countries(Id),
	[City] nvarchar(250) not null,
	[Street] nvarchar(250) not null,
	[BuildingNumber] nvarchar(20) not null,
	[ApartmentNumber] nvarchar(20) not null
);
go