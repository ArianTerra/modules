using Example.BusinessLogic.DTO;
using Example.BusinessLogic.Services;
using Example.Presentation.ViewModels;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace Example.Presentation.Controllers;

public class ContactsController : Controller
{
    private readonly IContactService _contactService;

    private readonly IValidator<ContactDto> _validator;
    public ContactsController(IContactService contactService, IValidator<ContactDto> validator)
    {
        _contactService = contactService;
        _validator = validator;
    }

    public async Task<IActionResult> Index(int page = 1, int pageSize = 5)
    {
        var itemsCount = await _contactService.ContactCount();
        var pageCount = (int)Math.Ceiling((double)itemsCount / pageSize);
        if (pageCount == 0)
        {
            pageCount = 1;
        }

        if (page <= 0 || page > pageCount)
        {
            return BadRequest();
        }

        var viewModel = new ContactViewModel
        {
            Contacts = _contactService.GetContactsPage(page, pageSize).ToList(),
            Page = page,
            PageSize = pageSize,
            PageCount = pageCount
        };

        return View(viewModel);
    }

    public IActionResult AddContact()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddContact(ContactDto contactDto)
    {
        var validationResult = await _validator.ValidateAsync(contactDto);
        if (!validationResult.IsValid)
        {
            validationResult.AddToModelState(this.ModelState);
            return View(contactDto);
        }

        await _contactService.AddContactAsync(contactDto);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> EditContact(Guid id)
    {
        var contact = await _contactService.GetContactByIdAsync(id);

        if (contact == null)
        {
            return BadRequest();
        }

        return View(contact);
    }

    [HttpPost]
    public async Task<IActionResult> EditContact(ContactDto contactDto)
    {
        if (contactDto == null)
        {
            return BadRequest();
        }

        var validationResult = await _validator.ValidateAsync(contactDto);
        if (!validationResult.IsValid)
        {
            validationResult.AddToModelState(this.ModelState);
            return View(contactDto);
        }

        await _contactService.UpdateContactAsync(contactDto);

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> DeleteContact(Guid id)
    {
        var contact = await _contactService.GetContactByIdAsync(id);

        if (contact == null)
        {
            return BadRequest();
        }

        await _contactService.DeleteContactAsync(contact);

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> ContactDetails(Guid id)
    {
        var contact = await _contactService.GetContactByIdAsync(id);

        if (contact == null)
        {
            return BadRequest();
        }

        return View(contact);
    }
}