using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public string firstname { get; set; }
    public string lastname { get; set; }

    public bool gender { get; set; }

    public List<PurchaseCart> PurchaseCarts { get; set; }
}

