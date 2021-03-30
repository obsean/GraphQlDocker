using System;

namespace GraphQlDocker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var client = new UsersRepositories(new System.Net.Http.HttpClient());
        }
    }
}
