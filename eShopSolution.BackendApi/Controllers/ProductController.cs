using eShopSolution.Application.Catalog.Products;
using eShopSolution.ViewModels.Catalog.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShopSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IManageProductService _productService;
        public ProductController(IManageProductService manageProductService)
        {
            _productService = manageProductService;
        }
        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            var result = await _productService.GetAll();
            return Ok(result);
        }
    }
}
