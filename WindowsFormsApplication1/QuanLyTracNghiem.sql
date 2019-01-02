create database TestManagement
go
use TestManagement
go
create table Student
(
	idStudent int IDENTITY(1,1) primary key,
	nameStudent nvarchar(45),
	gender nvarchar(10),
	class nvarchar(10),
	idAccount int
)
go

create table Class
(
	className nvarchar(10) not null primary key,
	grade int,
)
create table Teacher
(
	idTeacher int IDENTITY(1,1) primary key,
	nameTeacher nvarchar(45),
	class nvarchar(10),
	gender nvarchar(10),
	idAccount int
)
go

create table Admin
(
	idAdmin int IDENTITY(1,1) primary key,
	nameAdmin nvarchar(45),
	gender nvarchar(10),
	idAccount int
)
go

create table Account
(
	idAccount int IDENTITY(1,1) primary key,
	username varchar(45) unique,
	password varchar(45),
	role int
)
go

create table AccountRequest
(
	id int not null primary key,
	username varchar(45) unique,
	password varchar(45),
	role int
)
go

create table QuestionRequest
(
	id int IDENTITY(1,1) primary key,
	idStudent int not null,
	subject nvarchar(50) not null,
	grade int not null,
	question nvarchar(400),
	answerA nvarchar(100),
	answerB nvarchar(100),
	answerC nvarchar(100),
	answerD nvarchar(100),
	answerTrue nvarchar(100) not null,
	hardlevel int
)
go

create table Examination
(
	idExamination int IDENTITY(1,1) primary key,
	nameExamination nvarchar(100),
	startTime datetime,
	time int,
	countStudent int,
	type nvarchar(10),
	grade int
)
go

create table Result
(	
	idExamination int not null,
	idStudent int not null,
	subject nvarchar(50) not null,
	score float,
	constraint PK_Result primary key(idExamination,idStudent,subject)
)
go

create table Test
(
	idTest int IDENTITY(1,1) primary key,
	nameTest varchar(100),
	time int,
	subject nvarchar(50),
	grade int
)
go

create table Question
(
	idQuestion int IDENTITY(1,1) primary key,
	subject nvarchar(50),
	grade int,
	question nvarchar(400) unique,
	answerA nvarchar(100),
	answerB nvarchar(100),
	answerC nvarchar(100),
	answerD nvarchar(100),
	answerTrue nvarchar(100),
	hardlevel int,
)
go
create table Question_Test(
	idTest int not null,
	idQuestion int not null,
	primary key(idTest,idQuestion)
)
go
create table Test_Examination(
	idExamination int not null,
	idTest int not null,
	primary key(idExamination, idTest)
)
go

insert into Class values('12A1', 12), ('11B1', 11)

insert into Account values('hs01','F00EE32DAE4519308C88783F8C15A085581552D7',3) -- pass 123
insert into Student values(N'Học Sinh 01', 'nam', '12A1', 1)

insert into Account values('hs02','554345250C6A02D9A1DDCF0523149DBA4275BDC2',3) -- pass 123
insert into Student values(N'Học Sinh 02', N'nữ', '11B1', 2)

insert into Account values('gv01','27924B1087F1FBDB8DA1807F83EEE5E243A1543D',2) -- pass 123
insert into Teacher values(N'Giáo Viên 01', '12A1', N'nữ', 3)

insert into Account values('qt01','7B0EA62C17493107EE0F273BAB8BD400C3B1ECF8',1) -- pass 123
insert into Admin values(N'Quản Trị 01', 'nam', 4)

insert into Examination values('HK1','12/12/2018',15,100,N'thi thật',12)
insert into Examination values('HK2','5/5/2019',15,100,N'thi thật',12)
insert into Examination values('HK2','1/5/2019',15,100,N'thi thử',12)

insert into Test values('Test01',30,N'tiếng anh',12)
insert into Test values('Test02',30,N'tiếng anh',12)
insert into Test values('Test03',45,N'tiếng anh',12)
insert into Test values('Test04',45,N'tiếng anh',12)

insert into Question_Test values(1,1), (1,2), (1,3), (1,4), (1,5), (1,16), (1,17), (1,18), (1,19), (1,20), (1,31), (1,32), (1,33), (1,34), (1,35)
insert into Question_Test values(2,6), (2,7), (2,8), (2,9), (2,10), (2,21), (2,22), (2,23), (2,24), (2,25), (2,36), (2,37), (2,38), (2,39), (2,40)
insert into Question_Test values(3,11), (3,12), (3,13), (3,26), (3,27), (3,41), (3,42), (3,43), (3,44), (3,45), (3,46), (3,47), (3,48), (3,49), (3,50)
insert into Question_Test values(4,14), (4,15), (4,28), (4,29), (4,30), (4,51), (4,52), (4,53), (4,54), (4,55), (4,56), (4,57), (4,58), (4,59), (4,60)

insert into Test_Examination values(1,1), (1,2)
insert into Test_Examination values(2,3), (2,4)
insert into Test_Examination values(3,1), (3,4)

insert into QuestionRequest values(1,N'Toán',1,'1+1=?','2','3','1','1.5','2',1)
insert into QuestionRequest values(1,N'Toán',1,'1+2=?','2','3','1','1.5','3',1)

insert into Result values(1,1,N'tiếng anh',7.5)
insert into Result values(1,2,N'tiếng anh',8)

insert into Student values(N'Học Sinh 03', N'nữ', '11B2', null)