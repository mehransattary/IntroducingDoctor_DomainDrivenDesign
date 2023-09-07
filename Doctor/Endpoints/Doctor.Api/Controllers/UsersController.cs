﻿using AutoMapper;
using Common.AspNetCore;
using Doctor.Api.ViewModels.Users;
using Doctor.Application.UserAgg.ChangePassword;
using Doctor.Application.UserAgg.Create;
using Doctor.Application.UserAgg.Edit;
using Doctor.Presentation.Facade.UserAgg;
using Doctor.Query.UserAgg.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Doctor.Api.Controllers;


[Authorize]
public class UsersController : ApiController
{
    private readonly IUserFacade _userFacade;
    private readonly IMapper _mapper;
    public UsersController(IUserFacade userFacade, IMapper mapper)
    {
        _userFacade = userFacade;
        _mapper = mapper;
    }
    //[PermissionChecker(Permission.User_Management)]
    [HttpGet]
    public async Task<ApiResult<UserFilterResult>> GetUsers([FromQuery] UserFilterParams filterParams)
    {
        var result = await _userFacade.GetUserByFilter(filterParams);
        return QueryResult(result);
    }
    [HttpGet("Current")]
    public async Task<ApiResult<UserDto>> GetCurrentUser()
    {
        var result = await _userFacade.GetUserById(User.GetUserId());
        return QueryResult(result);
    }

    //[PermissionChecker(Permission.User_Management)]
    [HttpGet("{userId}")]
    public async Task<ApiResult<UserDto?>> GetById(long userId)
    {
        var result = await _userFacade.GetUserById(userId);
        return QueryResult(result);
    }

    //[PermissionChecker(Permission.User_Management)]
    [HttpPost]
    public async Task<ApiResult> Create(CreateUserCommand command)
    {
        var result = await _userFacade.CreateUser(command);
        return CommandResult(result);
    }

    [HttpPut("ChangePassword")]
    public async Task<ApiResult> ChangePassword(ChangePasswordViewModel command)
    {
        var changePasswordModel = _mapper.Map<ChangeUserPasswordCommand>(command);
        changePasswordModel.UserId = User.GetUserId();
        var result = await _userFacade.ChangePassword(changePasswordModel);
        return CommandResult(result);
    }

    [HttpPut("Current")]
    public async Task<ApiResult> EditUser([FromForm] EditUserViewModel command)
    {
        var commandModel = new EditUserCommand(User.GetUserId(), command.Avatar, command.Name, command.Family,
            command.PhoneNumber, command.Email, command.Gender);

        var result = await _userFacade.EditUser(commandModel);
        return CommandResult(result);
    }

    //[PermissionChecker(Permission.User_Management)]
    [HttpPut]
    public async Task<ApiResult> Edit([FromForm] EditUserCommand command)
    {
        var result = await _userFacade.EditUser(command);
        return CommandResult(result);
    }
}