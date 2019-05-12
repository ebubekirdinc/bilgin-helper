using Bilgin.Test.Business;
using System;

namespace Bilgin.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            CategoryManager manager = new CategoryManager();
            manager.Add(new Entities.Category
            {
                Name ="Taze",
                Description="Pideeğ"
            });
        }
    }
}
