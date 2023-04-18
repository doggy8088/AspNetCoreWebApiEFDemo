## 建立範例 Web API 專案

以下我們用 .NET 7 為範例：

1. 建立 `api1` 專案

    ```sh
    dotnet new webapi -n AspNetCoreWebApiEFDemo && cd AspNetCoreWebApiEFDemo
    ```

2. 加入 `.gitignore` 檔案

    ```sh
    dotnet new gitignore
    ```

3. 將專案加入 Git 版控

    ```sh
    git init && git add . && git commit -m "Initial commit"
    ```

4. 在資料庫中建立 [ContosoUniversity](https://gist.githubusercontent.com/doggy8088/2a2f7075d49b3814d19513426ede3549/raw/ab95b323425ff98e99b901793d0361d90439fb0b/ContosoUniversity.sql) 範例資料庫

    建議使用 SQL Server Express LocalDB 即可：`(localdb)\MSSQLLocalDB`

5. 安裝 `dotnet-ef` 全域工具 (.NET CLI Global Tool)

    ```sh
    dotnet tool update -g dotnet-ef
    ```

6. 安裝 Entity Framework Core 相關套件

    ```sh
    dotnet add package Microsoft.EntityFrameworkCore.SqlServer
    dotnet add package Microsoft.EntityFrameworkCore.Tools
    ```

    建立新版本

    ```sh
    git add . && git commit -m "Add EFCore NuGet packages"
    ```

7. 透過 `dotnet-ef` 快速建立 EFCore 模型類別與資料內容類別

    ```sh
    dotnet ef dbcontext scaffold "Server=(localdb)\MSSQLLocalDB;Database=ContosoUniversity;Trusted_Connection=True;MultipleActiveResultSets=true" Microsoft.EntityFrameworkCore.SqlServer -o Models
    dotnet build
    ```

    在透過 `dotnet ef` 產生程式碼之後，必須先建置專案，雖然建置會成功，但是卻會看到**警告訊息**如下：

    ![warning CS1030: #warning: 'To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.'](https://user-images.githubusercontent.com/88981/92549573-29de5000-f28c-11ea-82cb-d064b0503bbc.jpg)

    ```txt
    Models\ContosoUniversityContext.cs(32,10): warning CS1030: #warning: 'To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.' [G:\Projects\api1\api1.csproj]
    ```

    這個警告訊息主要是跟你說，在透過 `dotnet-ef` 工具產生程式碼的時候，會順便將「連接字串」一定產生在 `ContosoUniversityContext.cs` 原始碼中，建議你手動將這段程式碼移除。

    ![To protect potentially sensitive information in your connection string, you should move it out of source code.](https://user-images.githubusercontent.com/88981/232923126-e797df55-5a48-4006-9951-d6a8192d28df.png)

    上圖修改完後的程式碼如下：

    ```cs
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {}
    ```

    建立新版本

    ```sh
    git add . && git commit -m "Create EFCore models and dbcontext classes using dotnet-ef"
    ```

8. 調整 ASP․NET Core 的 `Program.cs` 並對 `ContosoUniversityContext` 設定 DI

    ```cs
    using AspNetCoreWebApiEFDemo.Models;
    using Microsoft.EntityFrameworkCore;

    var builder = WebApplication.CreateBuilder(args);

    // 加入這段程式碼
    builder.Services.AddDbContext<ContosoUniversityContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
    ```

9. 調整 ASP․NET Core 的 `appsettings.Development.json` 加入 `DefaultConnection` 連接字串

    ```json
    {
      "ConnectionStrings": {
          "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Initial Catalog=ContosoUniversity;Integrated Security=True"
      },
      "Logging": {
        "LogLevel": {
          "Default": "Information",
          "Microsoft.AspNetCore": "Warning"
        }
      }
    }
    ```

    建立新版本

    ```sh
    git add . && git commit -m "Add DI for ContosoUniversityContext and ConnectionStrings"
    ```

10. 建置專案，確認可以正常編譯！

    ```sh
    dotnet build
    ```

11. 建立方案檔

    ```sh
    dotnet new sln
    dotnet sln add AspNetCoreWebApiEFDemo.csproj
    ```

    建立新版本

    ```sh
    git add . && git commit -m "Add Solution File for Visual Studio 2022"
    ```
