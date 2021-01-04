using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace JWTApi.Models
{
    public partial class UserModel
    {

        public string UserID { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }


    }
}