create procedure spDeleteDepartment
(
	@deptid int
)
as
BEGIN
	Delete from Student where sid = @deptid
END