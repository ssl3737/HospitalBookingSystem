using System;
using System.Collections.Generic;

namespace HBS.Model
{
	public class DoctorCategory
    {
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
