using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MobilePhoneAppStore.Models
{
    public class PhoneContext:DbContext
    {
        public DbSet<Phone> Phones { set; get; }
        public DbSet<Client> Clients { set; get; }
    }
    public class PhoneInic : DropCreateDatabaseAlways<PhoneContext>
    {
        protected override void Seed(PhoneContext db)
        {
            db.Phones.Add(new Phone { Model ="IPhone 5s", Price=400, TypeOS="iOS", Weight=134, Count=200});
            db.Phones.Add(new Phone { Model = "IPhone 8", Price = 750, TypeOS = "iOS", Weight = 234, Count = 200 });
            db.Phones.Add(new Phone { Model = "IPhone X", Price = 1000, TypeOS = "iOS", Weight = 240, Count = 200 });
            db.Phones.Add(new Phone { Model = "Samsung Galaxy S10", Price = 1100, TypeOS = "Android", Weight = 300, Count = 200 });
            db.Phones.Add(new Phone { Model = "Nokia 7310", Price = 300, TypeOS = "Windwos Phone", Weight = 280, Count = 200 });
            base.Seed(db);
        }
    }
}