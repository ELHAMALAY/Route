using System;
using System.Collections.Generic;
using System.Text;

namespace Smart_Delivery_Management_System
{
    public struct DeliveryCenter
    {
        private Shipment[] shipments;

        public DeliveryCenter(int size)
        {
            shipments = new Shipment[size];
        }

        public Shipment this[int index]
        {
            get
            {
                if (index >= 0 && index < shipments.Length)
                    return shipments[index];

                return default;
            }

            set
            {
                if (index >= 0 && index < shipments.Length)
                    shipments[index] = value;
            }
        }

        public Shipment this[string trackingCode]
        {
            get
            {
                foreach (Shipment shipment in shipments)
                {
                    if (shipment.TrackingCode == trackingCode)
                        return shipment;
                }

                return default;
            }
        }

        public bool AddShipment(Shipment shipment)
        {
            for (int i = 0; i < shipments.Length; i++)
            {
                if (shipments[i].TrackingCode == null)
                {
                    shipments[i] = shipment;
                    return true;
                }
            }

            return false;
        }
    }
}
