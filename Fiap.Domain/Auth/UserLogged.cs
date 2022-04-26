using Microsoft.AspNetCore.Http;
using Fiap.Domain.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Domain.Auth
{
    public class UserLogged : IUserLogged
    {
        private readonly IHttpContextAccessor _accessor;

        public UserLogged(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public bool IsAuthenticated => _accessor.HttpContext.User.Identity?.IsAuthenticated ?? false;

        public int Id => _accessor.HttpContext.User.GetUserId();
    }
}
