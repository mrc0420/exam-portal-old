using Domain.User.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.User
{
    public class User : IUser
    {
        public string Password { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
    }
}
