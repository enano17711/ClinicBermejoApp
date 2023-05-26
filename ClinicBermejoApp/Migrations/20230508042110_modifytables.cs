﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicBermejoApp.Migrations
{
    /// <inheritdoc />
    public partial class modifytables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CategoryServiceId",
                table: "Services",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AppointmentId",
                table: "Patients",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AppointmentId",
                table: "Nurses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AppointmentId",
                table: "Doctors",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_CategoryServiceId",
                table: "Services",
                column: "CategoryServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_AppointmentId",
                table: "Patients",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Nurses_AppointmentId",
                table: "Nurses",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_AppointmentId",
                table: "Doctors",
                column: "AppointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Appointments_AppointmentId",
                table: "Doctors",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "AppointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nurses_Appointments_AppointmentId",
                table: "Nurses",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "AppointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Appointments_AppointmentId",
                table: "Patients",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "AppointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_CategoryServices_CategoryServiceId",
                table: "Services",
                column: "CategoryServiceId",
                principalTable: "CategoryServices",
                principalColumn: "CategoryServiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Appointments_AppointmentId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Nurses_Appointments_AppointmentId",
                table: "Nurses");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Appointments_AppointmentId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_CategoryServices_CategoryServiceId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_CategoryServiceId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Patients_AppointmentId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Nurses_AppointmentId",
                table: "Nurses");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_AppointmentId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "CategoryServiceId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "Nurses");

            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "Doctors");
        }
    }
}