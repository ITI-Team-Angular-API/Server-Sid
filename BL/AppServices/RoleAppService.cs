using BL.Bases;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices
{
    public class RoleAppService : AppServiceBase
    {
        public IdentityResult Create(string rolename)
        {
            return TheUnitOfWork.Role.Create(rolename);
        }
    }
}
