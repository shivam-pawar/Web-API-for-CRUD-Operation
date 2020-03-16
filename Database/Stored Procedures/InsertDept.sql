create procedure spAddDepartment
(
	@deptid int,
	@deptname varchar(50),
	@hod varchar(50)
)
as
Begin 
	INSERT INTO Department(deptid,deptname,hod)
	VALUES (@deptid,@deptname,@hod)
END