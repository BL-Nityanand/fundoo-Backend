using commonlayer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using repolayer.Context;
using repolayer.Entity;
using repolayer.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace repolayer.service
{
    public class UserRl : IUserRl
    {
        FundooContext fundooContext;
        //private readonly string key;
        //public  string _secret;
        //public  string _expDate;

        private readonly IConfiguration config;

        public UserRl(FundooContext fundooContext, IConfiguration config)
        {
            this.fundooContext = fundooContext;
            this.config = config;
        }

        public UserEntity Registration(UserRegistration userRegistration)
        {
            try
            {
                UserEntity userEntity = new UserEntity();
                userEntity.firstName = userRegistration.firstName;
                userEntity.lastName = userRegistration.lastName;
                userEntity.email = userRegistration.email;
                userEntity.password = userRegistration.password;

                fundooContext.Users.Add(userEntity);
                int result = fundooContext.SaveChanges();
                if (result > 0)
                {
                    return userEntity;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string JwtMethod(string email, long id)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(this.config[("Jwt:key")]));

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                new Claim[]
                {
                        new Claim(ClaimTypes.Email, email),
                        new Claim("id", id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(20),
                SigningCredentials = new SigningCredentials(
                tokenKey, SecurityAlgorithms.HmacSha256Signature)
            };
            //4. Create Token
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // 5. Return Token from method
            return tokenHandler.WriteToken(token);
        }

        public string Login(UserLogin userLogin)
        {
            try
            {
                var login = fundooContext.Users.SingleOrDefault(x => x.email == userLogin.email && x.password == userLogin.password);

                if (login != null)
                {
                    var token = JwtMethod(login.email, login.userid);
                    return token;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public string ForgetPassword(string email)
        {
            try
            {
                var emailCheck = fundooContext.Users.FirstOrDefault(e => e.email == email);
                if (emailCheck != null)
                {
                    var token = JwtMethod(emailCheck.email, emailCheck.userid);
                    new MsmqModel().MsmqSend(token);
                    return token;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool ResetPass(string email, string password, string confirm)
        {
            try
            {
                var emailCheck = fundooContext.Users.FirstOrDefault(e => e.email == email);
                if (password.Equals(confirm))
                {
                    //var token = JwtMethod(emailCheck.email, emailCheck.userid);
                    //new MsmqModel().MsmqSend(token);
                    //return token;

                    UserEntity user = fundooContext.Users.Where(e => e.email == email).FirstOrDefault();
                    user.password = confirm;
                    fundooContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
