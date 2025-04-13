
# LogToEventLog

DESCRIPTION: 
- "Tags" the server Event Log with process execution

> NOTES: "v1.0" was completed in 2012. 

## Requirements:

Operating System Requirements:
- Windows Server 2003 or higher (32-bit)
- Windows Server 2008 or higher (32-bit)

Additional software requirements:
Microsoft .NET Framework v3.5


## Operation and Configuration:

Command-line parameters:
- MyApplication (specify the application/process name)

Additional parameters: (one of these additional parameters is required)
- 9900 (specify that the application/process was called; the end of the execution may not be known)
- 9901 (specify the start of the program)
- 9902 (specify the end of the program)
