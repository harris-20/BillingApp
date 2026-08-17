using BillingApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace BillingApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly InvoiceDbContext _context;

        public HomeController(ILogger<HomeController> logger, InvoiceDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Invoice()
        {
            var allExpences= _context.Invoice.ToList();

            // Subtotal before tax
            var subtotal = allExpences.Sum(expense => expense.Price);

            // Ontario tax = 14%
            var ontarioTax = subtotal * 0.14m;

            // Total including tax
            var total = subtotal + ontarioTax;

            ViewBag.Subtotal = subtotal;
            ViewBag.OntarioTax = ontarioTax;
            ViewBag.Total = total;

            return View(allExpences);
        }

        public IActionResult InvoiceReport()
        {
            var allExpenses = _context.Invoice.ToList();

            return View(allExpenses);
        }

        public IActionResult CreateEditProduct(int? id)
        {
            if (id.HasValue)
            {
                var productInDb = _context.Invoice.SingleOrDefault(expence => expence.Id == id);
                return View(productInDb);

            }

            return View();
        }

        public IActionResult DeleteProduct(int id)
        {
            var productInDb = _context.Invoice.SingleOrDefault(expence => expence.Id ==id);
            _context.Invoice.Remove(productInDb);
            _context.SaveChanges();
            return RedirectToAction("Invoice");
        }

        public IActionResult CreateEditProductForm(Invoice model)
        {
            if(model.Id == 0)
            {
                _context.Invoice.Add(model);
            }
            else
            {
                _context.Invoice.Update(model);
            }

            _context.SaveChanges();

            return RedirectToAction("Invoice");
        }

        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
