using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using lost_found_api.Models;
using lost_found_api.Data;
using Microsoft.AspNetCore.Cors;

namespace lost_found_api.Controllers
{
    [Route("api/[controller]")]
    public class ItemController : Controller
    {
        private readonly lostfoundcontext db;

        public ItemController(lostfoundcontext db){
            this.db = db;

            if (this.db.Items.Count() == 0){
                this.db.Items.Add(new Item {
                    Id = 0,
                    Category = "test item"
                });

                this.db.SaveChanges();
            }
        }

        [HttpGet]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAll()
        {
            return Ok(db.Items);
        }


        [HttpGet("{id}")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetById(int id)
        {
            var item = db.Items.Find(id);

            if(item == null){
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPost]
        [EnableCors("CorsPolicy")]
        public IActionResult Post([FromBody]Item item)
        {
            if(item == null){
                return BadRequest();
            }

            this.db.Items.Add(item);
            this.db.SaveChanges();

            //return CreatedAtRoute("GetItem", new { id = item.Id }, item);
            return Ok(item);
        }

        [HttpPut("{id}")]
        [EnableCors("CorsPolicy")]
        public IActionResult Put(int id, [FromBody]Item newItem)
        {
            if (newItem == null || newItem.Id != id){
                return BadRequest();
            }
            var currentItem = this.db.Items.FirstOrDefault(x => x.Id == id);

            if(currentItem == null){
                return NotFound();
            }

            currentItem.Category = newItem.Category;
            currentItem.Type = newItem.Type;
            currentItem.School = newItem.School;
            currentItem.Building = newItem.Building;

            this.db.Items.Update(currentItem);
            this.db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [EnableCors("CorsPolicy")]
        public IActionResult Delete(int id)
        {
            var item = this.db.Items.FirstOrDefault(x => x.Id == id);

            if (item == null){
                return NotFound();
            }

            this.db.Items.Remove(item);
            this.db.SaveChanges();

            return NoContent();
        }

    }
}
