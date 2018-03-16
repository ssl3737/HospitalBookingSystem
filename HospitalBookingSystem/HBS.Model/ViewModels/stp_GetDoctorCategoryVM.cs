using System;

namespace HBS.Model.ViewModels
{
	public class stp_GetDoctorCategoryVM
    {
        public int Id { get; set; }
        public string DoctorFullName { get; set; }
        public string WorkingDays { get; set; }
        public string CategoryFullName { get; set; }
        public string ClinicFullName { get; set; }
        public int DoctorId { get; set; }
        public string BookingDate { get; set; }
        public string BookingTime { get; set; }
    }
}
