using pessoas_api.Dtos.Request;
using pessoas_api.Dtos.Response;

namespace pessoas_api.Services
{
    public interface IAddressService
    {
        Task<AddressResponseDto> CreateAsync(AddressCreationDto addressCreationDto);

        Task<AddressResponseDto> GetAsync(long id);

        Task<List<AddressResponseDto>> GetAllAsync();

        Task<AddressResponseDto> UpdateAsync(AddressUpdateDto addressUpdateDto);

        Task<bool> DeleteAsync(long id);
    }
}
