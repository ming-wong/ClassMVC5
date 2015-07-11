using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EFController : Controller
    {
        // GET: EF
        public ActionResult Index()
        {
            var db = new FabricsEntities2();
            var data = db.Product.Where(p => p.ProductId > 1400);
            return View(data);
        }

        public ActionResult First()
        {
            var db = new FabricsEntities2();
            var First = db.Product.FirstOrDefault(p => p.ProductId == 1556);
            return View(First);
        }

        public int AddProduct()
        {
            using (var db = new FabricsEntities2())
            {
                var product = new Product()
                {
                    ProductName = "連帽T",
                    Price = 1000,
                    Stock = 100,
                    Active = true
                };

                db.Product.Add(product);

                db.SaveChanges();

                return product.ProductId;
                
            }
            return 0;
        }

        public ActionResult UpdateClient()
        {
            var db = new FabricsEntities2();
            var data5 = db.Client.Take(5);
            foreach (var item in data5)
            {
                item.City = "Taipei";
            }

            db.SaveChanges();


            return View(data5);
        }


        public ActionResult DeleteClient()
        {
            var db = new FabricsEntities2();
            var data5 = db.Client.Take(5);
            foreach (var client in data5)
            {
                foreach (var order in client.Order)
                {
                    db.OrderLine.RemoveRange(order.OrderLine);
                }
                db.Order.RemoveRange(client.Order);
            }
            db.Client.RemoveRange(data5);
            db.SaveChanges();

            return View(data5);
        }

        public ActionResult RemoveProduct(int id = 0)
        {
            var db = new FabricsEntities2();
            var data = db.Product.Find(id);




            return View();
        }

        public ActionResult vmClient()
        {
            var db = new FabricsEntities2();
            var data = db.vmClient.ToList();
            return View(data);
        }


    }
}