﻿
using lan2.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace lan2.Controllers.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context, IUserServices userServices)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
                attachUserToContext(context, userServices, token);

            await _next(context);
        }
        private void attachUserToContext(HttpContext context, IUserServices userServices, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("35a8fd2cc0e1d4444fd53e75362bd6b303ff4d296f928b4ffc15ad0a1ed901c2e9e3309ad2e3ba4f27977ac8eb0603923d69dbf67fa0a5b89825291bc680ff80bdeb5d98d11b06674ecd65331670f0c97f63eb2089a58745586e69885f0c5eab6defa51a8f76081e4751033b9626775ae5133b36d97768b85258c2eae05bdf6076a758d424fa8f9f3ec58f588c58f6f340b84c195fa6781797d53a9e70611d2d5f90f979482c9b3bcc51d8333817a6df559e83a48fe3159cd11277ac5699c93c4a4eb68757a052ff45db90e533354a26cd34b884478c6088e27cb0194ac398f365f9558f5db778e50d9608f5edc5d46e30d8d45958ed1fc0ccc9aa5ebd5f0a97");
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);
                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);
                context.Items["User"] = userServices.GetUserByID(userId);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
