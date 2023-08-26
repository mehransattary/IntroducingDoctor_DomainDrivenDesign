using Common.AspNetCore;
using Doctor.Application.AboutUsAgg.Create;
using Doctor.Application.AboutUsAgg.Edit;
using Doctor.Application.DoctorInformationAgg.Create;
using Doctor.Application.DoctorInformationAgg.Edit;
using Doctor.Presentation.Facade.AboutUsAgg;
using Doctor.Presentation.Facade.DoctorInformationAgg;
using Doctor.Query.AboutUsAgg.DTOs;
using Doctor.Query.DoctorInformationAgg.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Doctor.Api.Controllers;

public class AboutUsController : ApiController
{
    private readonly IAboutUsFacade _facade;

    public AboutUsController(IAboutUsFacade facade)
    {
        _facade = facade;
    }
    [HttpGet]
    public async Task<ApiResult<AboutUsDto>> Get()
    {
        var result = await _facade.GetAboutUs();
        return QueryResult(result);
    }

 

    [HttpPost]
    public async Task<ApiResult> Create([FromForm] Create_AboutUs_Command command)
    {
        var result = await _facade.Create(command);
        return CommandResult(result);
    }
    [HttpPut]
    public async Task<ApiResult> Edit([FromForm] Edit_Aboutus_Command command)
    {
        var result = await _facade.Edit(command); //OptionResult<long>
        var r = CommandResult(result);
        return r;
    }

    [HttpDelete("{aboutusId}")]
    public async Task<ApiResult> Delete(long aboutusId)
    {
        var result = await _facade.Remove(aboutusId);
        return CommandResult(result);
    }
}
