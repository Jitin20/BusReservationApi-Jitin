using BusReservation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusReservation.Controllers
{
    public class Admin
    {
        public int AdminId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        BusReservationContext db = new BusReservationContext();


        //if db is not linked we will use this list to enable API requests.
        //static List<Admin> Admins = new List<Admin>
        //{
        //    new Admin { AdminId = 1, Email = "admin1@gmail.com", Password = "admin@123", Firstname = "Jitin", Lastname = "Sharma" },
        //    new Admin { AdminId = 2, Email = "admin2@gmail.com", Password = "admin@123", Firstname = "Anshul", Lastname = "Bansal" },
        //    new Admin { AdminId = 3, Email = "admin3@gmail.com", Password = "admin@123", Firstname = "Omkar", Lastname = "Bhagwat" },
        //    new Admin { AdminId = 4, Email = "admin4@gmail.com", Password = "admin@123", Firstname = "Divya", Lastname = "Marikanti" }

        //};

        //Get api/adminSignincontroller
        //to get all the details

      

        [HttpGet]
        [Route("list")]

        public IActionResult GetDetails()
        {
            try
            {
                var data = db.AdminCredentials.ToList();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }

        }

        //GET Api/<AdminController>/3
        [HttpGet("{id}")]
        [Route("list/{id}")]

        public IActionResult GetAdmin(int id)
        {
            try
            {
                var data = db.AdminCredentials.Where(admin => admin.AdminId == id).FirstOrDefault();
                return Ok(data);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }
        

        [HttpPost]
        [Route("Validate")]
        public IActionResult PostAdmin(string email, string password)
        {
           
            if (ModelState.IsValid)
            {
                try
                {
                    var data = db.AdminCredentials.Where(admin => admin.Email == email && admin.Password == password).FirstOrDefault();
                    //password = Convert.ToBase64String(Encoding.UTF8.GetBytes(password));
                    if (data != null)
                    {
                        return Ok(data);
                    }
                    else
                    {
                        return NotFound("Admin not registered");
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.InnerException.Message);
                }
            }
            
            return BadRequest("Something Went Wrong");
           
        }


    }
}
