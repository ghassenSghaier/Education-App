using System;
using EduAPP.Models;


namespace EduAPP.ViewModels
{
    public class InscriptionDetailViewModel : InscriptionBaseViewModel
    {
        public Inscription Inscription { get; set; }
        public InscriptionDetailViewModel(Inscription inscription = null)
        {
            Title = inscription?.Title;
            Inscription = inscription;
        }
    }
}
