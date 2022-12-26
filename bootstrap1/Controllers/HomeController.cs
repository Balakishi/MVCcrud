using bootstrap1.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bootstrap1.Controllers
{
    public class HomeController : Controller
    {

        NorthwindEntities db = new NorthwindEntities();
        public ActionResult Index()
        {
            var model=db.Orders.ToList();
            return View(model);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Yeni()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Yeni(Orders orders)
        {
            if (orders.OrderID == 0) //for insert
            {
                db.Orders.Add(orders);
            }
            else
            {
                var updateData = db.Orders.Find(orders.OrderID);
                if (updateData == null)
                {
                    return HttpNotFound();
                }
                updateData.ShipName = orders.ShipName;
            }

            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Update(int id)
        {
            var model = db.Orders.Find(id);
            if(model== null)
            {
                return HttpNotFound();
            }
            return View("Yeni",model);
        }

        public ActionResult Delete(int id)
        {
            var delete = db.Orders.Find(id);
            if(delete==null)
            {
                return HttpNotFound();
            }
            db.Orders.Remove(delete);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }








    }
}