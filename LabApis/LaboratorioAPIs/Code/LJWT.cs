using JWT.Algorithms;
using JWT.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorioAPIs.Repository
{
    public class LJWT
    {
        
        public async Task<string> GenerarJWT(IFormFile file, string llave)
        {
            var lectura = new StringBuilder();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                    lectura.AppendLine(await reader.ReadLineAsync()); 
            }
            var json = lectura.ToString();
            var claims = await CreateClaimsIdentities(json);
            var token = new JwtBuilder()
              .WithAlgorithm(new HMACSHA256Algorithm())
              .WithSecret(llave)
              .AddClaim("userdata", json)
              .Build();
            await Console.Out.WriteLineAsync(token);

            return token;
        }

        public static Task<ClaimsIdentity> CreateClaimsIdentities(string json)
        {
            ClaimsIdentity claimsIdentity = new ClaimsIdentity();
            claimsIdentity.AddClaim(new Claim("userdata", json));
            return Task.FromResult(claimsIdentity);
        }
    }
}