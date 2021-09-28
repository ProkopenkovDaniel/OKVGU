
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using OKVGU.Models;

public class OkUserManager : UserManager<OkUser>
{
    public OkUserManager(IUserStore<OkUser> store)
            : base(store)
    {
    }
    public static OkUserManager Create(IdentityFactoryOptions<OkUserManager> options,
                                            IOwinContext context)
    {
        IdentityContext db = context.Get<IdentityContext>();
        OkUserManager manager = new OkUserManager(new UserStore<OkUser>(db));
        return manager;
    }
}