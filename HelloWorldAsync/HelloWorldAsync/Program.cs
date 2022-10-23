using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace HelloWorldAsync
{
    public class Program
    {
        public static string PathHello => "Hello.txt";
        public static string PathWorld => "World.txt";
        public static void Main(string[] args)
        {
            Console.WriteLine(GetConcatText().Result);
        }

        public static async Task<string> GetConcatText()
        {
            var hello = Task.Run(ReadHelloAsync);
            var world = Task.Run(ReadWorldAsync);

            return await hello + await world;
        }

        public static async Task<string> ReadHelloAsync()
        {
            using (StreamReader reader = new StreamReader(PathHello))
            {
                return await reader.ReadToEndAsync();
            }
        }

        public static async Task<string> ReadWorldAsync()
        {
            using (StreamReader reader = new StreamReader(PathWorld))
            {
                return await reader.ReadToEndAsync();
            }
        }
    }
}
