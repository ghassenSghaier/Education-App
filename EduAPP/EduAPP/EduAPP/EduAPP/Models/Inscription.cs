using System;
using System.Collections.Generic;
using System.Text;

namespace EduAPP.Models
{
    public class Inscription 
    {
        public string InscId { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string ForId { get; set; }

        public Inscription(string InscId, string Title, DateTime Date, string ForId)
        {
            this.InscId = InscId;
            this.Date = Date;
            this.Title = Title;
            this.ForId = ForId;
        }
        public Inscription()
        {            
        }

       
    }
}
