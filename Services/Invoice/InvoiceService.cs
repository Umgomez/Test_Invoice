using Test_Invoice.Data;
using Test_Invoice.Structs;

namespace Test_Invoice.Services;

public interface IInvoiceService
{
    Task<Return> GetAllInvoices(int? customerId);
    Task<Return> GetAllInvoiceDetails(int? customerId);
}

public class InvoiceService : IInvoiceService
{
    public readonly ApplicationDbContext context;

    public InvoiceService(ApplicationDbContext context)
    {
        this.context = context;
    }


    public async Task<Return> GetAllInvoices(int? customerId)
    {
        var sql = new Sql(this.context);
        var file = "GetAllInvoices";
        var query = File.ReadAllText($"Data/Invoice/{file}.sql");
        var data = new Dictionary<string, object> { { "CustomerID", customerId } };
        query = await sql.QueryFormat(query, data);
        var entityData = await sql.OneQuery(query);

        return new Return($"File '{file}' data").SetData(entityData);
    }

    public async Task<Return> GetAllInvoiceDetails(int? customerId)
    {
        var sql = new Sql(this.context);
        var file = "GetAllInvoiceDetails";
        var query = File.ReadAllText($"Data/InvoiceDetail/{file}.sql");
        var data = new Dictionary<string, object> { { "CustomerID", customerId } };
        query = await sql.QueryFormat(query, data);
        var entityData = await sql.OneQuery(query);

        return new Return($"File '{file}' data").SetData(entityData);
    }
}
