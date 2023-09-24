﻿using Identity.API.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Identity.API.Dtos
{
    public class UserCreate
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
