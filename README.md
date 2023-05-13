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

### Cambiar la cadena de conexión en el archivo 'appsettings.json' por la de su servidor
	"Data Source="SERVER",1433;Initial Catalog=Test_Invoice; Integrated Security=False;User ID=USUARIO;Password=CONTRASEÑA;Connection Timeout=120;MultipleActiveResultSets=true;TrustServerCertificate=True;"

### Correr los siguientes comandos en el 'Package Manager Console'
	Update-Database
