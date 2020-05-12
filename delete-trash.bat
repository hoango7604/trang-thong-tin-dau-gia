@ECHO off
cls

ECHO Deleting all "trash" folders...
ECHO.

FOR /d /r . %%d in (bin,obj,node_modules,.vs) DO (
	IF EXIST "%%d" (		 	 
		ECHO %%d | FIND /I "\node_modules\" > Nul && ( 
			ECHO.Skipping: %%d
		) || (
			ECHO.Deleting: %%d
			rd /s/q "%%d"
		)
	)
)

ECHO.
ECHO.All "trash" folders have been successfully deleted. Press any key to exit.
pause > nul