using System;
using System.Collections.Generic;

namespace HBS.Model
{
	public class Category
	{
		public int Id { get; set; }
		public string FullName { get; set; }
        public ICollection<DoctorCategory> Doctors { get; set; }
    }
}
