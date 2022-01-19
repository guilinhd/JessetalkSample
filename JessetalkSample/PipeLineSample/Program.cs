using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PipeLineSample
{
    class Program
    {

        static List<Func<RequestDelegate, RequestDelegate>> funcs = new List<Func<RequestDelegate, RequestDelegate>>();
        
        static void Main(string[] args)
        {
            Use(next =>
            {
                return context =>
                {
                    Console.WriteLine("1....");
                    return next.Invoke(context);
                };
            });

            Use(next =>
            {
                return context =>
                {
                    Console.WriteLine("2....");
                    return next.Invoke(context);
                };
            });

            Use(next =>
            {
                return context =>
                {
                    Console.WriteLine("3....");
                    return next.Invoke(context);
                };
            });

            RequestDelegate end = context =>
            {
                Console.WriteLine("end....");
                return Task.CompletedTask;
            };

            funcs.Reverse();
            foreach (var middleware in funcs)
            {
                end = middleware.Invoke(end);
            }

            end.Invoke(new Context());

            Console.ReadKey();
        }

        static void Use(Func<RequestDelegate, RequestDelegate> middleware)
        {
            funcs.Add(middleware);
        }
    }
}
