using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HBS.Dash.Migrations
{
    public partial class InitialDatabase15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "Doctors",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_BookingId",
                table: "Doctors",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Booking_BookingId",
                table: "Doctors",
                column: "BookingId",
                principalTable: "Booking",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Booking_BookingId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_BookingId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "Doctors");
        }
    }
}
