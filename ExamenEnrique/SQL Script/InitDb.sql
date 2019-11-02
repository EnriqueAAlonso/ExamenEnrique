create database examen
go
use examen
go

create table users(

email nvarchar(100) not null,
pwd nvarchar(100));
go
create table cities(

email nvarchar(100) not null,
city nvarchar(100));
go
create procedure addUser
(
	@email nvarchar(100),
	@pwd nvarchar(100),
	@haserror bit out
)
as
begin try
	set @haserror = 0;
	insert into users
	values
	(@email,@pwd)
end try
begin catch
	set @haserror = 1;
end catch
go
create procedure getuser
(
@user nvarchar(100)
)
as
select * from users where @user=email
go
create procedure addCity
(
	@email nvarchar(100),
	@city nvarchar(100),
	@haserror bit out
)
as
begin try
	set @haserror = 0;
	insert into cities
	values
	(@email,@city)
end try
begin catch
	set @haserror = 1;
end catch
go
create procedure getcity
(
@user nvarchar(100)
)
as
select * from cities where @user=email
go