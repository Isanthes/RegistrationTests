using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
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

        public static Dictionary<string, string> ReadConfig(string configFilePath)
        {
            var configData = new Dictionary<string, string>();
            foreach (var line in File.ReadAllLines(configFilePath))
            {
                string[] values = line.Split('=');
                configData.Add(values[0].Trim(), values[1].Trim());
            }
            return configData;
        }

    }
}
