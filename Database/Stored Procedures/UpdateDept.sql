create procedure spUpdateDepartment
(
	@deptid int,
	@deptname varchar(50),
	@hod varchar(50)
)
as
Begin 
	Update Department 
	SET 
	deptname = @deptname,
	hod = @hod
	WHERE deptid = @deptid
END