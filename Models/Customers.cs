using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ViolinShop.Models
{


    public class Customers
    {
        public string DataUrl { get; set; }
        public bool Search { get; set; }
        public string AspFor { get; set; }


        public static StringStoreContext db;
        public Customers(StringStoreContext dbc)
        { db = dbc; }

        public Customers()
        {
        }

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string EmailAddress { get; set; }
        public Boolean Stud { get; set; }      // student?
        //public Boolean Instructor { get; set; }
        public Boolean Cust { get; set; }


       
        String Text;
        String Value;

        public IEnumerable<SelectListItem> GetCustomers()
        {
            List<Customers> cu = db.Customers.Where(p => p.Cust == true).ToList();

            IEnumerable<SelectListItem> list = new List<SelectListItem>();
            foreach (Customers item in cu)
            {
                Text = item.FirstName + " " + item.LastName;
                Value = item.ID.ToString();
                OSelectItem os = new OSelectItem(Text, Value);
                list.Append(os.GetSli());
            }

            IEnumerable<SelectListItem> CustomerList = (IEnumerable<SelectListItem>)(list);
            return CustomerList;


        }
        public IEnumerable<SelectListItem> GetStudents()
        {
            List<Customers> cs = db.Customers.Where(p => p.Stud == true).ToList();
            IEnumerable<SelectListItem> list = new List<SelectListItem>();
            foreach (Customers item in cs)
            {
                Text = item.FirstName + " " + item.LastName;
                Value = item.ID.ToString();
                OSelectItem os = new OSelectItem(Text, Value);
                list.Append(os.GetSli());
            }

            IEnumerable<SelectListItem> CustomerList = (IEnumerable<SelectListItem>)(list);
            return CustomerList;


        }
        static List<Customers> cu = db.Customers.Where(p => p.Cust == true).ToList();
        static List<Customers> cs = db.Customers.Where(p => p.Stud == true).ToList();
        public int CustomerID { get; set; }
        public int SelectedCustomer { get; set; }
    }
        
    public class CustomerModel
    { 
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public int ID { get; set; }
        public string MiddleName { get; set; }
        public string EmailAddress { get; set; }
        public Boolean Stud { get; set; }      // student?
        //public Boolean Instructor { get; set; }
        public Boolean Cust { get; set; }
        public String SelectedCustomer { get; set; }
        public IEnumerable<SelectListItem> Customers { get; set; }
     }
    public class StudentModel
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public int ID { get; set; }
        public IEnumerable<SelectListItem> Customers { get; set; }
    }
    public class CustomerViewModel
    {
        public String Name { get; set; }
        public int ID { get; set; }
       
    }

    public class StudentViewModel
    {
        public String Name { get; set; }
        public int ID { get; set; }

    }

}