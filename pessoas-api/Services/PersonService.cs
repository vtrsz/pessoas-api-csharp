using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using pessoas_api.Dtos.Request;
using pessoas_api.Dtos.Response;
using pessoas_api.Entities;
using pessoas_api.Exceptions;
using pessoas_api.Repositories;
using pessoas_api.Utils;

namespace pessoas_api.Services
{
    public class PersonService : IPersonService
    {
        private readonly PersonRepository _repository;

        public PersonService(PersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<PersonResponseDto> CreateAsync(PersonCreationDto personCreationDto)
        {
            if (personCreationDto == null)
            {
                throw new ArgumentException("a person cannot be null");
            }
            if (personCreationDto.Addresses.IsNullOrEmpty())
            {
                throw new BusinessRuleException("a person must have at least one address");
            }

            int mainAddressCount = personCreationDto.Addresses.Count(address => address.Main);

            if (mainAddressCount > 1)
            {
                throw new MultipleMainAddressException("a person cannot have multiple main addresses");
            }
            else if (mainAddressCount == 0)
            {
                throw new BusinessRuleException("a person needs to have a main address");
            }

            Person person = PersonMapper.ToEntity(personCreationDto);

            var result = await _repository.AddAsync(person);
            if (result == 0)
            {
                throw new NotSavedToDatabaseException("person was not saved to database");
            }

            return PersonMapper.ToResponseDto(person);
        }

        public async Task<PersonResponseDto> GetAsync(long id)
        {
            var person = await _repository.GetByIdAsync(id);

            return person is null ? throw new NotFoundException("person was not found") : PersonMapper.ToResponseDto(person);
        }

        public async Task<List<PersonResponseDto>> GetAllAsync()
        {
            var people = await _repository.GetAllAsync();

            return people.IsNullOrEmpty() ? new List<PersonResponseDto>() : people
                .Select(PersonMapper.ToResponseDto)
                .ToList();
        }

        public async Task<PersonResponseDto> UpdateAsync(PersonUpdateDto personUpdateDto)
        {
            if (personUpdateDto == null)
            {
                throw new ArgumentException("a person cannot be null");
            }
            if (personUpdateDto.Addresses.IsNullOrEmpty())
            {
                throw new BusinessRuleException("a person must have at least one address");
            }

            int mainAddressCount = personUpdateDto.Addresses.Count(address => address.Main);

            if (mainAddressCount > 1)
            {
                throw new MultipleMainAddressException("a person cannot have multiple main addresses");
            }
            else if (mainAddressCount == 0)
            {
                throw new BusinessRuleException("a person needs to have a main address");
            }

            var personToUpdate = await _repository.GetByIdAsync(personUpdateDto.Id) ?? throw new NotFoundException("person was not found");

            personToUpdate.Name = personUpdateDto.Name;
            personToUpdate.BirthDate = personUpdateDto.BirthDate;

            personToUpdate.Addresses.Clear();

            personToUpdate.Addresses = personUpdateDto.Addresses
                .Select((addressUpdateAttachedToPersonDto) => AddressMapper.ToEntity(personToUpdate, addressUpdateAttachedToPersonDto))
                .ToList();

            var result = await _repository.UpdateAsync(personToUpdate);
            if (result == 0)
            {
                throw new NotSavedToDatabaseException("person was not updated to database");
            }

            return PersonMapper.ToResponseDto(personToUpdate);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var person = await _repository.GetByIdAsync(id);

            if (person is null)
            {               
                throw new NotFoundException("person was not found");
            }

            int result = await _repository.DeleteAsync(person);
            if (result == 0)
            {
                throw new NotSavedToDatabaseException("person was not deleted from database");
            }

            return true;
        }
    }
}
