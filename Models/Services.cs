using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViolinShop.Models
{
    public class Services
    {
        public IEnumerable<SelectListItem> Instructors { get; set; }
        public int SelectedInstructor { get; set; }

        public IEnumerable<SelectListItem> Students { get; set; }
        public int SelectedStudent { get; set; }
        public IEnumerable<SelectListItem> FromAppointment { get; set; }
        public int SelectedFrom { get; set; }
        //Other Existing properties also.
        public IEnumerable<SelectListItem> ToAppointment { get; set; }
        public int SelectedTo { get; set; }
        public Services()
        {
            Instructors = new List<SelectListItem>();
            Students = new List<SelectListItem>();
            FromAppointment = new List<SelectListItem>();
            ToAppointment = new List<SelectListItem>();
        }
    }
}
