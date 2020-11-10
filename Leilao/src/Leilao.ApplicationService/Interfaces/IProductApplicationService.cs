using Leilao.ApplicationService.ViewModels.Request.Product;
using Leilao.ApplicationService.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Leilao.ApplicationService.Interfaces {

    public interface IProductApplicationService {

        Task<List<ProductResponseViewModel>> GetAllProducts();
        Task<ProductResponseViewModel> GetProductById(Guid id);
        Task<ProductResponseViewModel> CreateProduct(CreatePrductRequestViewModel viewModel);

    }
}
