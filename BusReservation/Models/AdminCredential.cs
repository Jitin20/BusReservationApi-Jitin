﻿using System;
using System.Collections.Generic;

#nullable disable

namespace BusReservation.Models
{
    public partial class AdminCredential
    {
        public int AdminId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
