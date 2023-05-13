using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Threading;
using Test_Invoice.Data;
using Test_Invoice.Helpers;
using Test_Invoice.Models;
using Test_Invoice.Models.ViewModel;
using Test_Invoice.Services;

namespace Test_Invoice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMaintenanceService maintenanceService;
        private readonly IInvoiceService invoiceService;
        private readonly IDataProtector protector;

        public SelectList Customers { get; set; }
        public SelectList CustomerStatus { get; set; }
        public SelectList CustomerTypes { get; set; }

        public HomeController(ApplicationDbContext context, 
            IMaintenanceService maintenanceService,
            IInvoiceService invoiceService,
            IDataProtectionProvider dataProtectionProvider,
            DataProtectionPurposeStrings dataProtectionPurposeStrings)
        {
            this.context = context;
            this.maintenanceService = maintenanceService;
            this.invoiceService = invoiceService;
            protector = dataProtectionProvider.CreateProtector(dataProtectionPurposeStrings.ProtectedIdRouteValue);
        }

        #region Mantenimiento a Clientes

        public async Task<IActionResult> CustomerList(string m)
        {
            dynamic customers = await maintenanceService.GetAllCustomers();

            foreach (var cus in customers.Data)
            {
                int encrytedId = cus["Customer_ID"];
                cus["Customer_ID"] = protector.Protect(Convert.ToString(encrytedId));
            }

            ViewData["Customers"] = customers;

            var customerStatus = await context.CustomerStatus.OrderBy(x => x.Order).ToListAsync();
            foreach (var item in customerStatus)
                CustomerStatus = new SelectList(customerStatus, nameof(item.CustomerStatus_ID), nameof(item.CustomerStatusDisplay));

            var customerTypes = await context.CustomerTypes.OrderBy(x => x.Order).ToListAsync();
            foreach (var item in customerTypes)
                CustomerTypes = new SelectList(customerTypes, nameof(item.CustomerType_ID), nameof(item.CustomerTypeDisplay));
            
            ViewBag.CustomerStatus = CustomerStatus;
            ViewBag.CustomerTypes = CustomerTypes;

            if (!string.IsNullOrEmpty(m))
                ViewBag.Message = m;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CustomerViewModel model, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var customerExist = await context.Customers.FirstOrDefaultAsync(x => x.CustomerName == model.CustomerName.Trim(), cancellationToken);
                if (customerExist == null)
                {
                    var entity = new Customer
                    {
                        CustomerName = model.CustomerName.Trim(),
                        Address = model.Address.Trim(),
                        CustomerType_ID = model.CustomerType_ID,
                        CustomerStatus_ID = model.CustomerStatus_ID
                    };
                    context.Customers.Add(entity);
                    await context.SaveChangesAsync(cancellationToken);
                    string m = "well";
                    return RedirectToAction("CustomerList", new { m });
                }
                else
                {
                    string m = "bad";
                    return RedirectToAction("CustomerList", new { m });
                }
            }
            return null;
        }

        public async Task<IActionResult> EditCustomer(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                string decryptedId = protector.Unprotect(id);
                var customer = await context.Customers.FirstOrDefaultAsync(x => x.Customer_ID == Convert.ToInt32(decryptedId));
                var model = new CustomerViewModel
                {
                    Customer_ID = Convert.ToInt32(decryptedId),
                    CustomerName = customer.CustomerName.Trim(),
                    Address = customer.Address.Trim(),
                    CustomerStatus_ID = customer.CustomerStatus_ID,
                    CustomerType_ID = customer.CustomerType_ID
                };

                var customerStatus = await context.CustomerStatus.OrderBy(x => x.Order).ToListAsync();
                foreach (var item in customerStatus)
                    CustomerStatus = new SelectList(customerStatus, nameof(item.CustomerStatus_ID), nameof(item.CustomerStatusDisplay));

                var customerTypes = await context.CustomerTypes.OrderBy(x => x.Order).ToListAsync();
                foreach (var item in customerTypes)
                    CustomerTypes = new SelectList(customerTypes, nameof(item.CustomerType_ID), nameof(item.CustomerTypeDisplay));

                ViewBag.CustomerStatus = CustomerStatus;
                ViewBag.CustomerTypes = CustomerTypes;

                return View(model);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditCustomer(CustomerViewModel model, CancellationToken cancellationToken)
        {
            var customer = await context.Customers.FirstOrDefaultAsync(x => x.Customer_ID == model.Customer_ID, cancellationToken);
            if (customer != null)
            {
                customer.CustomerName = model.CustomerName.Trim();
                customer.Address = model.Address.Trim();
                customer.CustomerStatus_ID = model.CustomerStatus_ID;
                customer.CustomerType_ID = model.CustomerType_ID;
                context.Customers.Update(customer);
                await context.SaveChangesAsync(cancellationToken);

                string m = "update";
                return RedirectToAction("CustomerList", new { m });
            }
            else
            {
                string m = "bad";
                return RedirectToAction("CustomerList", new { m });
            }
        }

        public async Task<IActionResult> DeleteCustomer(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                string decryptedId = protector.Unprotect(id);
                var customer = await context.Customers.FirstOrDefaultAsync(x => x.Customer_ID == Convert.ToInt32(decryptedId));
                var model = new CustomerViewModel
                {
                    Customer_ID = Convert.ToInt32(decryptedId),
                    CustomerName = customer.CustomerName.Trim(),
                    Address = customer.Address.Trim(),
                    CustomerStatus_ID = customer.CustomerStatus_ID,
                    CustomerType_ID = customer.CustomerType_ID
                };

                string m = "well";
                return View(model);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCustomer(CustomerViewModel model, CancellationToken cancellationToken)
        {
            var customer = await context.Customers.FirstOrDefaultAsync(x => x.Customer_ID == model.Customer_ID, cancellationToken);
            if (customer != null)
            {
                context.Customers.Remove(customer);
                await context.SaveChangesAsync(cancellationToken);
                string m = "delete";
                return RedirectToAction("CustomerList", new { m });
            }
            else
            {
                string m = "bad";
                return RedirectToAction("CustomerList", new { m });
            }
        }

        #endregion

        #region Mantenimiento a Tipos de Clientes

        public async Task<IActionResult> CustomerTypeList(string m)
        {
            dynamic customerTypes = await maintenanceService.GetAllCustomerTypes();

            foreach (var cus in customerTypes.Data)
            {
                int encrytedId = cus["CustomerType_ID"];
                cus["CustomerType_ID"] = protector.Protect(Convert.ToString(encrytedId));
            }

            ViewData["CustomerTypes"] = customerTypes;

            if (!string.IsNullOrEmpty(m))
                ViewBag.Message = m;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomerType(CustomerTypeViewModel model, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var customerExist = await context.CustomerTypes.FirstOrDefaultAsync(x => x.CustomerTypeDisplay == model.CustomerTypeDisplay.Trim(), cancellationToken);
                if (customerExist == null)
                {
                    var entity = new CustomerType
                    {
                        CustomerTypeDisplay = model.CustomerTypeDisplay.Trim(),
                        Order = model.Order
                    };
                    context.CustomerTypes.Add(entity);
                    await context.SaveChangesAsync(cancellationToken);
                    string m = "well";
                    return RedirectToAction("CustomerTypeList", new { m });
                }
                else
                {
                    string m = "bad";
                    return RedirectToAction("CustomerTypeList", new { m });
                }
            }
            return null;
        }

        public async Task<IActionResult> EditCustomerType(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                string decryptedId = protector.Unprotect(id);
                var customerType = await context.CustomerTypes.FirstOrDefaultAsync(x => x.CustomerType_ID == Convert.ToInt32(decryptedId));
                var model = new CustomerTypeViewModel
                {
                    CustomerType_ID = Convert.ToInt32(decryptedId),
                    CustomerTypeDisplay = customerType.CustomerTypeDisplay.Trim(),
                    Order = customerType.Order
                };

                return View(model);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditCustomerType(CustomerTypeViewModel model, CancellationToken cancellationToken)
        {
            var customerType = await context.CustomerTypes.FirstOrDefaultAsync(x => x.CustomerType_ID == model.CustomerType_ID, cancellationToken);
            if (customerType != null)
            {
                customerType.CustomerTypeDisplay = model.CustomerTypeDisplay.Trim();
                customerType.Order = model.Order;
                context.CustomerTypes.Update(customerType);
                await context.SaveChangesAsync(cancellationToken);

                string m = "update";
                return RedirectToAction("CustomerTypeList", new { m });
            }
            else
            {
                string m = "bad";
                return RedirectToAction("CustomerTypeList", new { m });
            }
        }

        public async Task<IActionResult> DeleteCustomerType(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                string decryptedId = protector.Unprotect(id);
                var customerType = await context.CustomerTypes.FirstOrDefaultAsync(x => x.CustomerType_ID == Convert.ToInt32(decryptedId));
                var model = new CustomerTypeViewModel
                {
                    CustomerType_ID = Convert.ToInt32(decryptedId),
                    CustomerTypeDisplay = customerType.CustomerTypeDisplay.Trim(),
                    Order = customerType.Order
                };

                string m = "well";
                return View(model);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCustomerType(CustomerTypeViewModel model, CancellationToken cancellationToken)
        {
            var customerType = await context.CustomerTypes.FirstOrDefaultAsync(x => x.CustomerType_ID == model.CustomerType_ID, cancellationToken);
            if (customerType != null)
            {
                context.CustomerTypes.Remove(customerType);
                await context.SaveChangesAsync(cancellationToken);
                string m = "delete";
                return RedirectToAction("CustomerTypeList", new { m });
            }
            else
            {
                string m = "bad";
                return RedirectToAction("CustomerTypeList", new { m });
            }
        }


        #endregion

        #region Mantenimiento a Estatus

        public async Task<IActionResult> CustomerStatusList(string m)
        {
            dynamic customerStatus = await maintenanceService.GetAllCustomerStatus();

            foreach (var cus in customerStatus.Data)
            {
                int encrytedId = cus["CustomerStatus_ID"];
                cus["CustomerStatus_ID"] = protector.Protect(Convert.ToString(encrytedId));
            }

            ViewData["CustomerStatus"] = customerStatus;

            if (!string.IsNullOrEmpty(m))
                ViewBag.Message = m;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomerStatus(CustomerStatusViewModel model, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var customerExist = await context.CustomerStatus.FirstOrDefaultAsync(x => x.CustomerStatusDisplay == model.CustomerStatusDisplay.Trim(), cancellationToken);
                if (customerExist == null)
                {
                    var entity = new CustomerStatus
                    {
                        CustomerStatusDisplay = model.CustomerStatusDisplay.Trim(),
                        Order = model.Order
                    };
                    context.CustomerStatus.Add(entity);
                    await context.SaveChangesAsync(cancellationToken);
                    string m = "well";
                    return RedirectToAction("CustomerStatusList", new { m });
                }
                else
                {
                    string m = "bad";
                    return RedirectToAction("CustomerStatusList", new { m });
                }
            }
            return null;
        }

        public async Task<IActionResult> EditCustomerStatus(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                string decryptedId = protector.Unprotect(id);
                var customerStatus = await context.CustomerStatus.FirstOrDefaultAsync(x => x.CustomerStatus_ID == Convert.ToInt32(decryptedId));
                var model = new CustomerStatusViewModel
                {
                    CustomerStatus_ID = Convert.ToInt32(decryptedId),
                    CustomerStatusDisplay = customerStatus.CustomerStatusDisplay.Trim(),
                    Order = customerStatus.Order
                };

                return View(model);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditCustomerStatus(CustomerStatusViewModel model, CancellationToken cancellationToken)
        {
            var customerStatus = await context.CustomerStatus.FirstOrDefaultAsync(x => x.CustomerStatus_ID == model.CustomerStatus_ID, cancellationToken);
            if (customerStatus != null)
            {
                customerStatus.CustomerStatusDisplay = model.CustomerStatusDisplay.Trim();
                customerStatus.Order = model.Order;
                context.CustomerStatus.Update(customerStatus);
                await context.SaveChangesAsync(cancellationToken);

                string m = "update";
                return RedirectToAction("CustomerStatusList", new { m });
            }
            else
            {
                string m = "bad";
                return RedirectToAction("CustomerStatusList", new { m });
            }
        }

        public async Task<IActionResult> DeleteCustomerStatus(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                string decryptedId = protector.Unprotect(id);
                var customerStatus = await context.CustomerStatus.FirstOrDefaultAsync(x => x.CustomerStatus_ID == Convert.ToInt32(decryptedId));
                var model = new CustomerStatusViewModel
                {
                    CustomerStatus_ID = Convert.ToInt32(decryptedId),
                    CustomerStatusDisplay = customerStatus.CustomerStatusDisplay.Trim(),
                    Order = customerStatus.Order
                };

                string m = "well";
                return View(model);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCustomerStatus(CustomerStatusViewModel model, CancellationToken cancellationToken)
        {
            var customerStatus = await context.CustomerStatus.FirstOrDefaultAsync(x => x.CustomerStatus_ID == model.CustomerStatus_ID, cancellationToken);
            if (customerStatus != null)
            {
                context.CustomerStatus.Remove(customerStatus);
                await context.SaveChangesAsync(cancellationToken);
                string m = "delete";
                return RedirectToAction("CustomerStatusList", new { m });
            }
            else
            {
                string m = "bad";
                return RedirectToAction("CustomerStatusList", new { m });
            }
        }

        #endregion


        #region Factura

        public async Task<IActionResult> InvoiceList(string m)
        {
            dynamic invoices = await invoiceService.GetAllInvoices(null);

            if (invoices.Data.Count != 0)
            {
                foreach (var cus in invoices.Data)
                {
                    int encrytedId = cus["Invoice_ID"];
                    cus["Invoice_ID"] = protector.Protect(Convert.ToString(encrytedId));
                }
            }

            ViewData["Invoices"] = invoices;

            var customers = await context.Customers.Where(x => x.CustomerStatus.CustomerStatusDisplay == "Activo").ToListAsync();
            foreach (var item in customers)
                Customers = new SelectList(customers, nameof(item.Customer_ID), nameof(item.CustomerName));


            ViewData["Customers"] = Customers;

            if (!string.IsNullOrEmpty(m))
                ViewBag.Message = m;

            return View();
        }

        #endregion





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}