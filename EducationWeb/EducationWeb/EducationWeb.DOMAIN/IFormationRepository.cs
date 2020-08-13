using EducationWeb.DOMAIN;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationWeb.DOMAIN
{
    public interface IFormationRepository
    {
        IList<Formation> GetAll();

        Formation GetById(string id);

        IList<Formation> GetNonInsc();

        void Add(Formation formation);

    }
}
