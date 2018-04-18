using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using lost_found_api.Models;
using lost_found_api.Data;
using Microsoft.AspNetCore.Cors;
using System.Diagnostics;

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
                    username = "test user",
                    emailaddr = "test email",
                    phonenum = "test number",
                    password = "testpass"
                });

                this.db.SaveChanges();
            }
        }

        [HttpGet]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAll()
        {
            return Ok(db.Users);
        }

        [HttpGet("{id}")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetById(int id)
        {
            var user = db.Users.Find(id);

            if(user == null){
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        [EnableCors("CorsPolicy")]
        public IActionResult Post([FromBody]User user)
        {
            if(user == null){
                return BadRequest();
            }
            Debug.WriteLine(user.emailaddr);
            Debug.WriteLine(user.username);

            this.db.Users.Add(user);
            this.db.SaveChanges();

            //return CreatedAtRoute("GetUser", new { id = user.Id }, user);
            return Ok(user);
        }

        [HttpPut("{id}")]
        [EnableCors("CorsPolicy")]
        public IActionResult Put(int id, [FromBody]User newUser)
        {
            if (newUser == null || newUser.Id != id){
                return BadRequest();
            }
            var currentUser = this.db.Users.FirstOrDefault(x => x.Id == id);

            if(currentUser == null){
                return NotFound();
            }

            currentUser.username = newUser.username;
            currentUser.emailaddr = newUser.emailaddr;
            currentUser.phonenum = newUser.phonenum;

            this.db.Users.Update(currentUser);
            this.db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [EnableCors("CorsPolicy")]
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
