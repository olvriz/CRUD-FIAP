using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime RegistrationDate { get; set; }
        protected string PasswordHash { get; set; } = string.Empty;

        public bool IsValidPassword(string passwordForCheck)
        {
            return BCrypt.Net.BCrypt.Verify(passwordForCheck, PasswordHash);
        }

    }
}
