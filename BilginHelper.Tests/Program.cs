using System;

namespace BilginHelper.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            var dal = new CategoryDal();
            dal.Add(new Category
            {
                Name = "TestBerkoviç",
                Description ="TESTOVİC"
            });
            Console.WriteLine("Hello World!");
        }
    }
}
