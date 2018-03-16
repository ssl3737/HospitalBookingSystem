using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HBS.Model.ViewModels;
using HBS.Data;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.Data.SqlClient;

namespace HBS.Dash.Controllers
{
    public class BookingController : Controller
    {
        private HBSContext _context;
        private IConfigurationRoot _config;

        public BookingController(IConfigurationRoot config, HBSContext context)
        {
            _config = config;
            _context = context;
        }

        public IActionResult Booking() //maching name
        {
            var currentUser = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var applicationUser = _context.Users.Where(x => x.Id.Equals(currentUser)).SingleOrDefault();

            //            var result = _context.Doctors
            //                .Join(_context.Booking, d => d.Id, b => b.DoctorId, (b, d) => new { Booking = b , Doctors = d })
            //                .Join(_context.Clinic, d => d.ClinicId, c => c.Id, (d, c) => new { d, Clinic = c })
            //               .Where(b => b.ApplicationUserId == applicationUserId)
            //               .Select(b => b);          
            var BookingsList = new List<stp_GetBookingsVM>();
            using (var db = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                var sqlCommand = new SqlCommand("dbo.stp_GetBookings", db)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@UserId", currentUser.ToString());

                db.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                try
                {
                    int id = 1;

                    while (reader.Read())
                    {
                        BookingsList.Add(new stp_GetBookingsVM
                        {
                            Id = id,
                            UserFullName = currentUser,
                            BookingDate = reader.IsDBNull(0) ? null : reader.GetString(0),
                            BookingTime = reader.IsDBNull(1) ? null : reader.GetString(1),
                            DoctorFullName = reader.IsDBNull(2) ? null : reader.GetString(2),
                            CategoryFullName = reader.IsDBNull(3) ? null : reader.GetString(3),
                            ClinicFullName = reader.IsDBNull(4) ? null : reader.GetString(4)
                        });
                        id++;
                    }
                }
                catch (Exception ex)
                {
                }
                db.Close();
            }
            return View(BookingsList);
        }
    }
}
