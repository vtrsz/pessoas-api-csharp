using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace pessoas_api.Entities
{
    public class Address : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column(TypeName = "varchar(255)")]
        [Required]
        public string Street { get; set; }

        [Column(TypeName = "varchar(10)")]
        [Required]
        public string Number { get; set; }

        [Column(TypeName = "varchar(255)")]
        [Required]
        public string City { get; set; }

        [Column(TypeName = "varchar(255)")]
        [Required]
        public string State { get; set; }

        [Column(TypeName = "varchar(10)")]
        [Required]
        public string Cep { get; set; }

        [Required]
        public bool Main { get; set; }

        [ForeignKey("Person")]
        public long PersonId { get; set; }

        public Person Person { get; set; }
    }
}
