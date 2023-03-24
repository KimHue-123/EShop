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
        Task<int> UpdatePrice(int productId, decimal newPrice, decimal newOriginalPrice);
        Task<int> UpdateStock(int productId, int newStock);
        Task<int> Update(ProductUpdateRequest request);
        Task<int> Delete(int productId);
        Task AddViewCount(int productId);
        Task<PageResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request);
    }
}
