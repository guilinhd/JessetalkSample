using System;
using Microsoft.Extensions.Configuration;

namespace CommandLineSample
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddCommandLine(args);

            IConfigurationRoot configuration = builder.Build();
            Console.WriteLine($"name is:{configuration["name"]}");
            Console.WriteLine($"age is:{configuration["age"]}");

            Console.ReadKey();
        }
    }
}
