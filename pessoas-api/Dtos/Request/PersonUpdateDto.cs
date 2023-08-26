using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace pessoas_api.Dtos.Request
{
    public class PersonUpdateDto
    {
        public PersonUpdateDto(long id, string name, DateTime birthDate, List<AddressAttachedToPersonDto> addresses)
        {
            Id = id;
            Name = name;
            BirthDate = birthDate;
            Addresses = addresses;
        }

        public PersonUpdateDto()
        {
        }

        [Required(ErrorMessage = "id cannot be null")]
        public long Id { get; set; }

        [Required(ErrorMessage = "name cannot be blank")]
        public string Name { get; set; }

        [Required(ErrorMessage = "birthDate cannot be blank")]
        [JsonConverter(typeof(DateOnlyConverter))]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "addresses cannot be null")]
        public List<AddressAttachedToPersonDto> Addresses { get; set; }
    }
}
