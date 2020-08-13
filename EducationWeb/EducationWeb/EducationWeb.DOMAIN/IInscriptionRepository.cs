using System;
using System.Collections.Generic;
using System.Text;

namespace EducationWeb.DOMAIN
{
    public interface IInscriptionRepository
    {
        IList<Inscription> GetAll();

        void Add(Inscription inscription);

        Inscription GetById(string id);

        void delete(string id);
    }
}
