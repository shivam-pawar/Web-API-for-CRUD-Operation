create procedure spDeleteStudent
(
	@sid int
)
as
BEGIN
	Delete from Student where sid = @sid
END