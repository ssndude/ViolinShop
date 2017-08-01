using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Data.SqlClient;
using ViolinShop.Models;


namespace ViolinShop.Controllers
{

    public class CustomersController : Controller
        {
            public StringStoreContext dbc;
            public CustomersController(StringStoreContext db)
            { dbc = db; }
        CustomerModel CustModel;
        public IActionResult Index()
         {
            
          CustModel = new CustomerModel();
            CustModel.Customers = PopulateCustomers();
            return View(CustModel);
        }   
        [HttpPost]
        public IActionResult Index(CustomerModel Cust)
        {
            Cust.Customers = PopulateCustomers();
            var selectedItem = Cust.Customers.GetEnumerator().Current;    //(p => p.Value == Cust.ID.ToString());
            if (selectedItem != null)
            {
                selectedItem.Selected = true;
                ViewBag.Message = selectedItem.Text;
                ViewBag.Message += Cust.ID;
            }
            return View();
        }
        [HttpPost]
        public IActionResult Customers(CustomerModel Cust)
        {
            Cust.Customers = PopulateCustomers();
            var selectedItem = Cust.Customers.GetEnumerator().Current;    //(p => p.Value == Cust.ID.ToString());
            if (selectedItem != null)
            {
                selectedItem.Selected = true;
                ViewBag.Message = selectedItem.Text;
                ViewBag.Message += Cust.ID;
            }
            return View();
        }
        private static List<SelectListItem> PopulateCustomers()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            string constr = "Data Source=RIXS-06;Initial Catalog=StringStore;Integrated Security=True;Connect Timeout=15;";
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = " SELECT ID, Firstname + ' ' + Lastname  as name FROM Customers where Cust=1";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            items.Add(new SelectListItem
                            {
                                Text = sdr["Name"].ToString(),
                                Value = sdr["ID"].ToString()
                            });
                        }
                    }
                    con.Close();
                }
            }

            return items;
        }

    }
}