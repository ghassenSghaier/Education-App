namespace EducationWeb.DOMAIN
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;        

    [Table("Formation")]
    public partial class Formation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Formation()
        {
            Inscription = new HashSet<Inscription>();
        }

        public Formation(string forId, string title, DateTime date, string des, string formateur)
        {
            ForId = forId;
            Title = title;
            Date = date;
            Des = des;
            Formateur = formateur;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ForId { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        public DateTime Date { get; set; }

        [StringLength(50)]
        public string Des { get; set; }

        [StringLength(50)]
        public string Formateur { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inscription> Inscription { get; set; }
    }
}
