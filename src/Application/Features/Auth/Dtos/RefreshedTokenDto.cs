using Core.Security.JWT;
using Domain.Entities;

namespace Application.Features.Auth.Dtos;

public class RefreshedTokenDto
{
    public AccessToken AccessToken { get; set; }
    public RefreshToken RefreshToken { get; set; }
}
