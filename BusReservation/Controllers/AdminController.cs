﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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
        //if db is not linked we will use this list to enable API requests.
        static List<Admin> Admins = new List<Admin>
        {
            new Admin { AdminId = 1, Email = "admin1@gmail.com", Password = "admin@123", Firstname = "Jitin", Lastname = "Sharma" },
            new Admin { AdminId = 2, Email = "admin2@gmail.com", Password = "admin@123", Firstname = "Anshul", Lastname = "Bansal" },
            new Admin { AdminId = 3, Email = "admin3@gmail.com", Password = "admin@123", Firstname = "Omkar", Lastname = "Bhagwat" },
            new Admin { AdminId = 4, Email = "admin4@gmail.com", Password = "admin@123", Firstname = "Divya", Lastname = "Marikanti" }

        };

        //Get api/adminSignincontroller
        //to get all the details
        [HttpGet]
        [Route("list")]
        public IActionResult GetAdmin()
        {
            
        }

    }

}