using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Framework
{
    public class UrlRewrite
    {
        public class Admin
        {
            // Must be 'const' so the compiler can evaluate it inside attributes
            public const string CourseList = "admin/course-list";
            public const string CourseDetail = "admin/course-detail";
        }
        public class Account
        {
            public const string Login = "login";
        }
    }
}
