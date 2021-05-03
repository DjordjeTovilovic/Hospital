﻿using DTO;
using Model;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Hospital.View.Doctor
{
    public partial class DoctorWindow : Window
    {
        App app;
        public Employee Doctor { get; set; }
        private List<AppointmentDTO> _appointments { get; set; }
        private List<AppointmentDTO> _appointmentsToShow { get; set; }

        public DoctorWindow()
        {
            InitializeComponent();
            app = Application.Current as App;

            Doctor = app.employeeController.GetByJmbg("1");
            WindowUpdate();
            appointment_date.SelectedDate = DateTime.Today;
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            _appointmentsToShow = _appointments.FindAll(appointment => appointment.StartTime.Date == appointment_date.SelectedDate);
            appointmentsDataGrid.ItemsSource = _appointmentsToShow;
        }

        public void WindowUpdate()
        {
            _appointments = app.appointmentController.GetAppointmentsForDoctor(Doctor.User.Jmbg);
            _appointmentsToShow = _appointments.FindAll(appointment => appointment.StartTime.Date == appointment_date.SelectedDate);
            appointmentsDataGrid.ItemsSource = _appointmentsToShow;
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            AppointmentDTO appointment = (AppointmentDTO)appointmentsDataGrid.SelectedItems[0];
            if (appointment.AppointmentType == AppointmentType.examination)
            {
                DoctorUpdateExamination doctorUpdateExamination = new DoctorUpdateExamination(this, appointment);
                doctorUpdateExamination.Show();
            }
            else
            {
                DoctorUpdateOperation doctorUpdateOperation = new DoctorUpdateOperation(this, appointment);
                doctorUpdateOperation.Show();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AppointmentDTO appointment = (AppointmentDTO)appointmentsDataGrid.SelectedItems[0];
                app.appointmentController.Delete(appointment.Id);
                WindowUpdate();
            }
            catch
            {
                MessageBox.Show("You have to select an appointment to delete!");
            }
        }

        private void View_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AppointmentDTO appointment = (AppointmentDTO)appointmentsDataGrid.SelectedItems[0];
                DoctorViewPatient doctorViewPatientWindow = new DoctorViewPatient(appointment);
                doctorViewPatientWindow.Show();
                this.Close();
            }
            catch
            {
                MessageBox.Show("You have to select an appointment to view!");
            }
        }

        private void NewExaminationButtonClick(object sender, RoutedEventArgs e)
        {
            DoctorExamination doctorExamination = new DoctorExamination(this);
            doctorExamination.Show();
        }

        private void NewOperationButtonClick(object sender, RoutedEventArgs e)
        {
            DoctorOperation doctorOperation = new DoctorOperation(this);
            doctorOperation.Show();
        }

        private void MedicineButton_Click(object sender, RoutedEventArgs e)
        {
            DoctorMedicine doctorMedicine = new DoctorMedicine(Doctor);
            doctorMedicine.Show();
        }
    }
}