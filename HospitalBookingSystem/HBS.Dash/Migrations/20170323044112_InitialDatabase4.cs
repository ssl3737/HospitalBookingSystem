using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HBS.Dash.Migrations
{
    public partial class InitialDatabase4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Booking_Bookingid",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "workingdays",
                table: "Doctors",
                newName: "Workingdays");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Doctors",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Doctors",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "Clinic",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Clinic",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "Clinic",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Clinic",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Categories",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Categories",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Booking",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Bookingid",
                table: "AspNetUsers",
                newName: "BookingId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_Bookingid",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Booking_BookingId",
                table: "AspNetUsers",
                column: "BookingId",
                principalTable: "Booking",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Booking_BookingId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Workingdays",
                table: "Doctors",
                newName: "workingdays");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Doctors",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Doctors",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Clinic",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Clinic",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Clinic",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Clinic",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Categories",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Categories",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Booking",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "BookingId",
                table: "AspNetUsers",
                newName: "Bookingid");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_BookingId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_Bookingid");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Booking_Bookingid",
                table: "AspNetUsers",
                column: "Bookingid",
                principalTable: "Booking",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
