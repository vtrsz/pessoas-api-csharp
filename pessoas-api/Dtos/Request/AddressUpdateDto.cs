using System.ComponentModel.DataAnnotations;

namespace pessoas_api.Dtos.Request
{
    public class AddressUpdateDto
    {
        public AddressUpdateDto(long id, string street, string number, string city, string state, string cep, bool main, long personId)
        {
            Id = id;
            Street = street;
            Number = number;
            City = city;
            State = state;
            Cep = cep;
            Main = main;
            PersonId = personId;
        }

        [Required(ErrorMessage = "Id cannot be null")]
        public long Id { get; set; }

        [Required(ErrorMessage = "street cannot be blank")]
        public string Street { get; set; }

        [Required(ErrorMessage = "number cannot be blank")]
        public string Number { get; set; }

        [Required(ErrorMessage = "city cannot be blank")]
        public string City { get; set; }

        [Required(ErrorMessage = "state cannot be blank")]
        public string State { get; set; }

        [Required(ErrorMessage = "cep cannot be blank")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "main cannot be null")]
        public bool Main { get; set; }

        [Required(ErrorMessage = "personId cannot be null")]
        public long PersonId { get; set; }
    }
}
