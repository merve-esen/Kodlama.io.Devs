﻿namespace Core.Security.Dtos;

public class UserForLoginDto
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string? AuthenticatorCode { get; set; }

    public UserForLoginDto()
    {
        Email = string.Empty;
        Password = string.Empty;
    }
}