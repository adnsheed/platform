using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Platform.Core.Entities;
using Platform.Core.Interfaces;
using Platform.Core.Requests.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;

namespace Platform.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration configuration;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AuthService(IConfiguration configuration, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.configuration = configuration;
            this.httpContextAccessor = httpContextAccessor;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<ServiceResponse<UserLoginResponseDto>> Login(string username, string password)
        {
            var user = await userManager.Users
                .Include(u => u.UserRoles)
                .ThenInclude(r => r.Role)
                .FirstOrDefaultAsync(u => u.UserName.Equals(username.ToLower().Trim()));

            if(user == null) throw new AuthenticationException("Invalid Credentials.");


            var result = await signInManager.CheckPasswordSignInAsync(user, password, false);

            if (!result.Succeeded) throw new AuthenticationException("Invalid Credentials!");

            var token = await CreateToken(user);

            return new ServiceResponse<UserLoginResponseDto>
            {
                Data = new UserLoginResponseDto
                {
                    Id = user.Id,
                    Role = user.UserRoles.First().Role.Name,
                    Token = token
                }
            };
        }

        public ServiceResponse<int> Logout()
        {
            throw new NotImplementedException();
        }

        public async Task<string> CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
            };

            var roles = await userManager.GetRolesAsync(user);

            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var secret = configuration.GetSection("AppSettings:JwtSecret").Value;

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secret));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
