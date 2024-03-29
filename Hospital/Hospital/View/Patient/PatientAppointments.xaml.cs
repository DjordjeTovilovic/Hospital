﻿using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Windows;
using DTO;


namespace Hospital
{
    /// <summary>
    /// Interaction logic for PatientAppointments.xaml
    /// </summary>
    public partial class PatientAppointments : Window
    {
        AppointmentController appointmentController = new AppointmentController();
        PatientController patientController = new PatientController();
        List<MedicalAppointment> appointments = new List<MedicalAppointment>();
        List<AppointmentDTO> appointmentDTOs = new List<AppointmentDTO>();
        public PatientAppointments()
        {
            InitializeComponent();

            appointmentDTOs = appointmentController.GetAppointmentsForPatient("5");
            readDataGrid.ItemsSource = appointmentDTOs;
            cancelButton.Visibility = Visibility.Collapsed;
            updateConfirm.Visibility = Visibility.Collapsed;


        }

        private void WindowUpdate()
        {
            appointmentDTOs = appointmentController.GetAppointmentsForPatient("5");
            readDataGrid.ItemsSource = appointmentDTOs;
        }

        private void ClearFileds()
        {
            durationTextBox.Clear();
            startTimeTextBox.Clear();

        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AppointmentDTO appoinmentDTO = (AppointmentDTO)readDataGrid.SelectedItems[0];
                new_appointment_date.SelectedDate = appoinmentDTO.StartTime.Date;
                durationTextBox.Text = appoinmentDTO.DurationInMinutes.ToString();
                startTimeTextBox.Text = appoinmentDTO.StartTime.ToString(("HH:mm"));
                updateConfirm.Visibility = Visibility.Visible;
                cancelButton.Visibility = Visibility.Visible;
            }
            catch
            {
                MessageBox.Show("Izaberi pregled", "greska");
            }
        }


        private AppointmentDTO AppointmentFromData()
        {

            AppointmentDTO oldAppointmentDTO = (AppointmentDTO)readDataGrid.SelectedItems[0];
            DateTime pickedDate = new_appointment_date.SelectedDate.Value;
            int hours = Int32.Parse(startTimeTextBox.Text.Split(':')[0]);
            int minutes = Int32.Parse(startTimeTextBox.Text.Split(':')[1]);
            DateTime appointmentDateTime = new DateTime(pickedDate.Year, pickedDate.Month, pickedDate.Day, hours, minutes, 00);
            double duration = Convert.ToDouble(durationTextBox.Text);

            AppointmentDTO newAppointment = new AppointmentDTO(oldAppointmentDTO.Id,
                                                         oldAppointmentDTO.MedicalAppointmentType,
                                                         appointmentDateTime,
                                                         duration,
                                                         oldAppointmentDTO.PatientJmbg,
                                                         oldAppointmentDTO.DoctorJmbg,
                                                         oldAppointmentDTO.RoomId,
                                                         oldAppointmentDTO.PatientJmbg);
            return newAppointment;
        }

        private void updateConfirm_Click(object sender, RoutedEventArgs e)
        {
            

            bool error = appointmentController.AppointmentTimeIsInvalid(AppointmentFromData());
            if (error)
            {
                MessageBox.Show("Izmjena nije moguca", "greska");
            }
            else
            {
                appointmentController.Update(AppointmentFromData());
                WindowUpdate();
                updateConfirm.Visibility = Visibility.Collapsed;
                cancelButton.Visibility = Visibility.Collapsed;
                ClearFileds();

            }

        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            updateConfirm.Visibility = Visibility.Collapsed;
            cancelButton.Visibility = Visibility.Collapsed;
            ClearFileds();

        }

        private void deletebutton_Click(object sender, RoutedEventArgs e)
        {
            AppointmentDTO appointmentDTO = (AppointmentDTO)readDataGrid.SelectedItems[0];
            string message = patientController.AntiTrollCheck(appointmentDTO.Id);
            MessageBox.Show(message, "obavjestenje");
            appointmentController.Delete(appointmentDTO.Id, "5");

            if(message == "Pacijent je blokiran")
            {
                var new_window = new MainWindow();
                new_window.Show();
                this.Close();

            }

            WindowUpdate();
        }

        private void NewAppointment_Click(object sender, RoutedEventArgs e)
        {
            var new_window = new PatientWindow();
            new_window.Show();
            this.Close();
        }

        private void showAppointments_Click(object sender, RoutedEventArgs e)
        {
            var new_window = new PatientAppointments();
            new_window.Show();
            this.Close();
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var new_window = new PatientReview();
            new_window.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var new_window = new PatientReferral();
            new_window.Show();
            this.Close();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var newWindow = new PatientMedicalRecord();
            newWindow.Show();
            //this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var newWindow = new PatientReminder();
            newWindow.Show();
            //this.Close();
        }


    }
}
