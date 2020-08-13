using System;
using System.Threading.Tasks;
using EduAPP.Models;
using Xamarin.Forms;

namespace EduAPP.ViewModels
{
    public class FormationDetailViewModel : FormationBaseViewModel
    {
        
        public Formation Item { get; set; }
        public FormationDetailViewModel(Formation item = null)
        {
            Title = item?.Title;
            Item = item;
            
        }
    }
}
