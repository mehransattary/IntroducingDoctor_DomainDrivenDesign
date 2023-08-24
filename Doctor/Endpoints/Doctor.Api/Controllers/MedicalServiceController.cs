using Common.AspNetCore;
using Doctor.Application.MedicalServiceAgg.Create;
using Doctor.Application.MedicalServiceAgg.Edit;
using Doctor.Presentation.Facade.MedicalServiceAgg;
using Doctor.Query.MedicalServiceAgg.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Doctor.Api.Controllers;

public class MedicalServiceController :  ApiController
{
    private readonly IMedicalServiceFacade _facade;

    public MedicalServiceController(IMedicalServiceFacade facade)
    {
        _facade = facade;
    }

    [HttpGet]
    public async Task<ApiResult<List<MedicalServiceDto>>> GetList()
    {
        var result = await _facade.GetList();
        return QueryResult(result);
    }

    [HttpGet("{id}")]
    public async Task<ApiResult<MedicalServiceDto?>> GetById(long id)
    {
        var result = await _facade.GetById(id);
        return QueryResult(result);
    }

    [HttpPost]
    public async Task<ApiResult> Create([FromForm] Create_MedicalService_Command command)
    {
        var result = await _facade.Create(command);
        return CommandResult(result);
    }
    [HttpPut]
    public async Task<ApiResult<long>> Edit([FromForm] Edit_MedicalService_Command command)
    {
        var result = await _facade.Edit(command); //OptionResult<long>
        var r= CommandResult(result);
        return r;
    }

    [HttpDelete("{medicalServiceId}")]
    public async Task<ApiResult> Delete(long medicalServiceId)
    {
        var result = await _facade.Remove(medicalServiceId);
        return CommandResult(result);
    }
}
