# Test_Invoice
Prueba de programación Schad

## Librerias
	Microsoft.EntityFrameworkCore					6.0.16
	Microsoft.EntityFrameworkCore.SqlServer			6.0.16
	Microsoft.EntityFrameworkCore.Tools				6.0.16
	Microsoft.Data.SqlClient						5.1.1


## Cambiar la cadena de conexión en el archivo 'appsettings.json'
	"Data Source="SERVER",1433;Initial Catalog=Test_Invoice; Integrated Security=False;User ID=USUARIO;Password=CONTRASEÑA;Connection Timeout=120;MultipleActiveResultSets=true;"

## Correr los siguientes comandos en el 'Package Manager Console'
	Add-Migration InitialMigration
	Update-Database
