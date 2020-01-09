using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MobilePhoneAppStore.Models;
using System.Web.Helpers;

namespace MobilePhoneAppStore.Controllers
{
    public class HomeController : Controller
    {
        PhoneContext db = new PhoneContext();
        private DateTime getToday()
        {
            return DateTime.Now;
        }


        public ActionResult Index()
        {
            IEnumerable<Phone> phones = db.Phones.ToList();
            ViewBag.Phones = phones;
            return View();
        }
        [HttpGet]
        public ActionResult Buy(int? id)
        {
            ViewBag.PhoneId = id;
            foreach(Phone phone in db.Phones)
            {
                if (phone.Id == id)
                {
                    phone.Count=phone.Count-50;
                    
                }
                
            }
            db.SaveChanges();
            return View();
            
            
            
        }
        [HttpPost]
        public ActionResult Buy(Client client)
        {
            foreach(Client c in db.Clients)
            {
                if (c.Name != null)
                {
                    if (String.Compare(c.Name, client.Name) == 0 && String.Compare(c.Adress, client.Adress) == 0)
                    {
                        client.DateTimeOfBuy = DateTime.Now;
                        ViewBag.Client = client;
                        return View("~/Views/Home/ThanksForBuy.cshtml");
                    }
                }
                else break;
            }
            
            client.DateTimeOfBuy =getToday();
            db.Clients.Add(client);
            // сохраняем в бд все изменения
            db.SaveChanges();
            ViewBag.Client = client;
            return View("~/Views/Home/ThanksForBuy.cshtml");
        }
        public ActionResult DrawChart()
        {
            List<string> l1 = new List<string>();
            foreach (Phone p in db.Phones)
            {
                l1.Add(p.Model);
            }
            List<int> l2 = new List<int>();
            foreach (Phone p in db.Phones)
            {
                l2.Add(p.Count);
            }
            new Chart(width: 700, height: 400, theme: ChartTheme.Yellow)
                .AddSeries(
                    chartType: "Bar",
                    xValue: l1,
                    yValues:l2).Write("png");
            return null;
        }
        public ActionResult DashBar()
        {
            List<string> l1 = new List<string>();
            foreach (Phone p in db.Phones)
            {
                l1.Add(p.Model);
            }
            List<int> l2 = new List<int>();
            foreach (Phone p in db.Phones)
            {
                l2.Add(p.Count);
            }
            ViewBag.Models = l1.ToList();
            ViewBag.Counts = l2.ToList();
            return View();

        }
        public ActionResult ShowClients()
        {
            IEnumerable<Client> clients = db.Clients.ToList();
            ViewBag.Clients = clients;
            return View();
        }


    }
}