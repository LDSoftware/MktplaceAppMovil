using System;
using LiteDB;
using Marketplace.App.Runtime.Interface;
using System.Collections.Generic;
using Marketplace.Schemas.Search;
using Marketplace.App.Runtime.Entities;
using System.Linq;
using Marketplace.Schemas.Product;
using Marketplace.Schemas.Order;

namespace Marketplace.App.Runtime.Implementation
{
    public class LiteDBService : ILiteDBData
    {
        public DBResult InsertAllLocalProducts(List<SearchProductModel> entity)
        {
            DBResult result = new DBResult();

            using (var db = new LiteDatabase(AppRuntime.LiteDbConnectionString))
            {
                try
                {
                    var data = db.GetCollection<SearchProductModel>("ProductsForSeacrh");
                    data.Insert(entity);
                    result.IsSucess = true;
                }
                catch (Exception ex)
                {
                    result.IsSucess = false;
                    result.Message = ex.Message;
                }
            }
            return result;
        }

        #region Favorite Products
        public DBResult FavoriteProduct(ProductInfo entity)
        {
            DBResult result = new DBResult();

            using (var db = new LiteDatabase(AppRuntime.LiteDbConnectionString))
            {
                try
                {
                    var data = db.GetCollection<Schemas.Product.ProductInfo>("ProductInfo");
                    data.Insert(entity);
                    result.IsSucess = true;
                }
                catch (Exception ex)
                {
                    result.IsSucess = false;
                    result.Message = ex.Message;
                }
            }
            return result;
        }

        public List<Schemas.Product.ProductInfo> getFavoriteProduct()
        {
            List<Schemas.Product.ProductInfo> resultProduct = new List<Schemas.Product.ProductInfo>();

            using (var db = new LiteDatabase(AppRuntime.LiteDbConnectionString))
            {
                var data = db.GetCollection<Schemas.Product.ProductInfo>("ProductInfo");
                resultProduct = data.FindAll().ToList();
            }
            return resultProduct;
        }

        public Schemas.Product.ProductInfo ExistFavoriteProduct(ProductInfo entity)
        {
            Schemas.Product.ProductInfo resultProduct = new Schemas.Product.ProductInfo();

            using (var db = new LiteDatabase(AppRuntime.LiteDbConnectionString))
            {
                var data = db.GetCollection<Schemas.Product.ProductInfo>("ProductInfo");
                resultProduct = data.Find(Query.EQ("_id", entity.Id)).FirstOrDefault();
            }
            return resultProduct;
        }

        public DBResult DeleteFavoriteProduct(ProductInfo entity)
        {
            DBResult result = new DBResult();

            using (var db = new LiteDatabase(AppRuntime.LiteDbConnectionString))
            {
                try
                {
                    var data = db.GetCollection<Schemas.Product.ProductInfo>("ProductInfo");
                    var value = new LiteDB.BsonValue(entity.Id);
                    data.Delete(value);
                    result.IsSucess = true;
                }
                catch (Exception ex)
                {
                    result.IsSucess = false;
                    result.Message = ex.Message;
                }
            }
            return result;
        }
        #endregion

        #region Recurring search
        public List<SearchProductModel> getRecurringSearches()
        {
            List<SearchProductModel> listItem = new List<SearchProductModel>();

            using (var db = new LiteDatabase(AppRuntime.LiteDbConnectionString))
            {
                var data = db.GetCollection<Schemas.Search.SearchProductModel>("RecurringSearches");

                listItem = data.FindAll().ToList();
            }
            return listItem;
        }

        public DBResult InsertRecurringSearches(SearchProductModel entity)
        {
            DBResult result = new DBResult();

            using (var db = new LiteDatabase(AppRuntime.LiteDbConnectionString))
            {
                try
                {
                    var data = db.GetCollection<Schemas.Search.SearchProductModel>("RecurringSearches");

                    SearchProductModel searchItem = data.Find(Query.EQ("IdProduct", entity.IdProduct)).FirstOrDefault();

                    if (searchItem == null)
                    {
                        data.Insert(entity);
                    }
                   
                    result.IsSucess = true;
                }
                catch (Exception ex)
                {
                    result.IsSucess = false;
                    result.Message = ex.Message;
                }
            }
            return result;
        }

        public DBResult DeleteRecurringSearches()
        {
            DBResult result = new DBResult();

            using (var db = new LiteDatabase(AppRuntime.LiteDbConnectionString))
            {
                try
                {
                    var data = db.GetCollection<Schemas.Search.SearchProductModel>("RecurringSearches");

                    data.DeleteAll();

                    result.IsSucess = true;
                }
                catch (Exception ex)
                {
                    result.IsSucess = false;
                    result.Message = ex.Message;
                }
            }
            return result;
        }

        public List<SearchProductModel> searchLocalProducts(string search)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Orders
        public DBResult InsertAllOrders(List<OrderModel> entityList)
        {
            DBResult result = new DBResult();

            using (var db = new LiteDatabase(AppRuntime.LiteDbConnectionString))
            {
                try
                {
                    var data = db.GetCollection<OrderModel>("Orders");
                    // Borramos lo insertado
                    data.DeleteAll();
                    // Volvemos a insertar
                    data.Insert(entityList);
                    result.IsSucess = true;
                }
                catch (Exception ex)
                {
                    result.IsSucess = false;
                    result.Message = ex.Message;
                }
            }
            return result;
        }
        public List<OrderModel> getOrders(string OrderNumber, string statusOrder, DateTime initDate, DateTime Enddate)
        {
            List<OrderModel> resultList = new List<OrderModel>();

            using (var db = new LiteDatabase(AppRuntime.LiteDbConnectionString))
            {
                var data = db.GetCollection<OrderModel>("Orders");
                resultList = data.FindAll().ToList();
                // Filtramos por Numero de la orden
                if (!string.IsNullOrEmpty(OrderNumber))
                {
                    resultList = resultList.Where(e => e.OrderId.Contains(OrderNumber)).ToList();
                }
                // Filtramos por status de la orden
                if (!string.IsNullOrEmpty(statusOrder))
                {
                    resultList = resultList.Where(e => e.Status == statusOrder).ToList();
                }
                // Filtramos por la fecha
                if (initDate.Year!=1900)
                {
                    var filterInit = DateTime.Parse(initDate.ToString("MM/dd/yyyy HH:mm:ss"));
                    var filterEnd = DateTime.Parse(Enddate.ToString("MM/dd/yyyy HH:mm:ss"));

                    resultList = resultList.Where(e => e.CreateDate>= filterInit && e.CreateDate<= filterEnd).ToList();
                }

            }
            return resultList;
        }
        #endregion
    }
}
