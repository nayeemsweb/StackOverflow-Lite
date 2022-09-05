@echo off

:: Defined Main Project Path Here
set mainProject=../src/StackOverflow/Applications/StackOverflow.Web

:: Defined Other DbContext Here
set dbcontext[0]=ApplicationDbContext
:: Don't modify in the below

title Stack Overflow Migration Runner
set /a dbcontextSize=0
set migrationdirectory=Data/Migrations
set /a tempcount=dbcontextSize+2
set /a count=1

:Loop 
if defined dbcontext[%dbcontextSize%] ( 
set /a dbcontextSize+=1
goto :Loop 
)

set /a dbcontextSize-=1

:MainMenu
cls
echo:
echo ============ Stack Overflow Migration Runner ==============
echo: 
echo 1. Create Migration 
echo 2. Apply Migration
echo 3. Remove Migration
echo 0. Exit
echo:

set /p options="Enter your choice: "

if %options% == 0 goto :Exist
if %options% == 1 goto :CreateMigrations
if %options% == 2 goto :ApplyMigrations
if %options% == 3 goto :RemoveMigrations
if %options% gtr 3 goto :WrongInput

:RemoveMigrations
cls
set /a count=1
echo:
echo ============ Stack Overflow Migration Runner ==============
echo: 
echo ============     Remove Migration       ==============
echo:
setlocal enabledelayedexpansion
for /l %%n in (0,1,%dbcontextSize%) do (
	echo !count!. !dbcontext[%%n]!
	set /a count=count+1
)
echo !count!. Main Menu
echo 0. Exit
echo:
echo ======================================================
echo:
set /p options="Enter your choice: "
if %options% == 0 goto :Exist
if %options% == %count% goto :MainMenu
set /a ddd=%count%-1
if %options% gtr %ddd% goto :WrongInput
set /a index=%options%-1
echo:
echo migration is being removed on the !dbcontext[%index%]!...
echo:
dotnet ef migrations remove --project !mainProject! --context !dbcontext[%index%]! --force
echo:
echo migration has been successfully removed on the !dbcontext[%index%]!...
echo:
endlocal
set /p choice="Press Enter Key to go to removed migration menu..."
goto :RemoveMigrations

:CreateMigrations
cls
set /a count=1
echo:
echo ============ Stack Overflow Migration Runner ==============
echo: 
echo ============     Create Migration       ==============
echo:
setlocal enabledelayedexpansion
for /l %%n in (0,1,%dbcontextSize%) do (
	echo !count!. !dbcontext[%%n]!
	set /a count=count+1
)
echo !count!. Main Menu
echo 0. Exit
echo:
echo ======================================================
echo:
set /p options="Enter your choice: "
if %options% == 0 goto :Exist
if %options% == %count% goto :MainMenu
set /a ddd=%count%-1
if %options% gtr %ddd% goto :WrongInput
echo:
set /p args="Enter migration name: "
set /a index=%options%-1
echo:
echo !args! migration is being created on the !dbcontext[%index%]!...
echo:
dotnet ef migrations add !args! --project !mainProject! --context !dbcontext[%index%]! -o !migrationdirectory! 
echo:
echo !args! migration has been successfully created on the !dbcontext[%index%]!...
echo:
endlocal
set /p choice="Press Enter Key to go to create migration menu..."
goto :CreateMigrations

:ApplyMigrations
cls
set /a count=2
echo:
echo ============ Stack Overflow Migration Runner ==============
echo: 
echo ============     Apply Migration       ==============
echo: 
echo 1. Update All
setlocal enabledelayedexpansion
for /l %%n in (0,1,%dbcontextSize%) do (
	echo !count!. !dbcontext[%%n]!
	set /a count=count+1
)
echo !count!. Main Menu
echo 0. Exit
echo:
echo ======================================================
echo:
set /p options="Enter your choice: "
if %options% == 0 goto :Exist
if %options% == %count% goto :MainMenu
if %options% == 1 goto :Runallcontexts
set /a ddd=%count%-1
if %options% gtr %ddd% goto :WrongInput
set /a index=%options%-2
echo:
echo migration is being applied on the !dbcontext[%index%]!...
echo:
dotnet ef database update --project !mainProject! --context !dbcontext[%index%]!
echo:
echo migration successfully applied on the !dbcontext[%index%]!...
echo:
endlocal
set /p choice="Press Enter Key to go to apply migration menu..."
goto :ApplyMigrations


:Runallcontexts
echo:
echo Updating All DbContexts...
setlocal enabledelayedexpansion

for /l %%n in (0,1,%dbcontextSize%) do (
	echo:
	echo migration is being applied on the !dbcontext[%%n]!...
	echo:
	if %%n equ 0 (dotnet ef database update --project !mainProject! --context !dbcontext[%%n]!) else (dotnet ef database update --no-build --project !mainProject! --context !dbcontext[%%n]!)
	echo:
	echo migration successfully applied on the !dbcontext[%%n]!...
)
echo:
endlocal
set /p choice="Press Enter Key to go to apply migration menu..."
goto :ApplyMigrations

:Wronginput
echo:
echo Entered Wrong input.
echo:
set /p choice="Press Enter for main menu..."
goto MainMenu

:Exist
echo:
pause