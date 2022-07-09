using AllInOneWithAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AllInOneWithAuthentication
{
    public class webapi_security
    {
        //In this file i just have done one thing to validate the username or password that they exist or not and i use bool that if exist then return true otherwise false
        public static bool ValidateUsers(string username, string user_password)
            // bool is keyword return two values just
        {
            Entities db = new Entities();
            var result = db.users.Where(x =>x.username == username && x.password == user_password).FirstOrDefault();
            // FirstOrDefault returns the first element of the querry or default value if element is not there.
            if (result != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}