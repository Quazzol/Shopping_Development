
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Quadro.Account.Infrastructure.Identity;

public class TokenProvider : ITokenProvider
{
    public const string TokenKey = "ShoppingDevelopment-key!_<Quadro>_<1234**!>*w4hooy!<>4";


    public (string token, DateTime validTo) CreateToken(User user)
    {

        var tokenHandler = new JwtSecurityTokenHandler();
        var claims = new List<Claim>()
        {
            new(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            new("userid",user.Id.ToString()),
            new("username",user.UserName),
            new(JwtRegisteredClaimNames.Sub,user.Credentials.Address.ToString()),
            new(JwtRegisteredClaimNames.Email,user.Credentials.Address.ToString()),
            new("password",user.Credentials.Password),
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(120),
            //Issuer = "",
            //Audience = "",
            SigningCredentials = new SigningCredentials(GetSecurityKey(), SecurityAlgorithms.HmacSha256)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return (tokenHandler.WriteToken(token), token.ValidTo);
    }

    public static SecurityKey GetSecurityKey() => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenKey));


}

