using Example.BusinessLogic.DTO;

namespace Example.BusinessLogic.Services;

public interface IContactService
{
    IEnumerable<ContactDto> GetContactsPage(int page, int pageSize);

    Task<ContactDto?> GetContactByIdAsync(Guid id);

    Task AddContactAsync(ContactDto contactDto);

    Task UpdateContactAsync(ContactDto contactDto);

    Task DeleteContactAsync(ContactDto contactDto);

    Task<int> ContactCount();
}