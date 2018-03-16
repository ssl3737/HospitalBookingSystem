using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HBS.Dash.Migrations
{
    public partial class InitialDatabase17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Booking_BookingId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Clinic_Doctors_DoctorId",
                table: "Clinic");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Booking_BookingId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Clinic_DoctorId",
                table: "Clinic");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_BookingId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Clinic");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "BookingId",
                table: "Doctors",
                newName: "ClinicId");

            migrationBuilder.RenameIndex(
                name: "IX_Doctors_BookingId",
                table: "Doctors",
                newName: "IX_Doctors_ClinicId");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Booking",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Booking",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Booking_ApplicationUserId",
                table: "Booking",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_DoctorId",
                table: "Booking",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_AspNetUsers_ApplicationUserId",
                table: "Booking",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Doctors_DoctorId",
                table: "Booking",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Clinic_ClinicId",
                table: "Doctors",
                column: "ClinicId",
                principalTable: "Clinic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_AspNetUsers_ApplicationUserId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Doctors_DoctorId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Clinic_ClinicId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Booking_ApplicationUserId",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_DoctorId",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Booking");

            migrationBuilder.RenameColumn(
                name: "ClinicId",
                table: "Doctors",
                newName: "BookingId");

            migrationBuilder.RenameIndex(
                name: "IX_Doctors_ClinicId",
                table: "Doctors",
                newName: "IX_Doctors_BookingId");

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Clinic",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clinic_DoctorId",
                table: "Clinic",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BookingId",
                table: "AspNetUsers",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Booking_BookingId",
                table: "AspNetUsers",
                column: "BookingId",
                principalTable: "Booking",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clinic_Doctors_DoctorId",
                table: "Clinic",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Booking_BookingId",
                table: "Doctors",
                column: "BookingId",
                principalTable: "Booking",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
