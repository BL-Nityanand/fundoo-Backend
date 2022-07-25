using businesslayer.Interface;
using commonlayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using repolayer.Entity;
using repolayer.Context;
using System.Security.Claims;

namespace FundooBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserBl iuserBl;
        //private readonly IJwtAuth jwtAuth;

        public UserController(IUserBl iuserBl)
        {
            this.iuserBl = iuserBl;
        }
        [HttpPost("registration")]
        public IActionResult Registration (UserRegistration userRegistration)
        {
            try
            {
                var result = iuserBl.Registration(userRegistration);
                if (result != null)
                {
                    return this.Ok(new { 
                        success = true,
                        message= "Registration is Successfull",
                        response = result
                    });
                }
                else
                {
                    return this.BadRequest(new
                    {
                        success = false,
                        message = "Registration is unsuccessfull",
                    
                    });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost("login")]

        public IActionResult Login(UserLogin userLogin)
        {
            try
            {
                //var result = iuserBl.Login(userLogin);

                var token = iuserBl.Login(userLogin);

                if (token == null)
                {
                    return this.Unauthorized(new
                    {
                        success = false,
                        message = "Invalid Email or Password",

                    });
                    
                }

                return this.Ok(new
                {
                    success = true,
                    message = "login succsessfull",
                    token = token

                });
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost("forget")]
        public IActionResult Forget(string email)
        {
            try
            {
                //var result = iuserBl.Login(userLogin);

                var token = iuserBl.ForgetPassword(email);

                if (token == null)
                {
                    return this.BadRequest(new
                    {
                        success = false,
                        message = "mail not sent",

                    });

                }

                return this.Ok(new
                {
                    success = true,
                    message = "Reset mail sent successfull"

                });
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost("reset")]
        [Authorize]
        public IActionResult ResetPass(string password, string confirm)
        {
            //FundooContext fundooContext;
            try
            {

                var email = User.FindFirst(ClaimTypes.Email).Value;
                var result = iuserBl.ResetPass(email,password, confirm);

                if (result == null)
                {
                    return this.BadRequest(new
                    {
                        success = false,
                        message = "try again",

                    });

                }

                return this.Ok(new
                {
                    success = true,
                    message = "password has been changed",
                    result = result

                });
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
