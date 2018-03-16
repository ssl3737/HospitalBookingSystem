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
    public class DoctorController : Controller
    {
        private HBSContext _context;
        private IConfigurationRoot _config;

        public DoctorController(IConfigurationRoot config, HBSContext context)
        {
            _config = config;
            _context = context;

        }
        public IActionResult Index()
        {
            var query1 = _context.DoctorSchedule.ToList();
            ViewBag.DoctorSchedule = query1;

            return View();
        }
        public IActionResult Doctor() //maching name
        {
            var currentUser = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var applicationUser = _context.Users.Where(x => x.Id.Equals(currentUser)).SingleOrDefault();

            var DoctorScheduleList = new List<stp_GetDoctorScheduleVM>();
            using (var db = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                var sqlCommand = new SqlCommand("dbo.stp_GetDoctorSchedule", db)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@UserId", applicationUser.ToString());

                db.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                try
                {
                    int id = 1;

                    while (reader.Read())
                    {
                        DoctorScheduleList.Add(new stp_GetDoctorScheduleVM
                        {
                            Id = id,
                            DoctorFullName = currentUser,
                            BookingDate = reader.IsDBNull(0) ? null : reader.GetString(0),
                            BookingTime = reader.IsDBNull(1) ? null : reader.GetString(1),
                            UserFullName = reader.IsDBNull(2) ? null : reader.GetString(2),
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
            return View(DoctorScheduleList);
        }
    }
}