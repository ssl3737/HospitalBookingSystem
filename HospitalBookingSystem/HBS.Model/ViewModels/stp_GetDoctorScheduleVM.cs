using System;

namespace HBS.Model.ViewModels
{
	public class stp_GetDoctorScheduleVM
    {
        public int Id { get; set; }
        public string DoctorFullName { get; set; }
        public string UserFullName { get; set; }
        public string BookingDate { get; set; }
        public string BookingTime { get; set; }
        public string CategoryFullName { get; set; }
        public string ClinicFullName { get; set; }

    }
}
