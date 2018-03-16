using HBS.Dash.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace HBS.Data
{
	public class DBInitializer
	{
		private HBSContext _context;
		private UserManager<ApplicationUser> _userManager;
		private RoleManager<IdentityRole> _roleManager;

		public DBInitializer(HBSContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			_context = context;
			_userManager = userManager;
			_roleManager = roleManager;
		}

		public async System.Threading.Tasks.Task InitializeData()
		{
			////////// Create Two Roles (Admin, User) and one admin account && one user account assigned with proper roles //////////

			var findAdminRole = await _roleManager.FindByNameAsync("Admin");//check there is existing user or not
            var findUserRole = await _roleManager.FindByNameAsync("User");
			var adminRole = new IdentityRole("Admin");//define admin role to be created
            var userRole = new IdentityRole("User");

			//If admin role does not exists, create it
			if (findAdminRole == null)
			{
				await _roleManager.CreateAsync(adminRole);
			}
			//If user role does not exists, create it
			if (findUserRole == null)
			{
				await _roleManager.CreateAsync(userRole);
			}
            
            var findAdminAccount = await _userManager.FindByNameAsync("doctor1@adps.com");

			//If there is no user account "admin@adps.com", create it       
			if (findAdminAccount == null)
			{
				var admin = new ApplicationUser()
				{
					UserName = "doctor1@adps.com",
					Email = "doctor1@adps.com",
					SecurityStamp = Guid.NewGuid().ToString()
				};

				var result = await _userManager.CreateAsync(admin, "P@$$w0rd");

				try
				{
					if (result.Succeeded)
					{
						await _context.SaveChangesAsync();
					}
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}

			var adminAccount = await _userManager.FindByNameAsync("doctor1@adps.com");
			//If Admin account is not in an admin role, add it to the role.
			if (!await _userManager.IsInRoleAsync(adminAccount, adminRole.Name))
			{
				await _userManager.AddToRoleAsync(adminAccount, adminRole.Name);
			}

			var findUserAccount = await _userManager.FindByNameAsync("test@adps.com");
			//If there is no user account "test@gmail.com, create it       
			if (findUserAccount == null)
			{
				var user = new ApplicationUser()
				{
					UserName = "test@adps.com",
					Email = "test@adps.com",
					PasswordHash = "P@$$w0rd",
					SecurityStamp = Guid.NewGuid().ToString()
				};

				var result = await _userManager.CreateAsync(user, "P@$$w0rd");

				try
				{
					if (result.Succeeded)
					{
						await _context.SaveChangesAsync();
					}
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}

			var userAccount = await _userManager.FindByNameAsync("test@adps.com");
			//If User account is not in an User role, add it to the role.
			if (!await _userManager.IsInRoleAsync(userAccount, userRole.Name))
			{
				await _userManager.AddToRoleAsync(userAccount, userRole.Name);
			}
            await _context.SaveChangesAsync();

		}
	}
}