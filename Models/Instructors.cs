using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ViolinShop.Models
{
    public partial class Instructors
    {
        public int Id { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        String Text;
        String Value;
        public static StringStoreContext db;
        public Instructors (StringStoreContext dbc)
        { db = dbc; }
        public SelectList GetInstructors()
        {
            List<Instructors> cu = db.Instructors.ToList();

            IEnumerable<SelectListItem> list = new List<SelectListItem>();
            foreach (Instructors item in cu)
            {
                Text = item.FirstName + " " + item.LastName;
                Value = item.Id.ToString();
                OSelectItem os = new OSelectItem(Text, Value);
                list.Append(os.GetSli());
            }

            SelectList InstructorList = new SelectList(list);

            return InstructorList;
            
        }
        public IEnumerable<SelectListItem> GetStudents()
        {
            Customers cust = new Customers();
            IEnumerable<SelectListItem> stud = cust.GetStudents();
            return stud;
        }
    }

    public class InstructorsModel
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public int ID { get; set; }
        public IEnumerable<SelectListItem> Instructors { get; set; }
        public IEnumerable<SelectListItem>  Students { get; set; }
    }
}
