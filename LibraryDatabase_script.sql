-------------------------------------------------
--- script to create LibraryDatabase database ---
-------------------------------------------------
--drop fk
alter table Books drop constraint fk_books_publisherid;
go

alter table BookAuthors drop constraint fk_bookauthors_bookid;
go

alter table BookAuthors drop constraint fk_bookauthors_authorid;
go

alter table BookCategories drop constraint fk_bookcategories_bookid;
go

alter table BookCategories drop constraint fk_bookcategories_categoryid;
go

alter table BookLibraries drop constraint fk_booklibraries_libraryid;
go

alter table BookLibraries drop constraint fk_booklibraries_bookid;
go

alter table Libraries drop constraint fk_libraries_addressid;
go

alter table Members drop constraint fk_members_addressid;
go

alter table Requests drop constraint fk_requests_requestedby;
go

alter table Requests drop constraint fk_requests_bookid;
go

--drop tables
drop table Books;
go
drop table Authors;
go
drop table BookAuthors;
go
drop table Categories;
go
drop table BookCategories;
go
drop table Addresses;
go
drop table Libraries;
go
drop table BookLibraries;
go
drop table Members;
go
drop table Requests;
go
drop table Publishers;
go

--create tables
create table Publishers (
	PublisherId int not null IDENTITY(1,1),
	Name varchar(50),
	constraint pk_publisher primary key clustered (PublisherId)
);
go

create table Books (
	BookId int not null IDENTITY(1,1),
	Title varchar(50),
	PublisherId int,
	[Year] int,
	Price decimal,
	constraint pk_book primary key clustered (BookId) 
);
go

create table Authors (
	AuthorId int not null IDENTITY(1,1),
	FirstName varchar(50),
	LastName varchar(50),
	BirthDate date,
	constraint pk_author primary key clustered (AuthorId)
);
go

create table BookAuthors (
	BookAuthorId int not null,
	BookId int,
	AuthorId int,
	constraint pk_bookauthor primary key clustered (BookAuthorId)
);
go

create table Categories (
	CategoryId int not null IDENTITY(1,1),
	Name varchar(50),
	constraint pk_category primary key clustered (CategoryId)
);
go

create table BookCategories (
	BookCategoryId int not null,
	BookId int,
	CategoryId int,
	constraint pk_bookcategory primary key clustered (BookCategoryId)
);
go

create table Addresses (
	AddressId int not null IDENTITY(1,1),
	Street varchar(50),
	BuildingNumber int,
	BuildingName varchar(50),
	EntranceNumber varchar(10),
	[Floor] varchar(10),
	ApartmentNumber int,
	City  varchar(50),
	PostalCode int,
	Country  varchar(50),
	OtherDetails varchar(100),
	constraint pk_address primary key clustered (AddressId)
);
go

create table Libraries (
	LibraryId int not null IDENTITY(1,1),
	Name varchar(50),
	AddressId int,
	constraint pk_library primary key clustered (LibraryId)
);
go

create table BookLibraries (
	BookLibraryId int not null,
	LibraryId int, 
	BookId int,
	Quantity int, 
	constraint pk_booklibrary primary key clustered (BookLibraryId)
);
go


create table Members (
	MemberId int not null IDENTITY(1,1),
	FirstName varchar(50),
	LastName varchar(50),
	PermitNumber varchar(50), 
	AddressId int,
	Gender varchar(10),
	PhoneNumber varchar(20),
	EmailAddress varchar(50),
	Password varchar(100),
	constraint pk_member primary key clustered (MemberId)
);
go

create table Requests (
	RequestId int not null IDENTITY(1,1),
	RequestedBy int,
	BookId int, 
	DateRequested date, 
	DateReturned date, 
	constraint pk_request primary key clustered (RequestId)
);
go


--add foreign keys
alter table Books add constraint fk_books_publisherid foreign key ( PublisherId ) references Publishers(PublisherId) on delete cascade;
go

alter table BookAuthors add constraint fk_bookauthors_bookid foreign key ( BookId ) references Books(BookId) on delete cascade;
go

alter table BookAuthors add constraint fk_bookauthors_authorid foreign key ( AuthorId ) references Authors(AuthorId) on delete cascade;
go

alter table BookCategories add constraint fk_bookcategories_bookid foreign key ( BookId ) references Books(BookId) on delete cascade;
go

alter table BookCategories add constraint fk_bookcategories_categoryid foreign key ( CategoryId ) references Categories(CategoryId) on delete cascade;
go

alter table BookLibraries add constraint fk_booklibraries_libraryid foreign key ( LibraryId ) references Libraries(LibraryId) on delete cascade;
go

alter table BookLibraries add constraint fk_booklibraries_bookid foreign key ( BookId ) references Books(BookId) on delete cascade;
go

alter table Libraries add constraint fk_libraries_addressid foreign key ( AddressId ) references Addresses(AddressId) on delete cascade;
go

alter table Members add constraint fk_members_addressid foreign key ( AddressId ) references Addresses(AddressId) on delete cascade;
go

alter table Requests add constraint fk_requests_requestedby foreign key (RequestedBy) references Members(MemberId) on delete cascade;
go

alter table Requests add constraint fk_requests_bookid foreign key ( BookId ) references Books(BookId) on delete cascade;
go


--fill in some values
insert into Publishers (Name) values ('Polirom'); --1
go
insert into Publishers (Name) values ('For you'); --2
go
insert into Publishers (Name) values ('Litera'); --3
go
insert into Publishers (Name) values ('Nemira'); --4
go
insert into Publishers (Name) values ('Rao'); --5
go
insert into Publishers (Name) values ('Trei'); --6
go
insert into Publishers (Name) values ('Asa'); --7
go
insert into Publishers (Name) values ('Art'); --8
go


insert into Categories (Name) values ('Clasici'); --1
go
insert into Categories (Name) values ('Fictiune'); --2
go
insert into Categories (Name) values ('Fantasy'); --3
go
insert into Categories (Name) values ('Crime, Thriller'); --4
go
insert into Categories (Name) values ('Aventura'); --5
go



insert into Books (Title, PublisherId, [Year], Price) values ('Constelatia fenomenelor vitale', 1, 2016, 17); --1
go
insert into Books (Title, PublisherId, [Year], Price) values ('Toata lumina pe care nu o putem vedea', 2, 2016, 13); --2
go
insert into Books (Title, PublisherId, [Year], Price) values ('Singuratatea numerelor prime', 3, 2011, 8); --3
go
insert into Books (Title, PublisherId, [Year], Price) values ('Portretul lui Dorian Grey', 1, 2013, 18); --4
go
insert into Books (Title, PublisherId, [Year], Price) values ('Urzeala tronurilor', 4, 2017, 30); --5
go
insert into Books (Title, PublisherId, [Year], Price) values ('Numele vantului', 5, 2017, 35); --6
go
insert into Books (Title, PublisherId, [Year], Price) values ('Cartea vietii', 3, 2017, 24); --7
go
insert into Books (Title, PublisherId, [Year], Price) values ('Chimista', 6, 2016, 33); --8
go
insert into Books (Title, PublisherId, [Year], Price) values ('Baltagul', 7, 2014, 22); --9
go
insert into Books (Title, PublisherId, [Year], Price) values ('Harry Potter vol. 5', 8, 2017, 64); --10
go
insert into Books (Title, PublisherId, [Year], Price) values ('Puterea armelor', 6, 2017, 35); --11
go


insert into BookCategories (BookCategoryId, BookId, CategoryId) values (1, 1, 1);
go
insert into BookCategories (BookCategoryId, BookId, CategoryId) values (2, 2, 2);
go
insert into BookCategories (BookCategoryId, BookId, CategoryId) values (3, 3, 1);
go
insert into BookCategories (BookCategoryId, BookId, CategoryId) values (4, 4, 1);
go
insert into BookCategories (BookCategoryId, BookId, CategoryId) values (5, 5, 3);
go
insert into BookCategories (BookCategoryId, BookId, CategoryId) values (6, 6, 3);
go
insert into BookCategories (BookCategoryId, BookId, CategoryId) values (7, 7, 3);
go
insert into BookCategories (BookCategoryId, BookId, CategoryId) values (8, 8, 4);
go
insert into BookCategories (BookCategoryId, BookId, CategoryId) values (9, 9, 1);
go
insert into BookCategories (BookCategoryId, BookId, CategoryId) values (10, 10, 5);
go
insert into BookCategories (BookCategoryId, BookId, CategoryId) values (11, 11, 5);
go


insert into Authors (FirstName, LastName, BirthDate) values ('Anthony', 'Marra', CONVERT(DATETIME, '1-JAN-1984') ); --1
go
insert into Authors (FirstName, LastName, BirthDate) values ('Anthony', 'Doerr', CONVERT(DATETIME, '27-OCT-1973') ); --2
go
insert into Authors (FirstName, LastName, BirthDate) values ('Paolo', 'Giordano', CONVERT(DATETIME, '19-DEC-1982') ); --3
go
insert into Authors (FirstName, LastName, BirthDate) values ('Oscar', 'Wilde', CONVERT(DATETIME, '16-OCT-1854') ); --4
go
insert into Authors (FirstName, LastName, BirthDate) values ('George R.R.', 'Martin', CONVERT(DATETIME, '20-SEP-1948') ); --5
go
insert into Authors (FirstName, LastName, BirthDate) values ('Patrick', 'Rothfuss', CONVERT(DATETIME, '6-JUN-1973') ); --6
go
insert into Authors (FirstName, LastName, BirthDate) values ('Deborah', 'Harkness', CONVERT(DATETIME, '5-APR-1965') ); --7
go
insert into Authors (FirstName, LastName, BirthDate) values ('Stephanie', 'Meyer', CONVERT(DATETIME, '24-DEC-1973') ); --8
go
insert into Authors (FirstName, LastName, BirthDate) values ('Mihail', 'Sadoveanu', CONVERT(DATETIME, '5-NOV-1880') ); --9
go
insert into Authors (FirstName, LastName, BirthDate) values ('J. K.', 'Rowling', CONVERT(DATETIME, '31-JUL-1965') ); --10
go
insert into Authors (FirstName, LastName, BirthDate) values ('Joe', 'Abercrombie', CONVERT(DATETIME, '31-DEC-1974') ); --11
go



insert into BookAuthors (BookAuthorId, BookId, AuthorId) values (1, 1, 1);
go
insert into BookAuthors (BookAuthorId, BookId, AuthorId) values (2, 2, 2);
go
insert into BookAuthors (BookAuthorId, BookId, AuthorId) values (3, 3, 3);
go
insert into BookAuthors (BookAuthorId, BookId, AuthorId) values (4, 4, 4);
go
insert into BookAuthors (BookAuthorId, BookId, AuthorId) values (5, 5, 5);
go
insert into BookAuthors (BookAuthorId, BookId, AuthorId) values (6, 6, 6);
go
insert into BookAuthors (BookAuthorId, BookId, AuthorId) values (7, 7, 7);
go
insert into BookAuthors (BookAuthorId, BookId, AuthorId) values (8, 8, 8);
go
insert into BookAuthors (BookAuthorId, BookId, AuthorId) values (9, 9, 9);
go
insert into BookAuthors (BookAuthorId, BookId, AuthorId) values (10, 10, 10);
go
insert into BookAuthors (BookAuthorId, BookId, AuthorId) values (11, 11, 11);
go



insert into Addresses (Street, BuildingNumber, BuildingName, EntranceNumber, [Floor], ApartmentNumber, City, PostalCode, Country, OtherDetails)
	values ('Strada Pacurari 4', null, null, null, null, null, 'Iasi', 700511, 'Romania', null); --1
go
insert into Addresses (Street, BuildingNumber, BuildingName, EntranceNumber, [Floor], ApartmentNumber, City, PostalCode, Country, OtherDetails)
	values ('Strada Pacurari 4B', 581, null, 'B', 2, 12, 'Iasi', 700531, 'Romania', null); --2
go
insert into Addresses (Street, BuildingNumber, BuildingName, EntranceNumber, [Floor], ApartmentNumber, City, PostalCode, Country, OtherDetails)
	values ('Bulevardul Independentei 2', 128, null, 'A', 1, 5, 'Iasi', 700540, 'Romania', null); --3
go
insert into Addresses (Street, BuildingNumber, BuildingName, EntranceNumber, [Floor], ApartmentNumber, City, PostalCode, Country, OtherDetails)
	values ('Strada Petre Tutea 9', null, null, null, null, null, 'Iasi', 700376, 'Romania', null); --4
go
insert into Addresses (Street, BuildingNumber, BuildingName, EntranceNumber, [Floor], ApartmentNumber, City, PostalCode, Country, OtherDetails)
	values ('Strada Clinicilor 2', null, null, null, null, null, 'Cluj-Napoca', 701400, 'Romania', null); --5
go


insert into Libraries (Name, AddressId) values ('Biblioteca Centrala Universitara', 1); --1
go
insert into Libraries (Name, AddressId) values ('Biblioteca Gheorghe Asachi', 4); --2
go
insert into Libraries (Name, AddressId) values ('Biblioteca Centrala Universitara', 5); --3
go

insert into BookLibraries (BookLibraryId, LibraryId, BookId, Quantity) values (1, 1, 1, 5);
go
insert into BookLibraries (BookLibraryId, LibraryId, BookId, Quantity) values (2, 1, 2, 3);
go
insert into BookLibraries (BookLibraryId, LibraryId, BookId, Quantity) values (3, 1, 3, 10);
go
insert into BookLibraries (BookLibraryId, LibraryId, BookId, Quantity) values (4, 1, 4, 6);
go
insert into BookLibraries (BookLibraryId, LibraryId, BookId, Quantity) values (5, 1, 5, 25);
go
insert into BookLibraries (BookLibraryId, LibraryId, BookId, Quantity) values (6, 1, 6, 10);
go
insert into BookLibraries (BookLibraryId, LibraryId, BookId, Quantity) values (7, 1, 7, 4);
go
insert into BookLibraries (BookLibraryId, LibraryId, BookId, Quantity) values (8, 1, 8, 2);
go
insert into BookLibraries (BookLibraryId, LibraryId, BookId, Quantity) values (9, 2, 9, 5);
go
insert into BookLibraries (BookLibraryId, LibraryId, BookId, Quantity) values (10, 2, 10, 8);
go
insert into BookLibraries (BookLibraryId, LibraryId, BookId, Quantity) values (11, 2, 11, 4);
go
insert into BookLibraries (BookLibraryId, LibraryId, BookId, Quantity) values (12, 2, 2, 14);
go
insert into BookLibraries (BookLibraryId, LibraryId, BookId, Quantity) values (13, 2, 3, 7);
go
insert into BookLibraries (BookLibraryId, LibraryId, BookId, Quantity) values (14, 3, 11, 3);
go
insert into BookLibrary (BookLibraryId, LibraryId, BookId, Quantity) values (15, 3, 2, 5);
go


insert into Members (FirstName, LastName, PermitNumber, AddressId, Gender, PhoneNumber, EmailAddress, [Password])
	values ('Daniel', 'Ionescu', 'AGX-40194', 2, 'm', '0728406394', 'daniel.popescu@gmail.com', 'start123'); --1
go
insert into Members (FirstName, LastName, PermitNumber, AddressId, Gender, PhoneNumber, EmailAddress, [Password])
	values ('Mihai', 'Popescu', 'BCS-40329', 3, 'm', '0749281504', 'mihai.popescu@yahoo.com', 'start123'); --2
go

insert into Requests (RequestedBy, BookId, DateRequested, DateReturned) values (1, 2, CONVERT(DATETIME, '15-MAY-2017'), CONVERT(DATETIME, '21-MAY-2017'));
go 
insert into Requests (RequestedBy, BookId, DateRequested, DateReturned) values (1, 6, CONVERT(DATETIME, '21-SEP-2017'), CONVERT(DATETIME, '30-SEP-2017'));
go 
insert into Requests (RequestedBy, BookId, DateRequested, DateReturned) values (1, 8, CONVERT(DATETIME, '18-DEC-2017'), null);
go 
insert into Requests (RequestedBy, BookId, DateRequested, DateReturned) values (2, 5, CONVERT(DATETIME, '11-MAR-2017'), null);
go 
insert into Requests (RequestedBy, BookId, DateRequested, DateReturned) values (2, 8, CONVERT(DATETIME, '14-JUN-2017'), CONVERT(DATETIME, '24-JUN-2017'));
go 

insert into Requests (RequestedBy, BookId, DateRequested, DateReturned) values (1, 11, CONVERT(DATETIME, '12-AUG-2017'), CONVERT(DATETIME, '21-AUG-2017'));
go 
insert into Requests (RequestedBy, BookId, DateRequested, DateReturned) values (1, 9, CONVERT(DATETIME, '13-OCT-2017'), null);
go 

/*
Biblioteca Centrala Universitara, Strada Pacurari 4, Iasi, 700511
1. ‘De veghe in lanul de secara’, J.D. Salinger,, Polirom, 2016 - Clasici; 17 lei; 5
copii
2. ‘Fluturi’, Irina Binder, For you, 2016 - Fictiune; 13 lei; 3 copii
3. ‘Proza’, Mihai Eminescu, Litera, 2011 - Clasici; 8 lei; Hardcover; 10 copii
4. ‘Portretul lui Dorian Grey’, Oscar Wilde, Polirom, 2013 - Clasici; 18 lei; 6 copii
5. ‘Urzeala tronurilor’, George R. R. Martin, Nemira, 2017 - Fantasy; 30 lei;
Hardcover; 25 copii
6. ‘Numele vantului’, Patrick Rothfuss, Rao, 2017 - Fantasy; 35 lei; 10 copii
7. ‘Cartea vietii’, Deborah Harkness, Litera, 2017 - Fantasy; 24 lei; 4 copii
8. ‘Chimista’, Stephanie Meyer, Trei, 2016 - Crime, Thriller; 33 lei; 2 copii
*/

/*
Members
1. Daniel Ionescu, Strada Pacurari 4B, bl. 581, sc. B, et. 2, ap. 12, Iasi,
0728406394, daniel.popescu@gmail.com; permis AGX-40194
a. Carti imprumutate
i. Fluturi; 15/05/2017 - 21/05/2017
ii. Numele vantului; 21/09/2017 - 30/09/2017
iii. Chimista; 18/12/2017 -
2. Mihai Popescu, Bulevardul Independentei 2, bl. 128, sc. A, et. 1, ap. 5, Iasi,
0749281504, mihai.popescu@yahoo.com; permis BCS-40329
a. Carti imprumutate
i. Urzeala tronurilor; 11/03/2017 -
ii. Chimista; 14/06/2017 - 24/06/2017
*/

/*
Biblioteca ‘Gheorghe Asachi’, Strada Petre Tutea 9, Iasi
1. ‘Baltagul’, Mihail Sadoveanu, Asa, 2014 - Clasici; 22 lei; 5 copii
2. ‘Harry Potter vol. 5’, J. K. Rowling, Art, 2017 - Aventura; 64 lei; 8 copii
3. ‘Puterea armelor’, Joe Abercrombie, Nemira, 2017, - Aventura; 35 lei; 4 copii
4. ‘Fluturi’, Irina Binder, For you, 2016 - Fictiune; 13 lei; 14 copii
5. ‘Proza’, Mihai Eminescu, Litera, 2011 - Clasici; 8 lei; Hardcover; 7 copii
*/

/*
Members
1. Daniel Ionescu, Strada Pacurari 4B, bl. 581, sc. B, et. 2, ap. 12, Iasi,
0728406394, daniel.popescu@gmail.com; permis FME-23043
a. Carti imprumutate
i. Puterea armelor; 12/08/2017 - 21/08/2017
ii. Baltagul; 13/10/2017 -
*/

/*
Biblioteca Centrala Universitara, Strada Clinicilor 2, Cluj Napoca
1. ‘Puterea armelor’, Joe Abercrombie, Nemira, 2017, - Aventura; 35 lei; 3 copii
2. ‘Fluturi’, Irina Binder, For you, 2016 - Fictiune; 13 lei; 5 copii
*/
