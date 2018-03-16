using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using HBS.Data;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using HBS.Model.ViewModels;
using HBS.Model;
using System.Security.Claims;

namespace HBS.Dash.Controllers
{
    public class HomeController : Controller
    {
        private HBSContext _context;
        private IConfigurationRoot _config;

        public HomeController(IConfigurationRoot config, HBSContext context)
        {
            _config = config;
            _context = context;
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Index()
        {
            var query1 = _context.Categories.ToList();
            var query2 = _context.Clinic.ToList();
            var query3 = _context.Doctors.ToList();
            var query4 = _context.DoctorCategory.ToList();

            ViewBag.Categories = query1;
            ViewBag.Clinics = query2;
            ViewBag.Doctors = query3;
            ViewBag.DoctorCategory = query4;

            return View();
        }
        public IActionResult SubmitResult(DateTime bookingDate, DateTime bookingTime, int clinicId, int categoryId)
        {
            string date = bookingDate.ToString("dd/MM/yyyy");
            string dateValue = bookingDate.ToString("dddd");
            string timeValue = bookingTime.ToString("hh:mm tt");
            //            string dateValue2 = bookingDate.DayOfWeek.ToString(); //same as above

            var DoctorCategoryList = new List<stp_GetDoctorCategoryVM>();
            using (var db = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                // Get the FullName where doctorId is matching with Id in Doctor Table.
                //var name = _context.Doctors
                //    .Where(x => x.Id == doctorId)
                //    .Select(x => x.FullName)
                //    .SingleOrDefault();
                //var doctorList = new List<stp_GetDoctorsVM>();
                //using (var db = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                //{
                //    var sqlCommand = new SqlCommand("dbo.stp_GetDoctors", db) { CommandType = System.Data.CommandType.StoredProcedure };
                //    sqlCommand.Parameters.Add(new SqlParameter("FullName", name));
                var sqlCommand = new SqlCommand("dbo.stp_GetDoctorCategory", db) {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@DateValue", dateValue);
                sqlCommand.Parameters.AddWithValue("@CategoryId", categoryId);
                sqlCommand.Parameters.AddWithValue("@ClinicId", clinicId);

                db.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                try
                {
                    int id = 1;

                    while (reader.Read())
                    {
                        DoctorCategoryList.Add(new stp_GetDoctorCategoryVM
                        {
                            Id = id,
                            DoctorFullName = reader.IsDBNull(0) ? null : reader.GetString(0),
                            WorkingDays = reader.IsDBNull(1) ? null : reader.GetString(1),
                            CategoryFullName = reader.IsDBNull(2) ? null : reader.GetString(2),
                            ClinicFullName = reader.IsDBNull(3) ? null : reader.GetString(3),
                            DoctorId = reader.GetInt32(4),
                            BookingDate = date,
                            BookingTime = timeValue
                        });
                        id++;

                    }
                }
                catch (Exception ex)
                {

                }

                db.Close();
            }

            var bookingList = _context.Booking.ToList();

            // Check for duplicates between two lists, and delete the duplicate(s) in DoctorCategoryList.
            DoctorCategoryList
                .RemoveAll(stp => bookingList
                .Exists(book => book.DoctorId == stp.DoctorId &&
                                book.BookingDate == stp.BookingDate &&
                                book.BookingTime == stp.BookingTime));

            return PartialView("_Result", DoctorCategoryList);
        }
        public IActionResult _Result()
        {
            var query1 = _context.Booking.ToList();
            ViewBag.Bookings = query1;

            return View();
        }
        public IActionResult BookingResult(string CategoryFullName, string BookingDate, string BookingTime, int DoctorId)
        {
            var currentUser = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var applicationUser = _context.Users.Where(x => x.Id.Equals(currentUser)).SingleOrDefault();
            Booking booking = new Booking
            {
                CategoryFullName = CategoryFullName,
                BookingDate = BookingDate,
                BookingTime = BookingTime,
                DoctorId = DoctorId,
                ApplicationUserId = currentUser,
                ApplicationUser = applicationUser
            };
            _context.Booking.Add(booking);
            _context.SaveChangesAsync();

            return Redirect("Index");
        }


    }
}
