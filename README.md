# Test_Invoice
Prueba de programación Schad

Esta fue realizada en Visual Studio 2022 y se ustilizó la plantilla ASP.NET Core MVC. 
Puede descargar el SDK aquí ---> https://dotnet.microsoft.com/es-es/download/dotnet/6.0

### Librerias Utilizadas
	Microsoft.EntityFrameworkCore				6.0.16
	Microsoft.EntityFrameworkCore.SqlServer			6.0.16
	Microsoft.EntityFrameworkCore.Tools			6.0.16
	Microsoft.Data.SqlClient				5.1.1

Se estará implementando Entity Framework Core 6. Para ejecutar la migración siga los siguientes pasos:

### 1. Cambiar la cadena de conexión en el archivo 'appsettings.json' por la de su servidor
	"Data Source={SERVER},1433;Initial Catalog={DATABASE}; Integrated Security=False;User ID={USER};Password={PASSWORD};Connection Timeout=120;MultipleActiveResultSets=true;TrustServerCertificate=True;"
	
## 2 Migración Entity Framework Core
### 2.1 Correr los siguientes comandos en el 'Package Manager Console'
	Update-Database

### 2.2 (Si no se tiene Visual Studio) Correr los siguientes comandos en el 'Powershell'
Hay que instalar una unica vez la herramienta Entity Framework Core globalmente, y el paquete `Microsoft.EntityFrameworkCore.Design` debe estar previamente instalado en el proyecto.
```sh
$ dotnet tool install --global dotnet-ef
$ dotnet tool update --global dotnet-ef
```

```sh
$ dotnet ef database update
```

### 2.3 (En caso de que no se pueda correr las migraciones por la herramienta) Correr el siguiente [script](./Data/Script_Test_Invoice.sql) en la base de datos