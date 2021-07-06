using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.User.Abstract
{
   public interface IUser
    {


        string Password { get; set; }
        string Username { get; set; }
        string Email { get; set; }
        string Name { get; set; }

    }
}
