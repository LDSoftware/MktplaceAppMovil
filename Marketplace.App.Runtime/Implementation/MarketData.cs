using Marketplace.App.Runtime.Interface;
using Marketplace.Schemas.Services;
using System.Collections.Generic;
using Marketplace.Schemas.Product;
using System.Linq;
using Marketplace.Schemas.Login;
using Marketplace.ApiClient.Service;
using Marketplace.Schemas.Quotation;

namespace Marketplace.App.Runtime.Implementation
{
    public class MarketData : IMarketData
    {
        //Listado de productos
        IEnumerable<ProductInfo> listProductsLocal;

        public CategoryServiceResponse getCategories()
        {
            var resultList = new CategoryServiceResponse();

            ApiClient.Category.CategoryService catSer =
                new ApiClient.Category.CategoryService(AppRuntime.MarketWebClient, "api/v1/categories");

            var result = catSer.GetCategories().Result;

            return result;
        }

        public ProductsCategoryServiceResponse getProductsByCategories(int IdCategory)
        {
            var resultList = new CategoryServiceResponse();


            ApiClient.Service.ProductCategoriesService resultService =
                new ApiClient.Service.ProductCategoriesService(AppRuntime.MarketWebClient, "api/v1/category");

            var result = resultService.GetProductCategory(IdCategory).Result;

            listProductsLocal = result.Products;

            return result;
        }

        public ProductInfoServiceResponse getProdyctById(int IdProduct)
        {
            var resulItem = new ProductInfoServiceResponse();


            ApiClient.Service.ProductService resultService =
                new ApiClient.Service.ProductService(AppRuntime.MarketWebClient, "api/v1/product");

            resulItem = resultService.GetProductInfo(IdProduct).Result;

            return resulItem;
        }

        public LoginServiceResponse LoginDistributor(LoginModel entity)
        {
            LoginService products = new LoginService(AppRuntime.MarketWebClient, "api/v1/authorizations");
           
            var result = products.LogInUser(entity).Result;

            return result;
        }

        public SearchServiceResponse SearchProducts()
        {
            ProductSearchService products = new ProductSearchService(AppRuntime.MarketWebClient, "api/v1/products");

            var result = products.GetSearchResult().Result;

            return result;
        }

        public OrderResponse SearchOrders(OrderRequest orderFilter, string token)
        {
            OrderService orders = new OrderService(AppRuntime.MarketWebClient, "api/v1/orders");
            orders.SetToken = token;

            var result = orders.GetOrders(orderFilter).Result;

            return result;
        }

        public OrderDetailInfoResponse getOrderById(OrderDetailInfoRequest orderFilter, string token)
        {
            OrderInfoService orderDetail = new OrderInfoService(AppRuntime.MarketWebClient, "api/v1/orders/details");
            orderDetail.SetToken = token;

            var result = orderDetail.GetOrderDetail(orderFilter).Result;

            return result;
        }

        public ProductQuotationServiceResponse getQuotation(ProductQuotationServiceRequest paramsFilter, string token)
        {
            ProductQuotationService service = new ProductQuotationService(AppRuntime.MarketWebClient, "api/v1/productquotation");
            
            var result = service.GetQuotation(paramsFilter).Result;
            return result;
        }
    }
}
