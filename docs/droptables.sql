CREATE PROCEDURE dbo.dropTables
	
AS
declare @cmd varchar(4000)
declare cmds cursor for 
Select
    'drop table [' + Table_Name + ']'
From
    INFORMATION_SCHEMA.TABLES
 

open cmds
while 1=1
begin
    fetch cmds into @cmd
    if @@fetch_status != 0 break

	BEGIN TRY
		exec(@cmd)
	END TRY
	BEGIN CATCH
	END CATCH
end


