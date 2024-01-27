using System;


namespace BookstoreSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Bookstore bs = new Bookstore();
            bs.Run();

            Console.WriteLine();
            Console.WriteLine("Click any key to Exit. ");
            Console.ReadKey();
        }
    }
}
