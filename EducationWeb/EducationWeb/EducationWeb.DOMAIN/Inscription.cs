namespace EducationWeb.DOMAIN
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;    

    [Table("Inscription")]
    public partial class Inscription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string InscId { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        public DateTime? Date { get; set; }

        public string? ForId { get; set; }

        public virtual Formation Formation { get; set; }
    }
}
