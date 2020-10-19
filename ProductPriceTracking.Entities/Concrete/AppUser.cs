﻿using ProductPriceTracking.Core.Entities.Concrete;
using ProductPriceTracking.Entities.Interfaces;
using System.Collections.Generic;

namespace ProductPriceTracking.Entities.Concrete
{
    public class AppUser : EntityBase, IAppUser
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public IEnumerable<UserRole> UserRoles{ get; set; }

    }
}