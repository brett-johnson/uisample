:: Name: push.bat
:: Author: Brett Johnson
:: Created: 20Nov24
:: Version: 1.0 (draft)
:: Description: Automated version management for MxD project.
:: Installation:
::   This script may be run from Powershell, CMD, and GitBash. To install, open a command
::   prompt AS ADMINISTRATOR, and move the script to C:\Windows\System32\.
:: Assumptions & Conditions:
::   - WARNING! This command merges upstream changes from git master BEFORE commit.
::   - This command advances the version number and checks in the code with a version tag
::     and a commit comment supplied by the developer.
::   - NOTE: A new version number is checked in to the git repo by this command. Any MxD
::     application that is compiled AFTER this command runs will contain the new version.
::   - It is presumed that there are uncommitted changes, and that it doesn't make sense
::     to bump the version if nothing has changed since the last checkin.
:: Usage:
::   From Git Bash, CMD, or PowerShell, run the following command in the source folder
::   where the version file is:
::
::     push
::
::   The developer will be prompted to enter a commit comment. <Enter> to check in the
::   code. A new version file will be created with the next minor version and build
::   version numbers. This will be checked in along with any outstanding changes and a tag
::   also reflecting the new version. Any app compiled after this code will contain the
::   newly checked-in version number.

:: Set up execution environment.
@echo off
setlocal enableextensions
@set versionfile=version.json

:: Make sure the version file exists.
@if not exist %versionfile% @echo FATAL ERROR: The version file (%versionfile%) is not found. 1>&2
@if not exist %versionfile% @echo The app version file must be in the current directory. 1>&2
@if not exist %versionfile% @exit /b 1

:: Extract and set the version major, minor, and build.
@type %versionfile%
@for /f "tokens=1,2 delims=:{} " %%A in (%versionfile%) do @set %%~A=%%~B
@set major=%major:,=%
@set minor=%minor:,=%
@set success=true
@echo major=%major%
@echo minor=%minor%
@echo build=%build%
@if "" == "%major%" @set success=false
@if "" == "%minor%" @set success=false
@if "" == "%build%" @set success=false
@if %success% == false @echo FATAL ERROR: Problem parsing %versionfile% (%major%.%minor%.%build%). 1>&2
@if %success% == false @exit /b 1
@echo Old version: %major%.%minor%.%build%

:: Get commit comment from developer.
@set /p comment=Enter git commit comment: 

:: Fetch and merge the latest MxD code before commit.
@call git fetch --all
@call git merge origin/main
@if errorlevel 1 @goto mergefailure
@call git commit -a -m "%comment%"

:: Advance the minor version.
@set /a minor=minor+1

:: Create a new build version from current date/time.
@set hr=%time:~0,2%
@if "%hr:~0,1%" == " " @set hr=0%hr:~1,1%
@set min=%time:~3,2%
@if "%min:~0,1%" == " " @set min=0%min:~1,1%
@set sec=%time:~6,2%
@if "%sec:~0,1%" == " " @set sec=0%sec:~1,1%
@set dy=%date:~0,2%
@if "%dy:~0,1%" == " " @set dy=0%dy:~1,1%
@set year=%date:~-4%
@set build=%sec%%dy%%year%%hr%%min%
@echo New version: %major%.%minor%.%build%

:: Update the version file with the new values.
(@echo {^

"version": {^

"major": %major%,^

"minor": %minor%,^

"build": %build%^

}^

})>%versionfile%
@echo Updated %versionfile%:
@type %versionfile%

@echo SUCCESS!
@goto :eof

:: Check MxD code in to git and make a tag for this version.
@call git commit -a -m "%comment% (%major%.%minor%.%build%)"
@call git push origin main
@call git tag "%major%.%minor%.%build%" main
@call git push --tags origin

:: Success!
@goto :eof

:: ---------------------------------------------------------------------------------------
:: ---------------------------------------------------------------------------------------
:: FATAL ERROR merge failure
:mergefailure
@echo FATAL ERROR: Git merge failure; resolve manually and try again 1>&2
@exit /b 1
