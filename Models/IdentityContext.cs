using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace OKVGU.Models
{
    public class IdentityContext : IdentityDbContext<OkUser>
    {
        public IdentityContext() : base("IdentityDb") { }

        public static IdentityContext Create()
        {
            return new IdentityContext();
        }
    }
}