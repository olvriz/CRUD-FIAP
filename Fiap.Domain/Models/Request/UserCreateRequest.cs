using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Domain.Models.Request
{
    public class UserCreateRequest
    {
        public UserCreateRequest(string name, string password, string email)
        {
            Name = name;
            Password = BCrypt.Net.BCrypt.HashPassword(password);
            Email = email;
        }

        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
