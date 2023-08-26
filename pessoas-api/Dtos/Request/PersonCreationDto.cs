using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace pessoas_api.Dtos.Request
{
    public class PersonCreationDto
    {
        public PersonCreationDto(string name, DateTime birthDate, List<AddressAttachedToPersonDto> addresses)
        {
            Name = name;
            BirthDate = birthDate;
            Addresses = addresses;
        }

        public PersonCreationDto()
        {
        }

        [Required(ErrorMessage = "name cannot be blank")]
        public string Name { get; set; }

        [Required(ErrorMessage = "birthDate cannot be blank")]
        [JsonConverter(typeof(DateOnlyConverter))]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "addresses cannot be null")]
        public List<AddressAttachedToPersonDto> Addresses { get; set; }
    }
}
