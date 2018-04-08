using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using lost_found_api.Models;
using lost_found_api.Data;

namespace lost_found_api.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly lostfoundcontext db;

        public UserController(lostfoundcontext db){
            this.db = db;

            if (this.db.Users.Count() == 0){
                this.db.Users.Add(new User {
                    Id = 0,
                    User_Name = "test user"
                });

                this.db.SaveChanges();
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(db.Users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = db.Users.Find(id);

            if(user == null){
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public IActionResult Post([FromBody]User user)
        {
            if(user == null){
                return BadRequest();
            }

            this.db.Users.Add(user);
            this.db.SaveChanges();

            return CreatedAtRoute("GetUser", new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]User newUser)
        {
            if (newUser == null || newUser.Id != id){
                return BadRequest();
            }
            var currentUser = this.db.Users.FirstOrDefault(x => x.Id == id);

            if(currentUser == null){
                return NotFound();
            }

            currentUser.User_Name = newUser.User_Name;
            currentUser.Email_Addr = newUser.Email_Addr;
            currentUser.Phone_Num = newUser.Phone_Num;

            this.db.Users.Update(currentUser);
            this.db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = this.db.Users.FirstOrDefault(x => x.Id == id);

            if (user == null){
                return NotFound();
            }

            this.db.Users.Remove(user);
            this.db.SaveChanges();

            return NoContent();
        }
    }
}
