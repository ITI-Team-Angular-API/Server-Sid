using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Helpers
{
    public class UserInfo
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}