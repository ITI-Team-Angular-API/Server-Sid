using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModel
{
    public enum ResposeStatus
    {
        Succeeded,
        Failed,
        Exception,

    }

    public class RegisterResponse : LoginRepsonse
    {
    }
    public class LoginRepsonse
    {
        public ResposeStatus Status { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        public bool IsAdmin { get; set; }
    }
    public class AddAdmin
    {
        public ResposeStatus Status { get; set; }
        public string Message { get; set; }
    }

}
