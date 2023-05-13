using Test_Invoice.Data;
using Test_Invoice.Structs;

namespace Test_Invoice.Services;

public interface IMaintenanceService
{
    Task<Return> GetAllCustomers();
    Task<Return> GetAllCustomerTypes();
    Task<Return> GetAllCustomerStatus();
}

public class MaintenanceService : IMaintenanceService
{
    public readonly ApplicationDbContext context;

    public MaintenanceService(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task<Return> GetAllCustomers()
    {
        var sql = new Sql(this.context);
        var file = "GetAllCustomers";
        var query = File.ReadAllText($"Data/Customer/{file}.sql");
        var entityData = await sql.OneQuery(query);

        return new Return($"File '{file}' data").SetData(entityData);
    }

    public async Task<Return> GetAllCustomerStatus()
    {
        var sql = new Sql(this.context);
        var file = "GetAllCustomerStatus";
        var query = File.ReadAllText($"Data/CustomerStatus/{file}.sql");
        var entityData = await sql.OneQuery(query);

        return new Return($"File '{file}' data").SetData(entityData);
    }

    public async Task<Return> GetAllCustomerTypes()
    {
        var sql = new Sql(this.context);
        var file = "GetAllCustomerTypes";
        var query = File.ReadAllText($"Data/CustomerType/{file}.sql");
        var entityData = await sql.OneQuery(query);

        return new Return($"File '{file}' data").SetData(entityData);
    }
}
