using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Client.Data;
using MVC.Client.Infrastructure;
using MVC.Client.Models;
using MVC.Client.SyncDataClient;
using MVC.Client.ViewModels;

namespace MVC.Client.Controllers
{
    //[Authorize]
    public class ProductsController : Controller
    {
        private readonly MVCDbContext _context;
        private readonly IDataClient dataClient;
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration configuration;
        private static ProductViewModel productViewModel;


        public ProductsController(MVCDbContext context,
            IDataClient dataClient, ILogger<HomeController> logger, IConfiguration configuration)
        {
            _context = context;
            this.dataClient = dataClient;
            _logger = logger;
            this.configuration = configuration;

            productViewModel = new ProductViewModel();
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            
            var user = User;

            var userId = User?.FindFirst("sub");

            var products = await dataClient.GetCatalog();
            LocalSession.Products = products;

            productViewModel.Products = products;
            
            return View(productViewModel);
        }

        public async Task<JsonResult> AddToCart(CartItem item)
        {
            var cart = await dataClient.AddToBasket("1234", item);
            var totalCost = 0m;
            foreach(var product in LocalSession.Products)
            {
                if(cart.Items.Any(x => x.ProductId == product.Id))
                {
                    var cartItem = cart.Items.Where(x => x.ProductId == product.Id).FirstOrDefault();
                    totalCost += cartItem.Quantity * product.UnitPrice;
                }
            }

            var items = new
            {
                totalItem = cart.Items.Sum(x => x.Quantity),
                totalPrice = cart.TotalPrice,
                totalDiscount = totalCost - cart.TotalPrice
            };
            return Json(items);
        }

        public void RemoveFromCart(CartItem item)
        {
            dataClient.RemoveBasket("1234", item);
        }


        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,UnitPrice,OfferPrice,DiscountedPrice")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,UnitPrice,OfferPrice,DiscountedPrice")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'MVCDbContext.Products'  is null.");
            }
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
          return _context.Products.Any(e => e.Id == id);
        }
    }
}
