using System.ComponentModel.DataAnnotations;

namespace rui_ting_Project.Models
{
    public class Booking
    {
        [Key]
        public int Booking_ID { get; set; }
        public string? Facility_Description { get; set; }
        public string? Booking_Date_From { get; set; }
        public string? Booking_Date_To { get; set; }
        public string? Booked_By { get; set; }
        public string? Booking_Status { get; set; }
    }
}
