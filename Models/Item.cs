using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserWebApi.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Code { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
    }
}
