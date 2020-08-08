
--查看bak 包含哪些文件          
restore  filelistonly from 
disk ='C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\Backup\test.bak' 

--查看bak 包含哪些备份集 
restore headeronly from 
disk = 'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\Backup\test.bak' 


--还原完整和差异 备份集
RESTORE DATABASE test  
   FROM disk='C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\Backup\test.bak' 
   WITH NORECOVERY, FILE = 13,move 'test' to 'C:\SqlDb\test.mdf',
            move 'test_log' to 'C:\SqlDb\test_log.ldf';  
GO  
-- Now restore the differential database backup, the second backup on   
-- the MyAdvWorks_1 backup device.  
RESTORE DATABASE test  
   FROM disk='C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\Backup\test.bak'   
   WITH FILE = 14,  
   RECOVERY;  
GO  

