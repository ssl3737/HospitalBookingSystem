using HBS.Dash.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HBS.Model
{
	public class Booking
	{
        [Required]
        public int Id { get; set; }
		public string BookingDate { get; set; }
        [Range(9, 18)]
        public string BookingTime { get; set; }
        public string CategoryFullName { get; set; }     

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}