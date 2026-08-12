namespace SmartDeliverySystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // a. Create a Driver
            Driver driver = new Driver("D001", "Ahmed Mohamed", "01000000000");

            // b. Create a DeliveryCenter
            DeliveryCenter center = new DeliveryCenter("Cairo Center");

            // c. Assign the Driver to the DeliveryCenter
            center.Driver = driver;

            // d, e, f. Create one shipment of each type
            StandardShipment standard = new StandardShipment(
                "SH001", "Laptop", 3, 80, new DeliveryAddress("Tahrir St", "Cairo"));

            ExpressShipment express = new ExpressShipment(
                "SH002", "Mobile Phone", 2, 60, new DeliveryAddress("Corniche St", "Alexandria"), 30);

            InternationalShipment international = new InternationalShipment(
                "SH003", "Television", 8, 120, new DeliveryAddress("Main St", "Berlin"), "Germany", 100);

            // g. Add all shipments to the DeliveryCenter
            center.AddShipment(standard);
            center.AddShipment(express);
            center.AddShipment(international);

            Console.WriteLine();
            Console.WriteLine("==========================================");
            Console.WriteLine("Delivery Center : " + center.CenterName);
            Console.WriteLine("==========================================");
            Console.WriteLine($"Driver : {center.Driver.FullName}");
            Console.WriteLine("------------------------------------------");

            // h. Print all shipments using PrintAllShipments()
            center.PrintAllShipments();

            Console.WriteLine("==========================================");
            Console.WriteLine("Printing Using DeliveryHelper...");
            Console.WriteLine();

            // i. Call DeliveryHelper.PrintShipmentDetails() for each shipment
            DeliveryHelper.PrintShipmentDetails(standard);
            DeliveryHelper.PrintShipmentDetails(express);
            DeliveryHelper.PrintShipmentDetails(international);

            Console.WriteLine("==========================================");
            Console.WriteLine("Updating Weight...");
            Console.WriteLine();

            // j. Demonstrate both versions of UpdateWeight()
            Console.WriteLine($"Original Weight : {standard.Weight} KG");
            standard.UpdateWeight(5);
            Console.WriteLine($"Updated Weight : {standard.Weight} KG");
            standard.UpdateWeight(5, 0.5m);
            Console.WriteLine($"Updated Weight After Packing : {standard.Weight} KG");

            Console.WriteLine("==========================================");
            Console.WriteLine("Printing Using Shipment[]...");
            Console.WriteLine();

            // k. Build a Shipment[] holding mixed types and print all of them in a loop
            Shipment[] mixedShipments = { standard, express, international };
            foreach (Shipment s in mixedShipments)
            {
                s.PrintShipment();
                Console.WriteLine("------------------------------------------");
            }

            Console.WriteLine("==========================================");
            Console.WriteLine("Demonstrating Sealed Class and Sealed Method...");
            Console.WriteLine();

            // l. Demonstrate the sealed class (CompletedShipment) and sealed method (GenerateCustomsReport)
            CompletedShipment completed = new CompletedShipment(
                "SH004", "Books", 1, 40, new DeliveryAddress("Nile St", "Cairo"));
            completed.PrintShipment();

            Console.WriteLine();

            PriorityInternationalShipment priority = new PriorityInternationalShipment(
                "SH005", "Medical Supplies", 5, 150, new DeliveryAddress("King St", "Paris"), "France", 120);
            priority.GenerateCustomsReport();

            Console.WriteLine("==========================================");

            // Optional extra demonstration of RemoveShipment and indexers, kept from Assignment 02
            Console.WriteLine();
            Console.WriteLine("Removing Shipment SH002...");
            center.RemoveShipment("SH002");
            Console.WriteLine();
            Console.WriteLine("==========================================");
            Console.WriteLine("Remaining Shipments");
            Console.WriteLine("==========================================");
            center.PrintAllShipments();
        }
    }
}
