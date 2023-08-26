using pessoas_api.Dtos.Request;
using pessoas_api.Dtos.Response;

namespace pessoas_api.Services
{
    public interface IPersonService
    {
        Task<PersonResponseDto> CreateAsync(PersonCreationDto personCreationDto);

        Task<PersonResponseDto> GetAsync(long id);

        Task<List<PersonResponseDto>> GetAllAsync();

        Task<PersonResponseDto> UpdateAsync(PersonUpdateDto personUpdateDto);

        Task<bool> DeleteAsync(long id);
    }
}
