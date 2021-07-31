using BL.Bases;
using BL.ViewModel;
using DAL;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices
{
    public class AccountAppService : AppServiceBase
    {
        //Login
        public ApplicationUserIDentity Find(string name, string passworg)
        {
            return TheUnitOfWork.Account.Find(name, passworg);
        }
        public ApplicationUserIDentity FindByName(string name)
        {
            return TheUnitOfWork.Account.FindByName(name);
        }
        public IdentityResult Register(RegisterViewodel user)
        {
            ApplicationUserIDentity identityUser = 
                Mapper.Map<RegisterViewodel, ApplicationUserIDentity>(user);
            return TheUnitOfWork.Account.Register(identityUser,user.Password);

        }
        public IdentityResult AssignToRole(string userid, string rolename)
        {
            return TheUnitOfWork.Account.AssignToRole(userid, rolename);


        }
        public bool HasRole(string userid, string rolename)
        {
            return TheUnitOfWork.Account.HasRole(userid, rolename);
        }
        public IdentityResult Update(ApplicationUserIDentity user)
        {
            return TheUnitOfWork.Account.Update(user);
        }
    }
}
