using pessoas_api.Dtos.Request;
using pessoas_api.Dtos.Response;
using pessoas_api.Entities;

namespace pessoas_api.Utils
{
    public class PersonMapper
    {
        public static Person ToEntity(PersonCreationDto personCreationDto)
        {
            Person person = new()
            {
                Name = personCreationDto.Name,
                BirthDate = personCreationDto.BirthDate
            };

            List<Address> addresses = personCreationDto.Addresses
                .Select((addressAttachedToPersonDto) => AddressMapper.ToEntity(person, addressAttachedToPersonDto))
                .ToList();

            person.Addresses = addresses;

            return person;
        }

        public static Person ToEntity(PersonUpdateDto personUpdateDto)
        {
            Person person = new()
            {
                Id = personUpdateDto.Id,
                Name = personUpdateDto.Name,
                BirthDate = personUpdateDto.BirthDate
            };

            List<Address> addresses = personUpdateDto.Addresses
                .Select((addressUpdateAttachedToPersonDto) => AddressMapper.ToEntity(person, addressUpdateAttachedToPersonDto))
                .ToList();

            person.Addresses = addresses;

            return person;
        }

        public static PersonResponseDto ToResponseDto(Person person)
        {
            PersonResponseDto personResponseDto = new()
            {
                Id = person.Id,
                Name = person.Name,
                BirthDate = person.BirthDate,
                Addresses = person.Addresses
                .Select((address) => AddressMapper.ToResponseDto(address, true))
                .ToList()
            };

            return personResponseDto;
        }
    }
}
