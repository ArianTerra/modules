using Example.BusinessLogic.DTO;

namespace Example.Presentation.ViewModels;

public class ContactViewModel
{
    public List<ContactDto> Contacts { get; set; }

    public int Page { get; set; }

    public int PageSize { get; set; }

    public int PageCount { get; set; }
}