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
        public SelectList Products { get; set; }

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

        #region Mantenimiento a Productos

        public async Task<IActionResult> ProductList(string m)
        {
            dynamic products = await maintenanceService.GetAllProducts();

            foreach (var cus in products.Data)
            {
                int encrytedId = cus["Product_ID"];
                cus["Product_ID"] = protector.Protect(Convert.ToString(encrytedId));
            }

            ViewData["Products"] = products;

            if (!string.IsNullOrEmpty(m))
                ViewBag.Message = m;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductViewModel model, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var productExist = await context.Products.FirstOrDefaultAsync(x => x.CodeProduct == model.CodeProduct.Trim(), cancellationToken);
                if (productExist == null)
                {
                    decimal salePrice = (model.UnitPrice * (model.PorcentajeGanancia / 100)) + model.UnitPrice;
                    var entity = new Product
                    {
                        CodeProduct = model.CodeProduct.Trim(),
                        ProductName = model.ProductName.Trim(),
                        UnitsInStock = model.UnitsInStock,
                        UnitPrice = model.UnitPrice,
                        SalePrice = salePrice,
                        Discontinued = model.Discontinued
                    };
                    context.Products.Add(entity);
                    await context.SaveChangesAsync(cancellationToken);
                    string m = "well";
                    return RedirectToAction("ProductList", new { m });
                }
                else
                {
                    string m = "bad";
                    return RedirectToAction("ProductList", new { m });
                }
            }
            return null;
        }

        public async Task<IActionResult> EditProduct(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                string decryptedId = protector.Unprotect(id);
                var product = await context.Products.FirstOrDefaultAsync(x => x.Product_ID == Convert.ToInt32(decryptedId));

                var model = new ProductViewModel
                {
                    Product_ID = Convert.ToInt32(decryptedId),
                    CodeProduct = product.CodeProduct.Trim(),
                    ProductName = product.ProductName.Trim(),
                    UnitsInStock = product.UnitsInStock,
                    UnitPrice = product.UnitPrice,
                    SalePrice = product.SalePrice,
                    Discontinued = product.Discontinued
                };

                return View(model);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(ProductViewModel model, CancellationToken cancellationToken)
        {
            var product = await context.Products.FirstOrDefaultAsync(x => x.Product_ID == model.Product_ID, cancellationToken);
            if (product != null)
            {
                product.CodeProduct = model.CodeProduct.Trim();
                product.ProductName = model.ProductName.Trim();
                product.UnitsInStock = model.UnitsInStock;
                product.UnitPrice = model.UnitPrice;
                product.SalePrice = model.SalePrice;
                product.Discontinued = model.Discontinued;

                context.Products.Update(product);
                await context.SaveChangesAsync(cancellationToken);

                string m = "update";
                return RedirectToAction("ProductList", new { m });
            }
            else
            {
                string m = "bad";
                return RedirectToAction("ProductList", new { m });
            }
        }

        public async Task<IActionResult> DeleteProduct(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                string decryptedId = protector.Unprotect(id);
                var product = await context.Products.FirstOrDefaultAsync(x => x.Product_ID == Convert.ToInt32(decryptedId));
                var model = new ProductViewModel
                {
                    Product_ID = Convert.ToInt32(decryptedId),
                    CodeProduct = product.CodeProduct.Trim(),
                    ProductName = product.ProductName.Trim()
                };
                return View(model);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(ProductViewModel model, CancellationToken cancellationToken)
        {
            var product = await context.Products.FirstOrDefaultAsync(x => x.Product_ID == model.Product_ID, cancellationToken);
            if (product != null)
            {
                context.Products.Remove(product);
                await context.SaveChangesAsync(cancellationToken);
                string m = "delete";
                return RedirectToAction("ProductList", new { m });
            }
            else
            {
                string m = "bad";
                return RedirectToAction("ProductList", new { m });
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

            if (!string.IsNullOrEmpty(m))
                ViewBag.Message = m;

            return View();
        }

        public async Task<IActionResult> CreateInvoice()
        {
            var customers = await context.Customers.Where(x => x.CustomerStatus.CustomerStatusDisplay == "Activo").ToListAsync();
            foreach (var item in customers)
                Customers = new SelectList(customers, nameof(item.Customer_ID), nameof(item.CustomerName));

            ViewData["Customers"] = Customers;

            var products = await context.Products.Where(x => x.Discontinued == false).ToListAsync();
            foreach (var item in products)
                Products = new SelectList(products, nameof(item.Product_ID), nameof(item.ProductName));

            ViewData["Products"] = Products;

            return View();
        }

        public async Task<IActionResult> DetailInvoice(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                string decryptedId = protector.Unprotect(id);
                var invoice = await context.InvoiceDetails.Include(x => x.Invoices).Include(x => x.Customers).Include(x => x.Products).Where(x => x.Invoice_ID == Convert.ToInt32(decryptedId)).ToListAsync();
                foreach (var item in invoice)
                {
                    ViewData["Customer"] = item.Customers;
                    ViewData["Invoices"] = item.Invoices;
                }

                decimal itbis = 0;
                decimal subTotal = 0;
                decimal total = 0;
                // Primero debo sumar los totales de la lista 
                foreach (var item in invoice)
                {
                    if (item.Customer_ID != 0)
                    {
                        itbis += item.TotalItbis;
                        subTotal += item.SubTotal;
                        total += item.Total;
                    }
                }
                ViewBag.SubTotal = subTotal;
                ViewBag.TotalItbis = itbis;
                ViewBag.Total = total;

                ViewData["InvoiceDetails"] = invoice;
            }
            return View();
        }
        #endregion

        #region Helpers

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<JsonResult> LoadCustomerDetail(int Id, CancellationToken cancellationToken)
        {
            var result = await context.Customers.Where(s => s.Customer_ID == Id).ToListAsync(cancellationToken);
            return Json(result);
        }

        public async Task<JsonResult> LoadProductDetail(int Id, CancellationToken cancellationToken)
        {
            var result = await context.Products.Where(s => s.Product_ID == Id).ToListAsync(cancellationToken);
            return Json(result);
        }

        public async Task<InvoiceViewModel> AddProductDetail(int productId, int customerId, int qty, CancellationToken cancellationToken)
        {
            var product = await context.Products.FirstOrDefaultAsync(x => x.Product_ID == productId, cancellationToken);

            var model = new InvoiceViewModel();
            
            decimal subTotal = 0;
            decimal totalItbis = 0;
            decimal total = 0;

            if (product != null) 
            {
                totalItbis = (product.SalePrice * (decimal)0.18) * qty;
                subTotal = (totalItbis + product.SalePrice);
                total = subTotal * qty;

                model.Product_ID = productId;
                model.CodeProduct = product.CodeProduct;
                model.ProductName = product.ProductName;
                model.Customer_ID = customerId;
                model.Qty = qty;
                model.Price = product.SalePrice;
                model.Total = total;
                model.SubTotal = subTotal;
                model.TotalItbis = totalItbis;
            }

            return model;
        }

        [HttpPost]
        public async Task<JsonResult> CreateInvoice(InvoiceViewModel model, CancellationToken cancellationToken)
        {
            string m = string.Empty;

            decimal itbis = 0;
            decimal subTotal = 0;
            decimal total = 0;
            // Primero debo sumar los totales de la lista 
            foreach (var item in model.InvoiceDetails)
            {
                if (item.Customer_ID != 0)
                {
                    itbis += item.TotalItbis;
                    subTotal += item.SubTotal;
                    total += item.Total;
                }
            }

            var invoice = new Invoice
            {
                Customer_ID = model.Customer_ID,
                TotalItbis = itbis,
                SubTotal = subTotal,
                Total = total
            };

            await context.Invoices.AddAsync(invoice, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            int id = invoice.Invoice_ID;

            // Guardo la lista en InvoiceDetail
            if (id != 0)
            {
                foreach (var detail in model.InvoiceDetails)
                {
                    if (detail.Customer_ID != 0)
                    {
                        var invoiceDetail = new InvoiceDetail
                        {
                            Qty = detail.Qty,
                            Price = detail.Price,
                            TotalItbis = detail.TotalItbis,
                            SubTotal = detail.SubTotal,
                            Total = detail.Total,
                            Customer_ID = detail.Customer_ID,
                            Product_ID = detail.Product_ID,
                            Invoice_ID = id
                        };

                        await context.InvoiceDetails.AddAsync(invoiceDetail, cancellationToken);
                        await context.SaveChangesAsync(cancellationToken);

                        // Actualizar el inventario
                        var product = await context.Products.FirstOrDefaultAsync(x => x.Product_ID == detail.Product_ID, cancellationToken);
                        if (product != null)
                        {
                            product.UnitsInStock = (short)(product.UnitsInStock - detail.Qty);
                            context.Products.Update(product);
                            context.SaveChanges();
                        }
                    }
                }
                m = "well";
            }
            else
                m = "bad";
            
            return Json(m);
        }

        #endregion
    }
}