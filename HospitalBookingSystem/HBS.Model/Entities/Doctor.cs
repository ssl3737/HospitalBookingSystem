using System;
using System.Collections.Generic;

namespace HBS.Model
{
	public class Doctor
	{
		public int Id { get; set; }
		public string FullName { get; set; }
		public string Workingdays { get; set; }
        public string Email { get; set; }

        public int ClinicId { get; set; }
        public Clinic Clinic { get; set; }
        public ICollection<Booking> Bookings { get; set; }
        public ICollection<DoctorCategory> Categories { get; set; }
    }
}
