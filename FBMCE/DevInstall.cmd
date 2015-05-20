@ECHO OFF
ECHO.
ECHO.Usage: DevInstall.cmd [/u][/debug]
ECHO.
ECHO.This script requires Administrative privileges to run properly.
ECHO.Start > All Programs > Accessories> Right-Click Command Prompt > Select 'Run As Administrator'
ECHO.
 
set AssemblyName=FBMCE
set RegistrationName=Registration
 
ECHO.Determine whether we are on an 32 or 64 bit machine
if "%PROCESSOR_ARCHITECTURE%"=="x86" if "%PROCESSOR_ARCHITEW6432%"=="" goto x86
set ProgramFilesPath=%ProgramFiles%
ECHO.
 
goto unregister
 
:x86

    ECHO.On an x86 machine
    set ProgramFilesPath=%ProgramFiles%
    ECHO.

:unregister

    ECHO.*** Unregistering and deleting assemblies ***
    ECHO.

    ECHO.Unregister and delete previously installed files (which may fail if nothing is registered)
    ECHO.

    ECHO.Unregister the application entry points
    %windir%\ehome\RegisterMCEApp.exe /allusers "%ProgramFilesPath%\Hamar Data\%AssemblyName%\%RegistrationName%.xml" /u
    ECHO.

    ECHO.Remove the DLL from the Global Assembly cache
    "gacutil.exe" /u "%AssemblyName%"
    "gacutil.exe" /u "Facebook"  
    "gacutil.exe" /u "CommonFunctions"
    "gacutil.exe" /u "Twitter"
    ECHO.

    REM Exit out if the /u uninstall argument is provided, leaving no trace of program files.
    if "%1"=="/u" goto exit
                
:releasetype
 
    if "%1"=="/debug" goto debug
    set ReleaseType=Release
    ECHO.
    goto checkbin
                
:debug
    set ReleaseType=Debug
    ECHO.
                
:checkbin
 
    if exist ".\bin\%ReleaseType%\%AssemblyName%.dll" goto register
    ECHO.Cannot find %ReleaseType% binaries.
    ECHO.Build solution as %ReleaseType% and run script again. 
    goto exit
                
:register

    ECHO.*** Copying and registering assemblies ***
    ECHO.

    ECHO.Create the path for the binaries and supporting files (silent if successful)
    md "%ProgramFilesPath%\Hamar Data\%AssemblyName%"
    ECHO.
    
    ECHO.Copy the binaries to program files
    copy /y ".\bin\%ReleaseType%\%AssemblyName%.dll" "%ProgramFilesPath%\Hamar Data\%AssemblyName%\"
    copy /y ".\bin\%ReleaseType%\Facebook.dll" "%ProgramFilesPath%\Hamar Data\%AssemblyName%\"    
    copy /y ".\bin\%ReleaseType%\CommonFunctions.dll" "%ProgramFilesPath%\Hamar Data\%AssemblyName%\"  
    copy /y ".\bin\%ReleaseType%\Twitter.dll" "%ProgramFilesPath%\Hamar Data\%AssemblyName%\"  
    ECHO.
    
    ECHO.Copy the registration XML to program files
    copy /y ".\%RegistrationName%.xml" "%ProgramFilesPath%\Hamar Data\%AssemblyName%\"
    ECHO.

    ECHO.Register the DLL with the global assembly cache
    "gacutil.exe" /if "%ProgramFilesPath%\Hamar Data\%AssemblyName%\%AssemblyName%.dll"
    "gacutil.exe" /if "%ProgramFilesPath%\Hamar Data\%AssemblyName%\Facebook.dll"
    "gacutil.exe" /if "%ProgramFilesPath%\Hamar Data\%AssemblyName%\CommonFunctions.dll"
    "gacutil.exe" /if "%ProgramFilesPath%\Hamar Data\%AssemblyName%\Twitter.dll"
    ECHO.

    ECHO.Register the application with Windows Media Center
    %windir%\ehome\RegisterMCEApp.exe /allusers "%ProgramFilesPath%\Hamar Data\%AssemblyName%\%RegistrationName%.xml"
    ECHO.

:exit