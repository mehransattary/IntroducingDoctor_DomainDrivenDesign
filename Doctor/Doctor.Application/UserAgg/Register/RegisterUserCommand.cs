﻿using Common.Application;
using Common.Domain.ValueObjects;

namespace Doctor.Application.UserAgg.Register;

public class RegisterUserCommand : IBaseCommand
{
    public RegisterUserCommand(PhoneNumber phoneNumber, string password)
    {
        PhoneNumber = phoneNumber;
        Password = password;
    }
    public PhoneNumber PhoneNumber { get; private set; }
    public string Password { get; private set; }
}