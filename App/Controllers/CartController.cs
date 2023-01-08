using hometask_17.DAL.Models;
using hometask_17.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace hometask_17.Controllers
{
    public class CartController : Controller
    {
        public const string COOKIES_CART = "Cart";
        private readonly PurpleBuzzDbContext? _context;
        public CartController(PurpleBuzzDbContext? context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<CartVM> carts = CheckCookiesCart();
            List<CartItemVM> cartItems = new();
            carts.ForEach(cart =>
            {
                var workProducts = _context.WorkProducts
                    .Where(wp => wp.Id == cart.WorkProductId)
                    .Include(i => i.Images)
                    .Include(c => c.Category)
                    .FirstOrDefault();
                CartItemVM cartItem = new()
                {
                    Id = workProducts.Id,
                    Name = workProducts.Name,
                    MainImage = workProducts.Images.Where(i => i.isMain).FirstOrDefault().Path,
                    CategoryName = workProducts.Category.Name,
                    Count = cart.Count,
                    isDeleted = workProducts.isDeleted,
                    Price = 100
                };
                cartItems.Add(cartItem);
            });
            return View(cartItems);
        }

        public bool AddToCart(int id, int count)
        {
            bool CheckExistenceProduct = _context.WorkProducts.Any(p => p.Id == id && !p.isDeleted);
            if (!CheckExistenceProduct)
                return false;

            if (count == 0)
                return false;

            List<CartVM> carts = CheckCookiesCart();

            AddToCookiesCart(id, count, carts, CheckProductExistenceInCart(id, count,carts));

            return true;
        }
        public bool Edit(int id, int count)
        {
            bool CheckExistenceProduct = _context.WorkProducts.Any(p => p.Id == id && !p.isDeleted);
            if (!CheckExistenceProduct)
                return false;

            if (count == 0)
                return false;

            List<CartVM> carts = CheckCookiesCart();

            bool ProductExists = false;
            foreach (var cart in carts)
            {
                if (cart.WorkProductId == id)
                {
                    cart.Count = count;
                    ProductExists=true;
                    break;
                }
            }

            AddToCookiesCart(id, count, carts, ProductExists);

            return true;
        }

        private bool CheckProductExistenceInCart(int id, int count, List<CartVM> carts)
        {
            foreach (var cart in carts)
            {
                if (cart.WorkProductId == id)
                {
                    cart.Count += count;
                    return true;
                }
            }
            return false;
        }
        private List<CartVM> CheckCookiesCart()
        {
            List<CartVM> carts;

            if (Request.Cookies[COOKIES_CART] != null)
                carts = JsonSerializer.Deserialize<List<CartVM>>(Request.Cookies[COOKIES_CART]);
            else
                carts = new List<CartVM>();

            return carts;
        }
        private void AddToCookiesCart(int id, int count, List<CartVM> cart, bool existenceProduct)
        {
            if (!existenceProduct)
                cart.Add(new CartVM { WorkProductId = id, Count = count });
            string cookiesCart = JsonSerializer.Serialize(cart);
            Response.Cookies.Append(COOKIES_CART, cookiesCart);
        }

    }
}
