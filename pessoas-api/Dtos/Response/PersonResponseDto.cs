using System.Text.Json.Serialization;

namespace pessoas_api.Dtos.Response
{
    public class PersonResponseDto
    {
        public PersonResponseDto(long id, string name, DateTime birthDate, List<AddressAttachedToPersonResponseDto> addresses)
        {
            Id = id;
            Name = name;
            BirthDate = birthDate;
            Addresses = addresses;
        }

        public PersonResponseDto()
        {
        }

        public long Id { get; set; }

        public string Name { get; set; }

        [JsonConverter(typeof(DateOnlyConverter))] 
        public DateTime BirthDate { get; set; }

        public List<AddressAttachedToPersonResponseDto> Addresses { get; set; }
    }
}
