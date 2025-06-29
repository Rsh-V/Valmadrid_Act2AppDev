using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SpendingTracker.Models;
using Valmadrid_Act2AppDev.Models;

namespace Valmadrid_Act2AppDev.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ExpensesDBContext _context;

        public HomeController(ILogger<HomeController> logger, ExpensesDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Expenses()
        {
            var allExpenses = _context.Expenses.ToList();
            return View(allExpenses);
        }
        public IActionResult CreateExpense()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateExpenseForm(Expense model)
        {
            if (!ModelState.IsValid)
                return View("CreateExpense", model);

            _context.Expenses.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Expenses");
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
