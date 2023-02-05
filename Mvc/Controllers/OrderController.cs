using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace Mvc.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IActionResult> OrderDetails(int orderId)
        {
            var products = await _orderService.GetProductsByOrder(orderId);
            return View(products);
        }
    }
}
