using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ODZ.Data
{
    public class StoreUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }


    }
}
