using Example.BusinessLogic.DTO;
using Example.DataAccess.DomainModels;
using Example.DataAccess.Repository;

namespace Example.BusinessLogic.Services;

public class ContactService : IContactService
{
    private readonly IGenericRepository<Contact> _repository;

    public ContactService(IGenericRepository<Contact> repository)
    {
        _repository = repository;
    }

    public IEnumerable<ContactDto> GetContactsPage(int page, int pageSize)
    {
        var contacts = _repository.FindAll(page: page, pageSize: pageSize);

        var contactsDto = new List<ContactDto>();
        foreach (var contact in contacts)
        {
            contactsDto.Add(new ContactDto()
            {
                Id = contact.Id,
                Name = contact.Name,
                Phone = contact.Phone
            });
        }

        return contactsDto;
    }

    public async Task<ContactDto?> GetContactByIdAsync(Guid id)
    {
        var contact = await _repository.FindFirstAsync(x => x.Id == id);

        if (contact == null)
        {
            return null;
        }

        return new ContactDto
        {
            Id = contact.Id,
            Name = contact.Name,
            Phone = contact.Phone
        };
    }

    public async Task AddContactAsync(ContactDto contactDto)
    {
        var contact = new Contact
        {
            Name = contactDto.Name,
            Phone = contactDto.Phone,
        };

        await _repository.AddAsync(contact);
    }

    public async Task UpdateContactAsync(ContactDto contactDto)
    {
        var contact = await _repository.FindFirstAsync(
            x => x.Id == contactDto.Id
        );

        if (contact == null)
        {
            throw new NullReferenceException("Not found");
        }

        contact.Name = contactDto.Name;
        contact.Phone = contactDto.Phone;

        await _repository.UpdateAsync(contact);
    }

    public async Task DeleteContactAsync(ContactDto contactDto)
    {
        var contact = await _repository.FindFirstAsync(
            x => x.Name == contactDto.Name && x.Phone == contactDto.Phone
        );

        if (contact == null)
        {
            throw new NullReferenceException("Contact not found for deletion");
        }

        await _repository.RemoveAsync(contact);
    }

    public async Task<int> ContactCount()
    {
        return await _repository.CountAsync();
    }
}