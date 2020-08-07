using System;
using System.Collections.Generic;
using Marketplace.App.Runtime.Entities;
using Marketplace.Schemas.Order;
using Marketplace.Schemas.Product;
using Marketplace.Schemas.Search;

namespace Marketplace.App.Runtime.Interface
{
    public interface ILiteDBData
    {
        // Get products search by keyword 
        List<Schemas.Search.SearchProductModel> searchLocalProducts(string search);
        // Insert product
        DBResult FavoriteProduct(ProductInfo entity);
        // Insert all products
        DBResult InsertAllLocalProducts(List<Schemas.Search.SearchProductModel> entity);
        // Get all favorite products
        List<Schemas.Product.ProductInfo> getFavoriteProduct();
        // Check if favorite product exists
        Schemas.Product.ProductInfo ExistFavoriteProduct(ProductInfo entity);
        // Delete favorite product
        DBResult DeleteFavoriteProduct(ProductInfo entity);

        #region RecurringSearch
        List<SearchProductModel> getRecurringSearches();
        DBResult InsertRecurringSearches(SearchProductModel entity);
        DBResult DeleteRecurringSearches();
        #endregion

        #region Orders
        DBResult InsertAllOrders(List<OrderModel> entityList);
        List<OrderModel> getOrders(string OrderNumber, string statusOrder, DateTime initDate, DateTime Enddate);
        #endregion
    }
}
