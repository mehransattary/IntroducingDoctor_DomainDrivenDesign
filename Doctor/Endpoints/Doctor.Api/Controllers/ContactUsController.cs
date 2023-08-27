using Common.AspNetCore;
using Doctor.Application.ContactUsAgg.Create;
using Doctor.Application.ContactUsAgg.Edit;
using Doctor.Presentation.Facade.ContactUsAgg;
using Doctor.Query.ContactUsAgg.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Doctor.Api.Controllers;

public class ContactUsController : ApiController
{
    private readonly IContactUsFacade _facade;

    public ContactUsController(IContactUsFacade facade)
    {
        _facade = facade;
    }
    [HttpGet]
    public async Task<ApiResult<ContactUsDto>> Get()
    {
        var result = await _facade.GetContactUs();
        return QueryResult(result);
    }



    [HttpPost]
    public async Task<ApiResult> Create([FromForm] Create_ContactUs_Command command)
    {
        var result = await _facade.Create(command);
        return CommandResult(result);
    }
    [HttpPut]
    public async Task<ApiResult> Edit([FromForm] Edit_ContactUs_Command command)
    {
        var result = await _facade.Edit(command); //OptionResult<long>
        var r = CommandResult(result);
        return r;
    }

    [HttpDelete("{contactUsId}")]
    public async Task<ApiResult> Delete(long contactUsId)
    {
        var result = await _facade.Remove(contactUsId);
        return CommandResult(result);
    }
}
