﻿using Avensia.Data;
using Avensia.Data.Models;
using System.Collections.Generic;

namespace Avensia.App_Start
{
    public class DataInit
    {
        public static void InitializeDatabase()
        {
            var sessionFactory = FluentNHibernateSessionFactory.CreateSessionFactory();
            using (var session = sessionFactory.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    // Start from scratch on each start
                    session.CreateQuery("delete from ProductPrice").ExecuteUpdate();
                    session.CreateQuery("delete from Product").ExecuteUpdate();
                    session.CreateQuery("delete from ProductCategory").ExecuteUpdate();
                    //
                    //

                    // The one and only category
                    var category = new ProductCategory() { Name = "Dator & Kringutrustning" };
                    session.SaveOrUpdate(category);

                    // Products
                    session.SaveOrUpdate(new Product() { Id = "68840", Name = "D-Link DCS-930L", Description = "IP-övervakningskamera", Category = category, Prices = new List<ProductPrice>() { new ProductPrice() { Price = 499m } } });
                    session.SaveOrUpdate(new Product() { Id = "18094", Name = "Tryckluft för kontorsrengöring", Description = "", Category = category, Prices = new List<ProductPrice>() { new ProductPrice() { Price = 99m } } });
                    session.SaveOrUpdate(new Product() { Id = "93600", Name = "D-Link DIR-505", Description = "D-Link DIR-505", Category = category, Prices = new List<ProductPrice>() { new ProductPrice() { Price = 399m } } });
                    session.SaveOrUpdate(new Product() { Id = "98982", Name = "Plexgear Silent Cool", Description = "Passar laptop upp till 15”.", Category = category, Prices = new List<ProductPrice>() { new ProductPrice() { Price = 179m } } });
                    session.SaveOrUpdate(new Product() { Id = "94058", Name = "Linocell Keyboard cover", Description = "för iPad generation 2, 3 & 4", Category = category, QuantityMax = 10, Prices = new List<ProductPrice>() { new ProductPrice() { Price = 299m } }, PriceNow = 198m });
                    session.SaveOrUpdate(new Product() { Id = "80004", Name = "Hur funkar det? 2013 del 1", Description = "Inbunden, 464 sidor i färg", Category = category, Prices = new List<ProductPrice>() { new ProductPrice() { Price = 39m } } });
                    session.SaveOrUpdate(new Product() { Id = "98658", Name = "Plexgear Moviesaver 500", Description = "Videoband till dator", Category = category, Prices = new List<ProductPrice>() { new ProductPrice() { Price = 399m } } });
                    session.SaveOrUpdate(new Product() { Id = "98199", Name = "Plexgear Moviesaver 220", Description = "Videoband till dator", Category = category, Prices = new List<ProductPrice>() { new ProductPrice() { Price = 399m } } });
                    session.SaveOrUpdate(new Product() { Id = "93690", Name = "Huawei E3276S", Description = "3G/4G/LTE-modem", Category = category, Prices = new List<ProductPrice>() { new ProductPrice() { Price = 1299m } } });
                    session.SaveOrUpdate(new Product() { Id = "93586", Name = "Roxcore Sonafi", Description = "Bluetooth-högtalare", Category = category, Prices = new List<ProductPrice>() { new ProductPrice() { Price = 399m } } });

                    var p = new Product() { Id = "68039", Name = "Nätverksuttag 2x Cat6", Description = "Proffsmodell, utanpåliggande", Category = category, QuantityMax = 3 };
                    p.Prices = new List<ProductPrice>()
                    {
                        new ProductPrice() { QuantityTo = 9, Price = 119m },
                        new ProductPrice() { QuantityFrom = 10, Price = 99m }
                    };
                    session.SaveOrUpdate(p);

                    tx.Commit();
                }
            }
        }
    }
}