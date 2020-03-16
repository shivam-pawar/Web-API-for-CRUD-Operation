create procedure spAddStudent
(
	@sid int,
	@sname varchar(50),
	@emailid varchar(50),
	@contact int,
	@deptid varchar(50)
)
as
Begin 
	INSERT INTO Student(sid,sname,emailid,contact,deptid)
	VALUES (@sid,@sname,@emailid,@contact,@deptid)
END