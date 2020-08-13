using EducationWeb.DAL;
using EducationWeb.DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebAPP.DAL
{
    public class InscriptionRepository : IInscriptionRepository
    {
        BdContext dal = new BdContext();
        IList<Inscription> IInscriptionRepository.GetAll()
        {
            return dal.Inscription.ToList();
        }

        public void Add(Inscription inscription)
        {
            dal.Inscription.Add(inscription);            
            dal.SaveChanges();
        }

        public Inscription GetById(string id)
        {
            return dal.GetInscById(id);
        }

        public void delete(string id)
        {
            dal.deleteInsc(id);
            dal.SaveChanges();
        }
    }
}
