using System.ComponentModel.DataAnnotations;

namespace pessoas_api.Dtos.Request
{
    public class AddressCreationDto
    {
        public AddressCreationDto(string street, string number, string city, string state, string cep, bool main, long personId)
        {
            Street = street;
            Number = number;
            City = city;
            State = state;
            Cep = cep;
            Main = main;
            PersonId = personId;
        }

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
