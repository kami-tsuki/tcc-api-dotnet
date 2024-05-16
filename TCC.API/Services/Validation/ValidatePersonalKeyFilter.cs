using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using TCC.API.Data;
using static TCC.API.Services.TokenService;

namespace TCC.API.Services.Validation
{
    public class ValidatePersonalKeyFilter : IAsyncAuthorizationFilter
    {
        private readonly TccDbContext _context;
        private readonly IConfiguration _configuration;

        public ValidatePersonalKeyFilter(TccDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var endpoint = context.HttpContext.GetEndpoint();
            if (endpoint != null)
            {
                if (endpoint.Metadata.GetMetadata<IAllowAnonymous>() != null) return;
                if (endpoint.Metadata.GetMetadata<IAuthorizeData>() == null) return;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var authHeader = context.HttpContext.Request.Headers[TokenService.AuthHeader].ToString();
            var tokenString = authHeader.Replace("Bearer ", "");
            var claimsPrincipal = tokenHandler.ValidateToken(
                tokenString,
                ValidationParameters(_configuration),
                out var validatedToken);
            var jwtToken = validatedToken as JwtSecurityToken;
            var personalKey = jwtToken.Claims.First(c => c.Type == PersonalKeyClaim).Value;
            var userId = jwtToken.Claims.First(c => c.Type == UserIdClaim).Value;
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id.ToString() == userId);
            if (user == null || user.PersonalKey != personalKey) context.Result = new UnauthorizedResult();
        }
    }
}