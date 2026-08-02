namespace Task10_BoxingAndUnboxing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int copies = 100;

            object boxed = copies;

            int unboxed = (int)boxed;

            Console.WriteLine(copies);
            Console.WriteLine(boxed);
            Console.WriteLine(unboxed);
        }
    }
}
