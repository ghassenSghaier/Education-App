using EducationWeb.DOMAIN;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace EducationWeb.DAL
{
    
    public class FormationRepository : IFormationRepository
    {        
        BdContext dal = new BdContext();

        
        IList<Formation> IFormationRepository.GetAll()
        {
            return dal.Formation.ToList();
        }

        IList<Formation> IFormationRepository.GetNonInsc()
        {
            return dal.GetNonInsc();
        }

        public Formation GetById(string id)
        {
            return dal.GetForById(id);
        }
        public void Add(Formation formation)
        {
            dal.addFor(formation);
            dal.SaveChanges();
        }       
    }
}
