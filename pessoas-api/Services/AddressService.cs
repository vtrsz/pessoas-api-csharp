using Microsoft.IdentityModel.Tokens;
using pessoas_api.Dtos.Request;
using pessoas_api.Dtos.Response;
using pessoas_api.Entities;
using pessoas_api.Exceptions;
using pessoas_api.Repositories;
using pessoas_api.Utils;
using System;

namespace pessoas_api.Services
{
    public class AddressService : IAddressService
    {
        private readonly IRepository<Address> _repository;
        private readonly PersonRepository _personRepository;


        public AddressService(IRepository<Address> repository, PersonRepository personRepository)
        {
            _repository = repository;
            _personRepository = personRepository;
        }

        private static void RemoveMainAddress(Person person)
        {
            foreach (var address in person.Addresses)
            {
                if (address.Main)
                {
                    address.Main = false;
                }
            }
        }

        public async Task<AddressResponseDto> CreateAsync(AddressCreationDto addressCreationDto)
        {
            if (addressCreationDto == null)
            {
                throw new ArgumentException("a address cannot be null");
            }

            var person = await _personRepository.GetByIdAsync(addressCreationDto.PersonId);

            if (person is null)
            {
                throw new BusinessRuleException("a person with this personId was not found");
            }

            Address newAddress = AddressMapper.ToEntity(person, addressCreationDto);

            if (newAddress.Main)
            {
                RemoveMainAddress(person);
            }

            person.Addresses.Add(newAddress);

            var result = await _personRepository.SaveChangesAsync();

            if (result == 0)
            {
                throw new NotSavedToDatabaseException("address was not saved to database");
            }
            return AddressMapper.ToResponseDto(newAddress);
        }

        public async Task<AddressResponseDto> GetAsync(long id)
        {
            var address = await _repository.GetByIdAsync(id);

            return address is null ? throw new NotFoundException("address was not found") : AddressMapper.ToResponseDto(address);
        }

        public async Task<List<AddressResponseDto>> GetAllAsync()
        {
            var addresses = await _repository.GetAllAsync();

            return addresses.IsNullOrEmpty() ? new List<AddressResponseDto>() : addresses
                .Select(AddressMapper.ToResponseDto)
                .ToList();
        }

        public async Task<AddressResponseDto> UpdateAsync(AddressUpdateDto addressUpdateDto)
        {
            if (addressUpdateDto == null)
            {
                throw new ArgumentException("a address cannot be null");
            }

            var person = await _personRepository.GetByIdAsync(addressUpdateDto.PersonId);

            if (person is null)
            {
                throw new BusinessRuleException("a person with this personId was not found");
            }

            var existingAddress = person.Addresses.Find(a => a.Id == addressUpdateDto.Id);

            
            if (existingAddress is null)
            {
                throw new BusinessRuleException("a address with this id was not found");
            }

            if (!addressUpdateDto.Main)
            {
                if (existingAddress.Main)
                {
                    throw new BusinessRuleException("cannot change main address to non-main, a person needs a main address");
                }
            }

            if (addressUpdateDto.Main)
            {
                RemoveMainAddress(person);
            }

            existingAddress.Street = addressUpdateDto.Street;
            existingAddress.Number = addressUpdateDto.Number;
            existingAddress.City = addressUpdateDto.City;
            existingAddress.State = addressUpdateDto.State;
            existingAddress.Cep = addressUpdateDto.Cep;
            existingAddress.Main = addressUpdateDto.Main;

            var resultPerson = await _personRepository.SaveChangesAsync();
            if (resultPerson == 0)
            {
                throw new NotSavedToDatabaseException("address was not saved to database");
            }

            return AddressMapper.ToResponseDto(existingAddress);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var address = await _repository.GetByIdAsync(id);

            if (address is null)
            {
                throw new NotFoundException("address was not found");
            }

            var person = await _personRepository.GetByIdAsync(address.PersonId);

            if (person is null)
            {
                throw new BusinessRuleException("a person with this personId was not found");
            }

            if (person.Addresses.Count == 1)
            {
                throw new BusinessRuleException("a person needs at least one address");
            }

            if (address.Main)
            {
                throw new BusinessRuleException("cannot delete a main address");
            }

            int result = await _repository.DeleteAsync(address);
            if (result == 0)
            {
                throw new NotSavedToDatabaseException("address was not deleted from database");
            }

            return true;
        }
    }
}
