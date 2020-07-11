﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicJwtAuthentication.Constants
{
    public class Authorization
    {
        public enum Roles
        {
            Administrator,
            Moderator,
            User
        }
        public const string default_username = "admin";
        public const string default_email = "admin@gmail.com";
        public const string default_password = "Password@1234";
        public const Roles default_role = Roles.User;
    }
}
