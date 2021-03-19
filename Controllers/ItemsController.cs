using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserWebApi.Models;

namespace UserWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        ItemContext db;
        public ItemsController(ItemContext context)
        {
            db = context;
            if (!db.Items.Any())
            {
                db.Items.Add(new Item { Name = "Tirozol", Price = 18.50, Amount = 10});
                db.Items.Add(new Item { Name = "Analgin", Price = 2.10, Amount = 100 });
                db.SaveChanges();
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> Get()
        {
            return await db.Items.ToListAsync();
        }
        //GET api/Items/NameAsc
        [HttpGet("{sortingParameter}")]
        public async Task<ActionResult<IEnumerable<Item>>> Get(string sortingParameter)
        {

            switch (sortingParameter)
            {
                case "PriceAsc":
                    return await db.Items.OrderBy(x => x.Price).ToListAsync();
                case "PriceDesc":
                    return await db.Items.OrderByDescending(x => x.Price).ToListAsync();
                case "NameAsc":
                    return await db.Items.OrderBy(x => x.Name).ToListAsync();
                case "NameDesc":
                    return await db.Items.OrderByDescending(x => x.Name).ToListAsync();
            }

            return await db.Items.ToListAsync();
        }        
    }
}
