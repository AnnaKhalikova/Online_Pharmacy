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
    public class AdminController: ControllerBase
    {
        ItemContext db;
        public AdminController(ItemContext context)
        {
            db = context;
            if (!db.Items.Any())
            {
                db.Items.Add(new Item { Name = "Tirozol", Price = 18.50, Amount = 10 });
                db.Items.Add(new Item { Name = "Analgin", Price = 2.10, Amount = 100 });
                db.SaveChanges();
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> Get()
        {
            return await db.Items.ToListAsync();
        }
        // GET api/admin/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> Get(int id)
        {
            Item item = await db.Items.FirstOrDefaultAsync(x => x.Id == id);
            if (item == null)
                return NotFound();
            return new ObjectResult(item);
        }
        // POST api/admin
        [HttpPost]
        public async Task<ActionResult<Item>> Post(Item item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            db.Items.Add(item);
            await db.SaveChangesAsync();
            return Ok(item);
        }
        // PUT api/admin/
        [HttpPut]
        public async Task<ActionResult<Item>> Put(Item item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            if (!db.Items.Any(x => x.Id == item.Id))
            {
                return NotFound();
            }

            db.Update(item);
            await db.SaveChangesAsync();
            return Ok(item);
        }
        // DELETE api/admin/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Item>> Delete(int id)
        {
            Item user = db.Items.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            db.Items.Remove(user);
            await db.SaveChangesAsync();
            return Ok(user);
        }

    }
}
