# StackOverflow-Lite

Minimalistic version of Stack Overflow website. Users can post 
questions, answer them and also can vote others’ answers. Besides 
questioner can also mark as accepted one correct answer.

<div align="center" style="justify-content:center;display:flex;"> 
    
[comment]: <> (Develop Build Checking)
<img alt="GitHub Workflow Status (branch)" src="https://img.shields.io/github/workflow/status/nayeemsweb/StackOverflow-Lite/.NET/develop?style=for-the-badge" style="margin-left: 10px;margin-right: 10px;">

[comment]: <> (Issues Closed)
<img alt="GitHub closed issues" src="https://img.shields.io/github/issues-closed-raw/nayeemsweb/StackOverflow-Lite?color=%23ee5253&style=for-the-badge" style="margin-left: 10px;margin-right: 10px;">

</div>

## Demo

![Stack Overflow](https://github.com/nayeemsweb/StackOverflow-Lite/blob/develop/docs/readme/Home.png?raw=true)


</br>

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
There you will find a batch file named **`StackOverflow_Migration_Runner.bat`**. 
Run that batch file to update database - 

Step(1): `Apply Migration` _[option 2]_

Step(2): `Update All` _[option 1]_

or, You may manually run the `Update Database` using the following command
in the `Project Manager Console` in Visual Studio. 

```
dotnet ef database update -p .\Applications\StackOverflow.Web -c ApplicationDbContext
```

This will create a database named `StackOverflowDb` in your SQL Server 
(actually SSMS) and also the table(s) accordingly.

⚠️ **Your must have `SQL Server` and `SQL Server Management Studio` 
installed on your machine.**

    
## Environment Variables

Go to - 

```
cd StackOverflow-Lite\src\StackOverflow\Applications\StackOverflow.Web
```
In this path 
there is a file named `appsettings.json`. 
If you face any issue updating the database then configure this line 
accordingly to your machine configuration - 
```
"ConnectionStrings": {
    "DefaultConnection": "Server=.\\SQLEXPRESS;Database=StackOverflowDb;Trusted_Connection=True;"
  },
```

You may change the `Server` value according to your configuration.


## Tech Stack

**Frontend:** ASP.NET Web App (MVC), Bootstrap UI Templates

**Backend:** ASP.NET (Core) 6,  Entity Framework (Core), Sql Server,
Fluent API

**Design Patterns:** Repository & Unit of Work Patterns

**Architecture:** Layered Architecture - n-Tier Architecture -
(UI, Business Logic & Data Access Layer)

**Error Logger:** Serilog

**Dependency Injection:** Autofac

**Object-Object Mapper:** AutoMapper






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

