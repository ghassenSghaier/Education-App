using System;

using EduAPP.Models;

namespace EduAPP.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Formation Formation { get; set; }
        public ItemDetailViewModel(Formation item = null)
        {
            Title = item?.Title;
            Formation = item;
        }
    }
}
