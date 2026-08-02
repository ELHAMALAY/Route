namespace Task14_NullCoalescingOperators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string? txt = null;

            Console.WriteLine(txt ?? "Untitled");

            txt ??= "Untitled";

            Console.WriteLine(txt);
        }
    }
}
