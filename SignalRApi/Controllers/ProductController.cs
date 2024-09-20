using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Interfaces;
using SignalR.DtoLayer.ProductDto;
using SignalRApi.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService ProductService, IMapper mapper)
        {
            _productService = ProductService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var value = _mapper.Map<List<ResultProductDto>>(_productService.TGetAllList());
            return Ok(value);
        }

		[HttpGet("ProductCount")]
		public IActionResult ProductCount()
		{
			return Ok(_productService.TProductCount());
		}

		[HttpGet("ProductCountByDrink")]
		public IActionResult ProductCountByDrink()
		{
			return Ok(_productService.TProductCountByCategoryNameDrink());
		}

		[HttpGet("ProductCountByHamburger")]
		public IActionResult ProductCountByHamburger()
		{
			return Ok(_productService.TProductCountByCategoryNameHamburger());
		}

		[HttpGet("ProductPriceAvg")]
		public IActionResult ProductPriceAvg()
		{
			return Ok(_productService.TProductPriceAvg());
		}

		[HttpGet("ProductNameMinPrice")]
		public IActionResult ProductNameMinPrice()
		{
			return Ok(_productService.TProductNameMinPrice());
		}

		[HttpGet("ProductNameMaxPrice")]
		public IActionResult ProductNameMaxPrice()
		{
			return Ok(_productService.TProductNameMaxPrice());
		}

		[HttpGet("ProductPriceAvgByHamburger")]
		public IActionResult ProductPriceAvgByHamburger()
		{
			return Ok(_productService.TProductPriceAvgByHamburger());
		}

		[HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var product = _productService.TGetProductsWithCategories();
            var values = _mapper.Map<List<ResultProductWithCategoryDto>>(product);
            return Ok(values);
        }


        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            Product Product = _mapper.Map<Product>(createProductDto);
            _productService.TAdd(Product);
            return Ok("Product eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var values = _productService.TGetByID(id);
            _productService.TDelete(values);
            return Ok("Product silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var values = _productService.TGetByID(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            Product Product = _mapper.Map<Product>(updateProductDto);
            _productService.TUpdate(Product);
            return Ok("Product güncellendi");
        }
    }
}
