## C-Sharp Malicious Injections Guard

The .Net C# project "Check Malicious" is a security gateway against Sql injections and other malicious.

### Project Topic

The "ClientInputSecurity" sub project runs Web Api and makes the tests against malicious inputs by these criterias:  

 	0 > Entity ID <= 1000 (for this example)  
  	0 > Dictionary ID <= 100 (for this example)

	SQL Injection possible words:
	--,  ;--,  ;,  /*,  */,  @@,  @,  char,  nchar,  varchar,  nvarchar,  alter,   begin,  cast,  
 	create,  cursor,  declare,  delete,  drop,  end,  exec,  execute, fetch,  insert,  kill,  select,  
  	sys,  sysobjects,  syscolumns,  table,  update

	0 > Entity Name Max Length <= 50 (for this example)

	Entity Description Max Length <= 500 (for this example)

### Additional Info	

The start page is TestPage.html

** Open Sql Server Management Studio and create the project database by TheArt.bak file.
**

