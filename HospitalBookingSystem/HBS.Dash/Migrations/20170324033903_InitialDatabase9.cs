using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HBS.Dash.Migrations
{
    public partial class InitialDatabase9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Clinic",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clinic_DoctorId",
                table: "Clinic",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clinic_Doctors_DoctorId",
                table: "Clinic",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clinic_Doctors_DoctorId",
                table: "Clinic");

            migrationBuilder.DropIndex(
                name: "IX_Clinic_DoctorId",
                table: "Clinic");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Clinic");
        }
    }
}
