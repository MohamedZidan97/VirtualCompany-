using _VC.Application.Contents;
using _VC.Application.Features.Account.Commends.Register;
using _VC.Application.Features.Account.Queries;
using _VC.Application.Features.Account.Queries.GetToken;
using _VC.Application.IHelper.VC;
using _VC.Domain.Contents.Enums;
using _VC.Domain.Contents.Identites;
using _VC.Domain.Contents.TokenEntities;
using _VC.Domain.Data.VM;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Persistance.Repositories
{
    public class AuthService : IAuthService
    {
        private readonly JWT jwt;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IVirtualCompany createVC;

        public AuthService(IOptions<JWT> jwt, UserManager<ApplicationUser> userManager, IVirtualCompany createVC)
        {
            this.jwt = jwt.Value;
            this.userManager = userManager;
            this.createVC = createVC;
        }
        public async Task<AccountGeneralResponse> RegisterAsync(AccountRegisterRequest request)
        {
            if (await userManager.FindByEmailAsync(request.Email) is not null)
                return new AccountGeneralResponse { Message = "Email Is already Recoerd" };
            if (await userManager.FindByNameAsync(request.PhoneNumber) is not null)
                return new AccountGeneralResponse { Message = "Number Is already Recoerd" };


            var user = new ApplicationUser()
            {
                FullName = request.Name,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                UserName = request.Email,
            };


            var result = await userManager.CreateAsync(user, request.Password);


            // string roleName = Enum.TryParse(request.RoleName, out ERoles role) ? role.ToString() : ERoles.User.ToString();

            await userManager.AddToRoleAsync(user, request.RoleName);

            if (request.RoleName == ERoles.StokeHolder.ToString())
            {

                user.VirtualCompanyId = await createVC.CreateVirtualCompany();
            }

            //if (request.RoleName == RegisterEnum.StokeHolder.ToString())
            //{
            //    await userManager.AddToRoleAsync(user, RegisterEnum.StokeHolder.ToString());

            //    var VCid = await onDB.CreateVM();
            //    user.VirtualCompanyId = VCid;

            //}
            //else
            //    await userManager.AddToRoleAsync(user, RegisterEnum.User.ToString());


            if (!result.Succeeded)
            {
                var errors = String.Empty;

                foreach (var error in result.Errors)
                {
                    errors += $"{error.Description},";
                }
                return new AccountGeneralResponse { Message = errors };
            }

            // await userManager.AddToRoleAsync(user, "User");
            // await userManager.AddToRoleAsync(user, ERoles.Admin.ToString());

            var jwtSecurityToken = await CreateJwtToken(user);
            //var generateRefreshToken = await GenerateRefreshToken();
            //user.RefreshTokens.Add(generateRefreshToken);
            await userManager.UpdateAsync(user);



            var roles = await userManager.GetRolesAsync(user);
            return new AccountGeneralResponse
            {
                IsAuthenticed = true,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Roles = roles.ToList(),
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                VirtualCompanyId = user.VirtualCompanyId,
                FullName = user.FullName

                //RefreshToken = generateRefreshToken.Token,
                //RefreshTokenExpiration = generateRefreshToken.ExpiresOn
            };
        }

        public async Task<AccountGeneralResponse> GetTokenAsync(AccountGetTokenRequest request)
        {
            var response = new AccountGeneralResponse();
            var user = await userManager.FindByEmailAsync(request.Email);

            if (user is null || !await userManager.CheckPasswordAsync(user, request.Password))
            {
                response.Message = "Email Or Password is incorect!";
                return response;
            }

            var role = await userManager.GetRolesAsync(user);


            var jwtSecurityToken = await CreateJwtToken(user);
            response.IsAuthenticed = true;
            response.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            response.Email = user.Email;
            response.ExpiresOn = jwtSecurityToken.ValidTo;
            response.Roles = role.ToList();
            response.VirtualCompanyId = user.VirtualCompanyId;
            response.FullName = user.FullName;


            //if (user.RefreshTokens.Any(act => act.IsActive))
            //{
            //    var ActiveToken = user.RefreshTokens.First(act => act.IsActive);
            //    response.RefreshToken = ActiveToken.Token;
            //    response.RefreshTokenExpiration = ActiveToken.ExpiresOn;

            //}
            //else
            //{
            //    var newRefreshToken = await GenerateRefreshToken();

            //    response.RefreshToken = newRefreshToken.Token;
            //    response.RefreshTokenExpiration = newRefreshToken.ExpiresOn;

            //    user.RefreshTokens.Add(newRefreshToken);
            //    await userManager.UpdateAsync(user);
            //}

            return response;
        }
        //public async Task<AccountResponse> CheckOrCreateRefreshTokenAsync(string refreshToken)
        //{

        //    var user = await userManager.Users.SingleOrDefaultAsync(tok => tok.RefreshTokens.Any(rt => rt.Token == refreshToken));

        //    var response = new AccountResponse();
        //    if (user == null)
        //    {
        //        response.Message = "Invalid token";
        //        return response;
        //    }

        //    var exictToken = user.RefreshTokens.Single(t => t.Token == refreshToken);

        //    if (!exictToken.IsActive)
        //    {
        //        response.Message = "Inactive token";
        //        return response;
        //    }

        //    // make old refresh token Revoked
        //    exictToken.RevokedOn = DateTime.UtcNow;

        //    // Add the new Token 
        //    var newRefreshToken = await GenerateRefreshToken();
        //    user.RefreshTokens.Add(newRefreshToken);
        //    await userManager.UpdateAsync(user);

        //    // Generate Token Authorization
        //    var jwtToken = await CreateJwtToken(user);
        //    response.Token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

        //    // complete attributes of AuthModel
        //    response.IsAuthenticed = true;
        //    response.Email = user.Email;
        //    response.RefreshToken = newRefreshToken.Token;
        //    response.RefreshTokenExpiration = newRefreshToken.ExpiresOn;


        //    return response;

        //}


        #region Token
        //private async Task<RefreshToken> GenerateRefreshToken()
        //{
        //    var randomNumber = new byte[32];

        //    using var Generator = new RNGCryptoServiceProvider();
        //    Generator.GetBytes(randomNumber);

        //    return new RefreshToken
        //    {
        //        Token = Convert.ToBase64String(randomNumber),
        //        ExpiresOn = DateTime.UtcNow.AddMinutes(jwt.DurationInMinutes),
        //        CreatedOn = DateTime.UtcNow
        //    };
        //}

        private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
        {
            var userClaims = await userManager.GetClaimsAsync(user);
            var roles = await userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
                roleClaims.Add(new Claim("roles", role));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: jwt.Issuer,
                audience: jwt.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(jwt.DurationInMinutes),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }
        #endregion
    }
}
