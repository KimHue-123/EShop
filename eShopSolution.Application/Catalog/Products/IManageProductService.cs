using eShopSolution.ViewModels.Catalog.ProductImages;
using eShopSolution.ViewModels.Catalog.Products;
using eShopSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Products
{
    public interface IManageProductService
    {
        Task<int> Create(ProductCreateRequest request);
        Task<int> UpdatePrice(int productId, decimal? newPrice, decimal? newOriginalPrice);
        Task<int> UpdateStock(int productId, int newStock);
        Task<int> Update(ProductUpdateRequest request);
        Task<int> Delete(int productId);
        Task AddViewCount(int productId);
        Task<PageResult<ProductViewModel>> GetAllPaging(string languageId, GetManageProductPagingRequest request);
        Task<List<ProductViewModel>> GetAll();
        Task<ProductViewModel> GetProductById(int productId, string languageId);

        Task<int> AddImage(int productId, ProductImageCreateRequest request);
        Task<int> UpdateImage(int imageId, ProductImageUpdateRequest request);
        Task<int> RemoveImage(int imageId);
        Task<ProductImageViewModel> GetImageById(int imageId);
        Task<List<ProductImageViewModel>> GetListImage(int productId);
    }
}
