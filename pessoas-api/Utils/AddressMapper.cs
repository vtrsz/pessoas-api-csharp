using pessoas_api.Dtos.Request;
using pessoas_api.Dtos.Response;
using pessoas_api.Entities;

namespace pessoas_api.Utils
{
    public class AddressMapper
    {
        public static Address ToEntity(Person person, AddressAttachedToPersonDto addressAttachedToPersonDto)
        {
            Address address = new()
            {
                Street = addressAttachedToPersonDto.Street,
                Number = addressAttachedToPersonDto.Number,
                City = addressAttachedToPersonDto.City,
                State = addressAttachedToPersonDto.State,
                Cep = addressAttachedToPersonDto.Cep,
                Main = addressAttachedToPersonDto.Main,
                Person = person
            };

            return address;
        }

        public static Address ToEntity(Person person, AddressCreationDto addressCreationDto)
        {
            Address address = new()
            {
                Street = addressCreationDto.Street,
                Number = addressCreationDto.Number,
                City = addressCreationDto.City,
                State = addressCreationDto.State,
                Cep = addressCreationDto.Cep,
                Main = addressCreationDto.Main,
                Person = person
            };

            return address;
        }

        public static AddressAttachedToPersonResponseDto ToResponseDto(Address address, bool attachedToPerson)
        {
            AddressAttachedToPersonResponseDto addressAttachedToPersonResponseDto = new()
            {
                Id = address.Id,
                Street = address.Street,
                Number = address.Number,
                City = address.City,
                State = address.State,
                Cep = address.Cep,
                Main = address.Main
            };

            return addressAttachedToPersonResponseDto;
        }

        public static AddressResponseDto ToResponseDto(Address address)
        {
            AddressResponseDto addressResponseDto = new()
            {
                Id = address.Id,
                Street = address.Street,
                Number = address.Number,
                City = address.City,
                State = address.State,
                Cep = address.Cep,
                Main = address.Main,
                PersonId = address.PersonId,
            };

            return addressResponseDto;
        }
    }
}
