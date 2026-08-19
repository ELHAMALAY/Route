using System;

namespace SmartDeliveryManagementSystem.Utilities
{
    public static class DeliveryUtilities
    {
        public static void PrintSeparator()
        {
            Console.WriteLine("==========================================");
        }

        public static void PrintSubSeparator()
        {
            Console.WriteLine("------------------------------------------");
        }

        public static void PrintSystemTitle()
        {
            PrintSeparator();
            Console.WriteLine("Smart Delivery Management System");
            PrintSeparator();
        }

        public static void PrintSectionTitle(string title)
        {
            PrintSeparator();
            Console.WriteLine(title);
            PrintSeparator();
        }

        public static void PrintSubSectionTitle(string title)
        {
            PrintSubSeparator();
            Console.WriteLine(title);
            PrintSubSeparator();
        }
    }
}
