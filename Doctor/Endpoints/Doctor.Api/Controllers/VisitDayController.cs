using Common.AspNetCore;
using Doctor.Application.VisitAgg.AddTime;
using Doctor.Application.VisitAgg.Create;
using Doctor.Application.VisitAgg.Edit;
using Doctor.Application.VisitAgg.EditTime;
using Doctor.Presentation.Facade.VisitAgg;
using Doctor.Query.VisitAgg.DTOs;
using Microsoft.AspNetCore.Mvc;
namespace Doctor.Api.Controllers;

public class VisitDayController : ApiController
{
    private readonly IVisitDayFacade _facade;

    public VisitDayController(IVisitDayFacade facade)
    {
        _facade = facade;
    }
    [HttpGet]
    public async Task<ApiResult<List<VisitDayDto>>> GetList()
    {
        var result = await _facade.GetList();
        return QueryResult(result);
    }

    [HttpGet("{id}")]
    public async Task<ApiResult<VisitDayDto?>> GetById(long id)
    {
        var result = await _facade.GetById(id);
        return QueryResult(result);
    }

    [HttpPost]
    public async Task<ApiResult> Create([FromForm] Create_VisitDay_Command command)
    {
        var result = await _facade.Create(command);
        return CommandResult(result);
    }
    [HttpPut]
    public async Task<ApiResult<long>> Edit([FromForm] Edit_VisitDay_Command command)
    {
        var result = await _facade.Edit(command); //OptionResult<long>
        var r = CommandResult(result);
        return r;
    }

    [HttpDelete("{visitDayId}")]
    public async Task<ApiResult> Delete(long visitDayId)
    {
        var result = await _facade.Remove(visitDayId);
        return CommandResult(result);
    }

    [HttpPost("AddTime")]
    public async Task<ApiResult> AddTime([FromForm] AddTime_Command command)
    {
        var result = await _facade.AddTime(command);
        return CommandResult(result);
    }

    [HttpPut("EditTime")]
    public async Task<ApiResult> EditTime([FromForm] EditTime_Command command)
    {
        var result = await _facade.EditTime(command);
        return CommandResult(result);
    }
}
