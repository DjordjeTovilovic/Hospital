using Controller;
using Repository;
using System;
using Service;
using System.IO;
using System.Windows;

namespace Hospital
{
    public partial class App : Application
    {
        private static readonly string _medicineFileLocation = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\medicines.json";
        private static readonly string _roomFileLocation = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\rooms.json";


        private static readonly MedicineRepository medicineRepository = new MedicineRepository(_medicineFileLocation);
        private static readonly RoomRepository roomRepository = new RoomRepository(_roomFileLocation);
        private static readonly RoomService roomService = new RoomService(roomRepository);



        public readonly PatientController patientController = new PatientController();

        public readonly AppointmentController appointmentController = new AppointmentController();
        public readonly RoomController roomController = new RoomController(roomService);
        public readonly StaticEquipmentController staticEquipmentController = new StaticEquipmentController();
        public readonly MedicineController medicineController = new MedicineController(medicineRepository);
        public readonly EmployeeController employeeController = new EmployeeController();
    }
}
