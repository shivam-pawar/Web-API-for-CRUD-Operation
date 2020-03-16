create procedure spUpdateStudent
(
	@sid int,
	@sname varchar(50),
	@emailid varchar(50),
	@contact int,
	@deptid varchar(50)
)
as
Begin 
	Update Student 
	SET 
	sname = @sname,
	emailid = @emailid,
	contact = @contact,
	deptid = @deptid
	WHERE sid = @sid
END