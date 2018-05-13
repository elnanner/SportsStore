using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStore.Infrastructure.Identity
{
    //inherited from IdentityUser
    //Email Returns the e-mail address of the user
    //Id Returns the unique ID of the user
    //Roles Returns a collection containing the roles to which the user has been assigned
    //UserName Returns the name of the user
    public class StoreUser: IdentityUser
    {
        //to define
    }
}