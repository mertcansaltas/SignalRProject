using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Interfaces;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.BasketDto;
using SignalR.EntityLayer.Entities;
using SignalRApi.Models;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService basketService;

        public BasketController(IBasketService basketService)
        {
            this.basketService = basketService;
        }
        [HttpGet]
        public IActionResult GetBasketByMenuTableID(int id)
        {
            var values=basketService.TGetBasketByTableNumber(id);   
            return Ok(values);
        }
        [HttpGet("BasketListByMenuTableWithProductName")]
        public IActionResult BasketListByMenuTableWithProductName(int id)
        {
            using var context = new SignalRContext();
            var values = context.Baskets.Include(x => x.Product).Where(y => y.MenuTableID == id).Select(z => new ResultBasketListWithProducts
            {
                BasketID=z.BasketID,
                Count=z.Count,
                MenuTableID=z.MenuTableID,
                Price=z.Price,
                ProducTID=z.ProducTID,
                TotalPrice=z.TotalPrice,
                ProductName=z.Product.ProductName
            }).ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateBasket(CreateBasketDto createBasketDto)
        {
            using var context = new SignalRContext();
            basketService.TAdd(new Basket() {
                ProducTID = createBasketDto.ProducTID,
                Count =1,
                MenuTableID=3,
                Price=context.Products.Find(createBasketDto.ProducTID).Price,
                TotalPrice=0,
                
            });
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBasket(int id)
        {
            var value = basketService.TGetByID(id);
            basketService.TDelete(value);
            return Ok("Sepet kısmı silindi");
        }
    }
}
