using System.ComponentModel.DataAnnotations;

namespace pessoas_api.Dtos.Response
{
    public class AddressAttachedToPersonResponseDto
    {
        public AddressAttachedToPersonResponseDto(long id, string street, string number, string city, string state, string cep, bool main)
        {
            Id = id;
            Street = street;
            Number = number;
            City = city;
            State = state;
            Cep = cep;
            Main = main;
        }

        public AddressAttachedToPersonResponseDto()
        {
        }

        [Required(ErrorMessage = "id cannot be blank")]
        public long Id { get; set; }

        [Required(ErrorMessage = "street cannot be null")]
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
    }
}
