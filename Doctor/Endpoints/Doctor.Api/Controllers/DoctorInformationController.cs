using Common.AspNetCore;
using Doctor.Application.DoctorInformationAgg.Create;
using Doctor.Application.DoctorInformationAgg.Edit;
using Doctor.Presentation.Facade.DoctorInformationAgg;
using Doctor.Query.DoctorInformationAgg.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Doctor.Api.Controllers;

public class DoctorInformationController : ApiController
{
    private readonly IDoctorInformationFacade _facade;

    public DoctorInformationController(IDoctorInformationFacade facade)
    {
        _facade = facade;
    }

    [HttpGet]
    public async Task<ApiResult<List<DoctorInformationDto>>> GetList()
    {
        var result = await _facade.GetList();
        return QueryResult(result);
    }

    [HttpGet("{id}")]
    public async Task<ApiResult<DoctorInformationDto?>> GetById(long id)
    {
        var result = await _facade.GetById(id);
        return QueryResult(result);
    }

    [HttpPost]
    public async Task<ApiResult> Create([FromForm] Create_DoctorInfo_Command command)
    {
        var result = await _facade.Create(command);
        return CommandResult(result);
    }
    [HttpPut]
    public async Task<ApiResult> Edit([FromForm] Edit_DoctorInfo_Command command)
    {
        var result = await _facade.Edit(command); //OptionResult<long>
        var r = CommandResult(result);
        return r;
    }

    [HttpDelete("{doctorInfoId}")]
    public async Task<ApiResult> Delete(long doctorInfoId)
    {
        var result = await _facade.Remove(doctorInfoId);
        return CommandResult(result);
    }
}



