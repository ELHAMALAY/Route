using System;

namespace SmartDeliveryManagementSystem.Models
{
    public partial class Shipment
    {
        public string TrackingStatus { get; private set; } = "Pending";

        public string GetTrackingStatus()
        {
            return TrackingStatus;
        }

        public void UpdateTrackingStatus(string newStatus)
        {
            TrackingStatus = newStatus;

            OnTrackingStatusChanged(newStatus);
        }

        public void UpdateTrackingStatusSilently(string newStatus)
        {
            TrackingStatus = newStatus;
        }

        partial void OnTrackingStatusChanged(string newStatus)
        {
            Console.WriteLine($"Tracking status changed to: {newStatus}");
        }
    }
}
