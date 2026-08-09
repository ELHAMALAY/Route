namespace Smart_Delivery_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create Delivery Center
            Console.Write("Enter Delivery Center Name: ");
            string centerName = Console.ReadLine();

            DeliveryCenter center = new DeliveryCenter(centerName);



            // Standard Shipment
   

            Console.WriteLine("\n--- Enter Standard Shipment Data ---");

            Console.Write("Tracking Code: ");
            string standardTrackingCode = Console.ReadLine();

            Console.Write("Description: ");
            string standardDescription = Console.ReadLine();

            Console.Write("Weight: ");
            decimal standardWeight = decimal.Parse(Console.ReadLine());

            Console.Write("Delivery Fee: ");
            decimal standardDeliveryFee = decimal.Parse(Console.ReadLine());

            Console.Write("City: ");
            string standardCity = Console.ReadLine();

            Console.Write("Street: ");
            string standardStreet = Console.ReadLine();

            Console.Write("Building Number: ");
            int standardBuildingNumber =
                int.Parse(Console.ReadLine());

            DeliveryAddress standardAddress =
                new DeliveryAddress(
                    standardCity,
                    standardStreet,
                    standardBuildingNumber);

            StandardShipment standardShipment =
                new StandardShipment(
                    standardTrackingCode,
                    standardDescription,
                    standardWeight,
                    standardDeliveryFee,
                    standardAddress);


   
            // Express Shipment
   

            Console.WriteLine("\n--- Enter Express Shipment Data ---");

            Console.Write("Tracking Code: ");
            string expressTrackingCode = Console.ReadLine();

            Console.Write("Description: ");
            string expressDescription = Console.ReadLine();

            Console.Write("Weight: ");
            decimal expressWeight = decimal.Parse(Console.ReadLine());

            Console.Write("Delivery Fee: ");
            decimal expressDeliveryFee = decimal.Parse(Console.ReadLine());

            Console.Write("City: ");
            string expressCity = Console.ReadLine();

            Console.Write("Street: ");
            string expressStreet = Console.ReadLine();

            Console.Write("Building Number: ");
            int expressBuildingNumber =
                int.Parse(Console.ReadLine());

            Console.Write("Extra Fee: ");
            decimal extraFee =
                decimal.Parse(Console.ReadLine());

            DeliveryAddress expressAddress =
                new DeliveryAddress(
                    expressCity,
                    expressStreet,
                    expressBuildingNumber);

            ExpressShipment expressShipment =
                new ExpressShipment(
                    expressTrackingCode,
                    expressDescription,
                    expressWeight,
                    expressDeliveryFee,
                    expressAddress,
                    extraFee);


    
            // International Shipment
          

            Console.WriteLine(
                "\n--- Enter International Shipment Data ---");

            Console.Write("Tracking Code: ");
            string internationalTrackingCode =
                Console.ReadLine();

            Console.Write("Description: ");
            string internationalDescription =
                Console.ReadLine();

            Console.Write("Weight: ");
            decimal internationalWeight =
                decimal.Parse(Console.ReadLine());

            Console.Write("Delivery Fee: ");
            decimal internationalDeliveryFee =
                decimal.Parse(Console.ReadLine());

            Console.Write("City: ");
            string internationalCity =
                Console.ReadLine();

            Console.Write("Street: ");
            string internationalStreet =
                Console.ReadLine();

            Console.Write("Building Number: ");
            int internationalBuildingNumber =
                int.Parse(Console.ReadLine());

            Console.Write("Destination Country: ");
            string destinationCountry =
                Console.ReadLine();

            Console.Write("Customs Fee: ");
            decimal customsFee =
                decimal.Parse(Console.ReadLine());

            DeliveryAddress internationalAddress =
                new DeliveryAddress(
                    internationalCity,
                    internationalStreet,
                    internationalBuildingNumber);

            InternationalShipment internationalShipment =
                new InternationalShipment(
                    internationalTrackingCode,
                    internationalDescription,
                    internationalWeight,
                    internationalDeliveryFee,
                    internationalAddress,
                    destinationCountry,
                    customsFee);


      
            // Add Shipments
     

            if (center.AddShipment(standardShipment))
            {
                Console.WriteLine("\nShipment Added Successfully.");
            }

            if (center.AddShipment(expressShipment))
            {
                Console.WriteLine("Shipment Added Successfully.");
            }

            if (center.AddShipment(internationalShipment))
            {
                Console.WriteLine("Shipment Added Successfully.");
            }


         
            // Print All Shipments
            

            Console.WriteLine();

            center.PrintAllShipments();


          
            // Search Shipment
          

            Console.Write("\nEnter Tracking Code to Search: ");
            string searchCode = Console.ReadLine();

            Shipment searchedShipment = center[searchCode];

            if (searchedShipment != null)
            {
                Console.WriteLine("\nShipment Found:");
                searchedShipment.PrintShipment();
            }
            else
            {
                Console.WriteLine("Shipment not found.");
            }


           
            // Remove Shipment
            

            Console.Write("\nEnter Tracking Code to Remove: ");
            string removeCode = Console.ReadLine();

            bool removed = center.RemoveShipment(removeCode);

            if (removed)
            {
                Console.WriteLine("\nShipment Removed Successfully.");
            }
            else
            {
                Console.WriteLine("\nShipment not found.");
            }


            // =========================
            // Print Remaining Shipments
            // =========================

            Console.WriteLine();
            Console.WriteLine("========================================");
            Console.WriteLine("Remaining Shipments");
            Console.WriteLine("========================================");

            for (int i = 0; i < 20; i++)
            {
                if (center[i] != null)
                {
                    Console.WriteLine();
                    center[i].PrintShipment();
                    Console.WriteLine("...");
                }
            }
        }
    }
}
