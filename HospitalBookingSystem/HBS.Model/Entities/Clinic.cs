using System;
using System.Collections.Generic;

namespace HBS.Model
{
	public class Clinic
	{
		public int Id { get; set; }
		public string FullName { get; set; }
		public string Phone { get; set; }
		public string Address { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
