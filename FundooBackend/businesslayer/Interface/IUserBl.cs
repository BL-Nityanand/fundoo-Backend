using commonlayer.Model;
using Microsoft.AspNetCore.Mvc;
using repolayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace businesslayer.Interface
{
    public interface IUserBl
    {
        public UserEntity Registration(UserRegistration userRegistration);
        public string Login(UserLogin userLogin);
        public string ForgetPassword(string email);
        public bool ResetPass(string email, string password, string confirm);

    }
}
