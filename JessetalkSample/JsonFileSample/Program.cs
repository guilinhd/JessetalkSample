using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;

namespace JsonFileSample
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", false, true);

            IConfiguration configuration = builder.Build();
            IConfiguration section = configuration.GetSection("Student");

            //json start
            //Console.WriteLine($"name is:{section["name"]}");
            //Console.WriteLine($"age is:{section["age"]}");
            //json end

            //bind start
            //var student = new Student();
            //section.Bind(student);

            //Console.WriteLine($"name is:{student.Name}");
            //Console.WriteLine($"age is:{student.Age}");
            //bind end


            IServiceCollection services = new ServiceCollection();
            //services.AddSingleton<Student>();
            services.Configure<Student>(section);

            var provider = services.BuildServiceProvider();

            //IOptions start

            //IOptions<Student> option = provider.GetRequiredService<IOptions<Student>>();
            //Console.WriteLine($"name is:{option.Value.Name}");
            //Console.WriteLine($"age is:{option.Value.Age}");
            //IOptions end

            //IOptionsSnapshot start 
            //IOptionsSnapshot<Student> snapshot = provider.GetRequiredService<IOptionsSnapshot<Student>>();
            //Console.WriteLine($"name is:{snapshot.Value.Name}");
            //Console.WriteLine($"age is:{snapshot.Value.Age}");

            //ChangeToken.OnChange(() => section.GetReloadToken(), () =>
            //{
            //    using (var scope = provider.CreateScope())
            //    {
            //        var s = scope.ServiceProvider.GetRequiredService<IOptionsSnapshot<Student>>();
            //        Console.WriteLine($"name is:{s.Value.Name}");
            //        Console.WriteLine($"age is:{s.Value.Age}");
            //    }
            //});
            //IOptionsSnapshot end

            //IOptionsMonitor start
            IOptionsMonitor<Student> monitor = provider.GetRequiredService<IOptionsMonitor<Student>>();
            Console.WriteLine($"name is:{monitor.CurrentValue.Name}");
            Console.WriteLine($"age is:{monitor.CurrentValue.Age}");

            
            monitor.OnChange((student) => {
                Console.WriteLine($"name is:{student.Name}");
                Console.WriteLine($"age is:{student.Age}");
            });

            //IOptionsMonitor end

            Console.ReadKey();
        }

        static void Print(IServiceProvider sp)
        {
            //var sp = scope.ServiceProvider;
            var options2 = sp.GetRequiredService<IOptionsMonitor<Student>>();
            var options3 = sp.GetRequiredService<IOptionsSnapshot<Student>>();
            Console.WriteLine("IOptionsMonitor值: {0}", options2.CurrentValue.Age);
            Console.WriteLine("IOptionsSnapshot值: {0}", options3.Value.Age);
            Console.WriteLine();
        }
    }


}
