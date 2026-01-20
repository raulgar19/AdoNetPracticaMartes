using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdoNetPracticaMartes.Helpers
{
    public class HelperConfiguration
    {
        public static IConfigurationRoot GetConfiguration()
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", false, true);

            IConfigurationRoot configuration = builder.Build();

            return configuration;
        }
    }
}