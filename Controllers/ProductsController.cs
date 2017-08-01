using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using ViolinShop.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ViolinShop.Controllers
{
    public class ProductsController : Controller
    {
        // GET: /<controller>/
        //private StringStoreContext db = new StringStoreContext();
        public StringStoreContext db;
        public ProductsController(StringStoreContext dbc)
        { db = dbc; }

        public Cart cart;
        ICollection<Products> product;
        ICollection<LineItems> cartitem;


        public IActionResult getMusicList()
        {
            //Products products;
            ICollection<Products> products = db.Products.Where(p => p.Code == "MU").ToList();
            return View(products);
        }

        public IActionResult getIstrumentList()
        {
            //Products products;
            ICollection<Products> products = db.Products.Where(p => p.Code != "MU").ToList();
            return View(products);
        }

        [HttpPost]
        public IActionResult Products(Products model)
        {

            ICollection<LineItems>  CartContents;
            if (cart == null)
                cart = new Cart();
            

           
           //Request.Form.Keys.Take(j);
            string code;
            string price;
            String Qty;
            int cID=0;
            int ID=0;
            StringValues value = "";
           
            foreach (string key in Request.Form.Keys)
            {
                
                switch (key)
                {
                    case "Code":  if (Request.Form.TryGetValue(key, out value))
                                        code = value;
                                  break;
                    case "Price":
                                  if (Request.Form.TryGetValue(key, out value))
                                      price = value;
                        break;

                    case "Quantity":
                        if (Request.Form.TryGetValue(key, out value))
                            Qty = value;
                        break;

                    case "Product.Id":
                        if (Request.Form.TryGetValue(key, out value))
                            ID = int.Parse(value);
                        break;

                        }
            }
            ICollection<Products> products = db.Products.ToList();

            if (cID == 0)
            {
                LineItems item = new LineItems(ID);
                cID = item.ProductId;
            }
             return View(products);
        }
        [HttpGet]
        public IActionResult Products()
        {
            ICollection<Products> products = db.Products.ToList();
            return View(products);

        }
        public IActionResult Cart()
        {
            ICollection<Products> products = db.Products.Where(p => p.Code != "MU").ToList();
            return View(products); 
        }

  
        


        //public static void SetValue(object inputObject, string propertyName, object propertyVal)
        //{
        //    //find out the type
        //    Type type = inputObject.GetType();

        //    //get the property information based on the type
        //    PropertyInfo propertyInfo = type.GetProperty(propertyName);

        //    //find the property type
        //    Type propertyType = propertyInfo.PropertyType;

        //    //Convert.ChangeType does not handle conversion to nullable types
        //    //if the property type is nullable, we need to get the underlying type of the property
        //    var targetType = IsNullableType(propertyInfo.PropertyType) ? Nullable.GetUnderlyingType(propertyInfo.PropertyType) : propertyInfo.PropertyType;

        //    //Returns an System.Object with the specified System.Type and whose value is
        //    //equivalent to the specified object.
        //    propertyVal = Convert.ChangeType(propertyVal, targetType);

        //    //Set the value of the property
        //    propertyInfo.SetValue(inputObject, propertyVal, null);

        //}
        //private static bool IsNullableType(Type type)
        //{
        //    return type.IsGenericParameter && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>));
        //}
    }
}
