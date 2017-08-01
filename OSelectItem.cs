using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViolinShop
{
    public class OSelectItem
    {


        public SelectListItem s = new SelectListItem();
        public String Text { get; set; }
        public String Value { get; set; }   
        public OSelectItem(String s1, String s2)
        {
            Text = s1;
            Value = s2;
            SetSli();
        }

        public OSelectItem()
        {
        }

        public void SetSli()
        {
            s.Text = this.Text;
            s.Value = this.Value;
          
        }
        public SelectListItem GetSli()
        {
            return s;
        }
    }
}
