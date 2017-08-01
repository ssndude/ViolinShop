using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViolinShop.Models;

namespace ViolinShop
{
    public static class StaticStuff
    {

        public static IEnumerable<SelectListItem> ToSelectListItems(
             this IEnumerable<Customers> Customer, int ID)
        {
            return
                Customer.OrderBy(Customers => Customers.LastName)
                      .Select(Customers =>
                          new SelectListItem
                          {
                              Selected = (Customers.ID == ID),
                              Text = Customers.FirstName + " " + Customers.LastName,
                              Value = Customers.ID.ToString()
                          });
        }

       
    }
}
