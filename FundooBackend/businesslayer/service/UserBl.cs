using businesslayer.Interface;
using commonlayer.Model;
using Microsoft.AspNetCore.Mvc;
using repolayer.Entity;
using repolayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace businesslayer.service
{
    public class UserBl : IUserBl
    {
        IUserRl userRl;

        public UserBl(IUserRl userRl)
        {
            this.userRl = userRl;
        }

        public UserEntity Registration(UserRegistration userRegistration)
        {
            try
            {
                return userRl.Registration(userRegistration);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string Login(UserLogin userLogin)
        {
            try
            {
                return userRl.Login(userLogin);
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
                 return userRl.ForgetPassword(email);
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
                return userRl.ResetPass(email,password, confirm);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
