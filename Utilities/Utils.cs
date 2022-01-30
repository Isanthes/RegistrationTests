using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistrationTests.Utilities
{
    class Utils
    {

        const string protocol = "http";
        const string hostname = "86.121.249.150";
        const string port = "4999";
        const string path = "/#/";

        public static string GetUrl()
        {
            return String.Format("{0}://{1}:{2}{3}", protocol, hostname, port, path);
        }

    }
}
