using eShopSolution.Application.Catalog.Products;
using eShopSolution.ViewModels.Catalog.ProductImages;
using eShopSolution.ViewModels.Catalog.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShopSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IManageProductService _productService;
        public ProductsController(IManageProductService manageProductService)
        {
            _productService = manageProductService;
        }

        //[HttpGet]
        //public async Task<IActionResult> getAll()
        //{
        //    var result = await _productService.GetAll();
        //    return Ok(result);
        //}

        [Route("filter")]
        [HttpGet]
        public async Task<IActionResult> Filter(string languageId, [FromQuery]GetManageProductPagingRequest request)
        {
            var products = await _productService.GetAllPaging(languageId, request);
            return Ok(products);
        }

        [HttpGet("{productId}/{languageId}")]
        public async Task<IActionResult> GetById(int productId, string languageId)
        {
            var product =await _productService.GetProductById(productId, languageId);
            if (product == null)
                return BadRequest("Can't not find product");
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var productId = await _productService.Create(request);
            if (productId == 0)
                return BadRequest();
            var product = await _productService.GetProductById(productId, request.LanguageId);
            
            
            return CreatedAtAction(nameof(GetById),new { id = productId }, product);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] ProductUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _productService.Update(request);
            if(result > 0)
                return Ok();
            return BadRequest();
        }

        // Phải được khai báo ở trên này, đúng theo tên tham số truyền vào (productId)
        [HttpDelete("productId")]
        public async Task<IActionResult> Delete([FromQuery] int productId)
        {
            var result = await _productService.Delete(productId);
            if (result > 0)
                return Ok();
            return BadRequest();
        }

        [HttpPatch("UpdatePrice")]
        public async Task<IActionResult> UpdatePrice(int productId, decimal? newPrice, decimal? newOriginalPrice)
        {
            var result = await _productService.UpdatePrice(productId, newPrice, newOriginalPrice);
            if (result > 0)
                return Ok();
            return BadRequest();
        }

        [HttpPatch("UpdateStock")]
        public async Task<IActionResult> UpdateStock(int productId, int newStock)
        {
            var result = await _productService.UpdateStock(productId, newStock);
            if (result > 0)
                return Ok();
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetImageById(int imageId)
        {
            var image = await _productService.GetImageById(imageId);
            return Ok(image);
        }

        [HttpPost("{productId}/image")]
        public async Task<IActionResult> CreateImage(int productId, [FromForm] ProductImageCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var imageId = await _productService.AddImage(productId, request);
            if (imageId == 0)
                return BadRequest();
            var image = await _productService.GetImageById(imageId);
            return CreatedAtAction(nameof(GetImageById), new { id = imageId }, image);
        }

        [HttpPut("UpdateImage")]
        public async Task<IActionResult> UpdateImage(int imageId, [FromForm] ProductImageUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _productService.UpdateImage(imageId, request);
            if (result > 0)
                return Ok();
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveImage(int imageId)
        {
            var result = await _productService.RemoveImage(imageId);
            if (result > 0)
                return Ok();
            return BadRequest();
        }
    }
}
