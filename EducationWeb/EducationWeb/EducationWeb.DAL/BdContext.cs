using EducationWeb.DOMAIN;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace EducationWeb.DAL
{
    public class BdContext : DbContext
    {

        public BdContext()
            : base("Data Source = localhost; Initial Catalog = GestionFormation; Integrated Security = True")
        {
        }

        public virtual DbSet<Formation> Formation { get; set; }
        public virtual DbSet<Inscription> Inscription { get; set; }

        public IList<Formation> Formations { get; set; }
        
  
        public Formation GetForById(string id)
        {            
            return Formation.Where(f => f.ForId.Equals(id)).First();

        }

        public IList<Formation> GetNonInsc()
        {
  
            return Formation.SqlQuery("Select * from Formation Left Join Inscription ON Formation.ForId = Inscription.ForId WHERE Inscription.ForId IS NULL").ToList();
        }

        public Inscription GetInscById(string id)
        {            
                return Inscription.Where(f => f.InscId.Equals(id)).DefaultIfEmpty().First();
            
        }
        public void addFor(Formation formation)
        {
            Formation.Add(formation);
        }

        public void deleteInsc(string id)
        {
            Inscription.Remove(GetInscById(id));
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Formation>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Formation>()
                .Property(e => e.Des)
                .IsUnicode(false);

            modelBuilder.Entity<Formation>()
                .Property(e => e.Formateur)
                .IsUnicode(false);

            modelBuilder.Entity<Inscription>()
                .Property(e => e.Title)
                .IsUnicode(false);
        }
        
    }
}


