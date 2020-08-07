using Marketplace.Schemas.Services;
using Marketplace.Schemas.Login;

namespace Marketplace.App.Runtime.Interface
{
    public interface IMarketData
    {
        // Listado de categorias
        CategoryServiceResponse getCategories();

        // Listado de productos
        ProductsCategoryServiceResponse getProductsByCategories(int IdCategory);

        // Detalle del producto
        ProductInfoServiceResponse getProdyctById(int IdProduct);

        // Market Login
        LoginServiceResponse LoginDistributor(LoginModel entity);

        // Search Product
        SearchServiceResponse SearchProducts();

        // Orders
        OrderResponse SearchOrders(OrderRequest orderFilter, string token);

        // Order detail
        OrderDetailInfoResponse getOrderById(OrderDetailInfoRequest orderFilter, string token);

        // Product quotation
        ProductQuotationServiceResponse getQuotation(ProductQuotationServiceRequest paramsFilter, string token);
    }
}
