using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyToDo.WebAPI.Common
{
	public static class JWTHelper
	{
		public static string createJwt(List<Claim> claims)
		{
			DateTime expires = DateTime.Now.AddDays(1);
			byte[] secBytes = Encoding.UTF8.GetBytes(key);
			var secKey = new SymmetricSecurityKey(secBytes);
			var credentials = new SigningCredentials(secKey, SecurityAlgorithms.HmacSha256Signature);
			var tokenDecriptor = new JwtSecurityToken(claims: claims, expires: expires,
				signingCredentials: credentials);
			string jwt = new JwtSecurityTokenHandler().WriteToken(tokenDecriptor);
			return jwt;
		}
		private readonly static string key = "asfhwaifhiwaogfiawgfi65165awfiuawfwafaw";
	}
}
