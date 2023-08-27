﻿
using Common.Application;
using FluentValidation.Validators;
using Microsoft.AspNetCore.Http;

namespace Doctor.Application.AboutUsAgg.Edit;

public record Edit_ContactUs_Command(long Id,string Title, IFormFile ImageFile, string? Description) : IBaseCommand;
