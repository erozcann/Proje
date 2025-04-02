﻿namespace ProductApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } // şimdilik plain-text (geliştirilebilir)
        public string Role { get; set; } // örnek: Admin, Customer
    }


}
