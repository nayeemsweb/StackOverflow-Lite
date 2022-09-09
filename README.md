# StackOverflow-Lite

Minimalistic version of Stack Overflow website. Users can post 
questions, answer them and also can vote others’ answers. Besides 
questioner can also mark as accepted one correct answer.

<div align="center" style="display: flex; justify-content: center"> 
    
[comment]: <> (Develop Build Checking)
<img alt="GitHub Workflow Status (branch)" src="https://img.shields.io/github/workflow/status/nayeemsweb/StackOverflow-Lite/.NET/develop?style=for-the-badge" style="margin-left: 10px;margin-right: 10px">

[comment]: <> (Issues Closed)
<img alt="GitHub closed issues" src="https://img.shields.io/github/issues-closed-raw/nayeemsweb/StackOverflow-Lite?color=%23ee5253&style=for-the-badge">

</div>

## Demo




## Installation

Firstly, clone the project-
```
https://github.com/nayeemsweb/StackOverflow-Lite.git
```
Secondly, Open the project in Visual Studio by running the `StackOverflow.sln` solution file - 
```
cd StackOverflow-Lite/src/StackOverflow
```
Thirdly, go to `docs` folder - 
```
cd StackOverflow-Lite/docs
```
There you will find a batch file named `StackOverflow_Migration_Runner.bat`. 
Run that batch file to update database - 

Step(1): `Apply Migration` [Option 2]

Step(2): `Update All` [Option 1]

or, You may manually run the `Update Database` using the following command
in the `Project Manager Console` in Visual Studio. 

```
dotnet ef database update -p .\Applications\StackOverflow.Web -c ApplicationDbContext
```

This will create a database named `StackOverflowDb` in your SQL Server 
(actually SSMS) and also the table(s) accordingly.

⚠️ ***Your must have `SQL Server` and* `SQL Server Management Studio` 
installed on your machine.***


    
## Environment Variables

Go to - 

```
cd StackOverflow-Lite\src\StackOverflow\Applications\StackOverflow.Web
```
In this path 
there is a file named `appsettings.json`. 
If you face in updating the migration then configure this line 
accordingly to your configuration - 
```
"DefaultConnection": "Server=.\\SQLEXPRESS;Database=EcommerceDb;Trusted_Connection=True;"
```

You may change the `Server` value according to your configuration.


## Tech Stack

**Backend:** ASP.NET (Core) 6,  Entity Framework (Core), Sql Server,
Fluent API

**Logger:** Serilog

**Dependency Injection:** Autofac

**Object-Object Mapper:** AutoMapper

**Design Patterns:** Repository & Unit of Work Patterns

**Architecture:** Layered Architecture - n-Tier Architecture -
(UI, Business Logic & Data Access Layer)




## Features

- Authentication, Authorization
- Posting Questions (Post)
- Answering those Questions (Comments)
- Voting different Questions and Answers
- Selecting one correct answer as Accepted


## Support

❤️ If you do like my work, hit the ⭐️ button above. ❤️


## License

[MIT](https://choosealicense.com/licenses/mit/)

