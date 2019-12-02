using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebStore.Domain.Entities.Identity
{
    public class Role:IdentityRole
    {
        public string Description { get; set; }
    }
}
