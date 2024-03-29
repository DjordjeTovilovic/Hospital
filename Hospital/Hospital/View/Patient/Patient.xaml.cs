﻿using Controller;
using DTO;
using Model;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Hospital
{
    /// <summary>
    /// Interaction logic for PatientWindow.xaml
    /// </summary>
    public partial class PatientWindow : Window
    {
        EmployeeController doctorController = new EmployeeController();

        AppointmentController appointmentController = new AppointmentController();
        RoomController roomController = new RoomController();
        List<Employee> doctors = new List<Employee>();
        Patient patient;
        PatientController patientController = new PatientController();
        Employee doctor;
        List<AppointmentDTO> doctorsAppointments;
        public PatientWindow()
        {
            InitializeComponent();
            /*  //PATIENT DATA GEN
              DateTime date2 = new DateTime(1998, 6, 12);
              DateTime date3 = new DateTime(1973, 8, 9);
              DateTime medicineStart1 = new DateTime(2021, 4, 17, 12, 20, 00);
              DateTime medicineStart2 = new DateTime(2021, 3, 20, 14, 00, 00);
              DateTime medicineEnd1 = new DateTime(2021, 6, 2, 12, 20, 00);
              DateTime medicineEnd2 = new DateTime(2021, 7, 8, 14, 00, 00);
              User user2 = new User("33", "Zarko", "Zarkovic", "asd", "sifra", "email", "adresa", date2);
              User user3 = new User("44", "Pero", "Peric", "dsa", "sifra", "email", "adresa", date3);
              Medicine medicine2 = new Medicine(1, "Paracetamol");
              Medicine medicine3 = new Medicine(2, "Brufen");
              MedicalRecord medicalRecord = new MedicalRecord();
              //Prescription prescription1 = new Prescription(3, medicineStart1, medicineEnd1, "opis",100,medicine2);
              //Prescription prescription2 = new Prescription(6, medicineStart2, medicineEnd2, "opis", 100, medicine3);
              Anamnesis anamnesis1 = new Anamnesis(1,"Licna","ime anamneze", "opis anamneze");
              Anamnesis anamnesis2 = new Anamnesis(2, "Anamneza", "naziv", "opis ");

              //prescription1.Medicine = medicine2;
              //prescription2.Medicine = medicine3;

              List<Prescription> prescriptions = new List<Prescription>();
              //prescriptions.Add(prescription2);
              //prescriptions.Add(prescription1);

              List<Anamnesis> anamneses = new List<Anamnesis>();
              anamneses.Add(anamnesis1);
              anamneses.Add(anamnesis2);

              List<String> alergies = new List<String>();
              alergies.Add("Alergija na polen");
              alergies.Add("Alergija na dlake");

              medicalRecord.Prescription = prescriptions;
              medicalRecord.Anamnesis = anamneses;
              medicalRecord.Alergies = alergies;


              Patient patient1 = new Patient(user2);
              patient1.MedicalRecord = medicalRecord;
              List<DateTime> cancelDates = new List<DateTime>();
              cancelDates.Add(DateTime.Now);
              patient1.CancelationDates = cancelDates;
              patientController.Save(patient1);

              */

            ////PATIENT DATA GEN
            // DateTime date2 = new DateTime(1998, 6, 12);
            //  DateTime date3 = new DateTime(1973, 8, 9);
            //  DateTime medicineStart1 = new DateTime(2021, 4, 17, 12, 20, 00);
            //  DateTime medicineStart2 = new DateTime(2021, 3, 20, 14, 00, 00);
            //  DateTime medicineEnd1 = new DateTime(2021, 6, 2, 12, 20, 00);
            //  DateTime medicineEnd2 = new DateTime(2021, 7, 8, 14, 00, 00);
            //  User user2 = new User("5", "Zarko", "Zarkovic", "asd", "sifra", "email", "adresa", date2);
            //  User user3 = new User("6", "Pero", "Peric", "dsa", "sifra", "email", "adresa", date3);
            //  Medicine medicine2 = new Medicine(1, "Paracetamol");
            //  Medicine medicine3 = new Medicine(2, "Brufen");
            //  MedicalRecord medicalRecord = new MedicalRecord();
            //  //Prescription prescription1 = new Prescription(3, medicineStart1, medicineEnd1, "opis",100,medicine2);
            //  //Prescription prescription2 = new Prescription(6, medicineStart2, medicineEnd2, "opis", 100, medicine3);
            //  Anamnesis anamnesis1 = new Anamnesis(1,"Licna","ime anamneze", "opis anamneze");
            //  Anamnesis anamnesis2 = new Anamnesis(2, "Anamneza", "naziv", "opis ");

            //  //prescription1.Medicine = medicine2;
            //  //prescription2.Medicine = medicine3;

            //  List<Prescription> prescriptions = new List<Prescription>();
            //  //prescriptions.Add(prescription2);
            //  //prescriptions.Add(prescription1);

            //  List<Anamnesis> anamneses = new List<Anamnesis>();
            //  anamneses.Add(anamnesis1);
            //  anamneses.Add(anamnesis2);

            //  List<String> alergies = new List<String>();
            //  alergies.Add("Alergija na polen");
            //  alergies.Add("Alergija na dlake");

            //  medicalRecord.Prescription = prescriptions;
            //  medicalRecord.Anamnesis = anamneses;
            //  medicalRecord.Alergies = alergies;


            //  Patient patient1 = new Patient(user2);
            //  patient1.MedicalRecord = medicalRecord;
            //  List<DateTime> cancelDates = new List<DateTime>();
            //  cancelDates.Add(DateTime.Now);
            //  patient1.CancelationDates = cancelDates;

            //  Employee doctortest = doctorController.GetByJmbg("1");
            //  Referral referral = new Referral("opis neki", doctortest);
            //  List<Referral> referrals = new List<Referral>();
            //  referrals.Add(referral);
            //  patient1.MedicalRecord.Referrals = referrals;
            //  patientController.Save(patient1);

            //Referral referral = new Referral("1", "opis drugi ");
            //patient.MedicalRecord.Referrals.Add(referral);
            //patientController.Update(patient);


            doctors = doctorController.GetDoctors();
            timeDataGrid.Visibility = Visibility.Collapsed;
            patient = patientController.GetByJmbg("5");




            doctorsDataGrid.ItemsSource = doctors;
            CheckNotifications();
        }

        private void ClearFileds()
        {
            durationTextBox.Clear();
            startTimeTextBox.Clear();

        }
        private AppointmentDTO CreateAppointmentFromData()
        {
            //int id = Int32.Parse(idTextBox.Text);
            DateTime pickedDate = new_appointment_date.SelectedDate.Value;
            int hours = Int32.Parse(startTimeTextBox.Text.Split(':')[0]);
            int minutes = Int32.Parse(startTimeTextBox.Text.Split(':')[1]);
            DateTime appointmentDateTime = new DateTime(pickedDate.Year, pickedDate.Month, pickedDate.Day, hours, minutes, 00);
            double duration = Convert.ToDouble(durationTextBox.Text);

            return new AppointmentDTO(MedicalAppointmentType.examination, appointmentDateTime, duration, patient.User.Jmbg, doctor.User.Jmbg, doctor.RoomId, patient.User.Jmbg);
        }



        public void CheckNotifications()
        {
            
            patientController.CheckForMedicineNotification(patient);
            patientController.CheckForReminder(patient.User.Jmbg);
            patient = patientController.GetByJmbg(patient.User.Jmbg);
            foreach (Notification notification in patient.Notifications)
            {
                MessageBox.Show(notification.NotificationText, "Notification");
            }
            patient.Notifications.Clear();
            patientController.Update(patient);
                
            
            


        }

        private void New_Appointment_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                doctor = (Employee)doctorsDataGrid.SelectedItems[0];
                AppointmentDTO newAppointment = CreateAppointmentFromData();
                doctorsAppointments = appointmentController.GetAppointmentsForDoctor(doctor.User.Jmbg);
                bool error = false;

                if (appointmentController.AppointmentIsTaken(newAppointment, doctor.User.Jmbg))
                {
                    error = true;
                }

                if (error == true)
                {
                    if (doctorRadioButton.IsChecked == true)
                    {
                        MessageBox.Show("Doktor je zauzet, izaberi drugi termin", "greska");
                        timeDataGrid.Visibility = Visibility.Visible;
                        timeDataGrid.ItemsSource = doctorsAppointments;
                    }
                    else
                    {
                        MessageBox.Show("Termin je zauzet, izaberi drugog doktora", "greska");
                        timeDataGrid.ItemsSource = doctorsAppointments;
                    }
                }
                else if (appointmentController.AppointmentValidationWithoutOverlaping(newAppointment))
                {
                    MessageBox.Show("Termin nije moguce dodati, ponovi unos", "greska");
                }
                else
                {
                    appointmentController.Save(newAppointment);
                    ClearFileds();
                    MessageBox.Show("Novi termin uspjeno dodat", "Uspjesno");
                }

            }
            catch
            {
                MessageBox.Show("Unesi podatke u sva polja", "Greska");
            }
        }




        private void timeRadioButton_Click(object sender, RoutedEventArgs e)
        {
            timeDataGrid.Visibility = Visibility.Collapsed;
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

        private void NewAppointment_Click(object sender, RoutedEventArgs e)
        {
            var new_window = new PatientWindow();
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
