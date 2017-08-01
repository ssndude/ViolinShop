using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using ViolinShop.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ViolinShop.Controllers
{
    public class ServicesController : Controller
    {
        // GET: /<controller>/



      public PartialViewResult RenderInstructors()
      {
          return PartialView(PopulateInstructors());
      }

      public PartialViewResult RenderStudents()
      {
          return PartialView(PopulateStudents());
      }
        public IActionResult Services()
        {
            var svc = new Services();
            svc.Instructors = PopulateInstructors();
            svc.Students = PopulateStudents();
            svc.FromAppointment = PopulateAppointmentList();
            svc.ToAppointment = PopulateAppointmentList();
            return View(svc);

            //return View();
        }

        static StudentModel students;
        [HttpPost]
        public IActionResult Services(InstructorsModel inst)
        {
            inst.Instructors = PopulateInstructors();
            students.Customers = PopulateStudents();
            var selectedItem = inst.Instructors.GetEnumerator().Current;    //(p => p.Value == Cust.ID.ToString());
            if (selectedItem != null)
            {
                selectedItem.Selected = true;
                ViewBag.Message = selectedItem.Text;
                ViewBag.Message += inst.ID;
            }
            selectedItem = students.Customers.GetEnumerator().Current;    //(p => p.Value == Cust.ID.ToString());
            if (selectedItem != null)
            {
                selectedItem.Selected = true;
                ViewBag.Message += selectedItem.Text;
                ViewBag.Message += students.ID;
            }
            
            return View(students);

            //return View();
        }

        private static IEnumerable<SelectListItem> PopulateInstructors()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            string constr = "Data Source=RIXS-06;Initial Catalog=StringStore;Integrated Security=True;Connect Timeout=15;";
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = " SELECT ID, Firstname + ' ' + Lastname  as name FROM Instructors";
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

            return (IEnumerable<SelectListItem>)items;
        }
        private static IEnumerable<SelectListItem> PopulateStudents()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            string constr = "Data Source=RIXS-06;Initial Catalog=StringStore;Integrated Security=True;Connect Timeout=15;";
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = " SELECT ID, Firstname + ' ' + Lastname  as name FROM Customers where Stud = 1";
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

            return (IEnumerable<SelectListItem>)items;

        }
        private static IEnumerable<SelectListItem> PopulateAppointmentList()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem {Text = "9:00 AM", Value = "9" });
            items.Add(new SelectListItem { Text = "9:30 AM", Value = "9.5" });
            items.Add(new SelectListItem { Text = "10:00 AM", Value = "10" });
            items.Add(new SelectListItem { Text = "10:30 AM", Value = "10.5" });
            items.Add(new SelectListItem { Text = "11:00 AM", Value = "11" });
            items.Add(new SelectListItem { Text = "11:30 AM", Value = "11.5" });
            items.Add(new SelectListItem { Text = "Noon", Value = "12" });
            items.Add(new SelectListItem { Text = "12:30 PM", Value = "12.5" });
            items.Add(new SelectListItem { Text = "1:00 PM", Value = "13" });
            items.Add(new SelectListItem { Text = "1:30 PM", Value = "13.5" });
            items.Add(new SelectListItem { Text = "2:00 PM", Value = "14" });
            items.Add(new SelectListItem { Text = "2:30 PM", Value = "14.5" });
            items.Add(new SelectListItem { Text = "3:00 PM", Value = "15" });
            items.Add(new SelectListItem { Text = "3:30 pM", Value = "15.5" });
            items.Add(new SelectListItem { Text = "4:00 PM", Value = "16" });
            items.Add(new SelectListItem { Text = "4:30 PM", Value = "16.5" });
            items.Add(new SelectListItem { Text = "5:00 PM", Value = "17" });
            items.Add(new SelectListItem { Text = "5:30 PM", Value = "17.5" });
            items.Add(new SelectListItem { Text = "6:00 PM", Value = "18" });
            items.Add(new SelectListItem { Text = "6:30 PM", Value = "18.5" });
            items.Add(new SelectListItem { Text = "7:00 PM", Value = "19" });
            items.Add(new SelectListItem { Text = "7:30 pM", Value = "19.5" });
            return items;
        }
    }
}
