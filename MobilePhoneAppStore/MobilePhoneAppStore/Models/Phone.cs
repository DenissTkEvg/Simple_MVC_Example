using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobilePhoneAppStore.Models
{
    public class Phone
    {
        public int Id { set; get; }
        public string Model { set; get; }
        public string TypeOS { set; get; }
        public int Weight { set; get; }
        public int Price { set; get; }
        public int Count { set; get; }
    }
}