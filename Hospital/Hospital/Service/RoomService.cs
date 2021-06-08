using Model;
using DTO;
using System;
using Repository.Interfaces;
using Repository;
using System.Collections.Generic;


namespace Service
{
    public class RoomService : IService<Room>
    {
        
        public readonly AppointmentService appointmentService = new AppointmentService();
        public readonly StaticEquipmentService staticService = new StaticEquipmentService();
        private readonly IRoomRepository _roomRepository;
        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public IEnumerable<Room> GetAll()
            => _roomRepository.GetAll();

        public Room GetById(int id)
            => _roomRepository.GetById(id);

        public void Save(Room room)
            => _roomRepository.Save(room);

        public void Update(Room room)
            => _roomRepository.Update(room);

        public void Delete(int id)
            => _roomRepository.Delete(id);

        public Room GetByName(string name)
            => _roomRepository.GetByName(name);
        
        
        public List<Room> GetRoomsByRoomType(RoomType roomType)
        {
            return _roomRepository.GetRoomsByRoomType(roomType);
        }

        public int GenerateNewId()
            => _roomRepository.GenerateNewId();

        public bool Renovation(int roomId, DateTime renovationDate, double duration)
        {
            AppointmentDTO appointment = new AppointmentDTO(renovationDate, duration, roomId);
            if (appointmentService.IsRoomAvailable(appointment)){
                appointmentService.SaveRenovation(appointment);
                return true;
            }
            else
            {
                return false;
            }
        }



        public List<Room> GetRoomsWithEquipmentName(string name)
        {
            return _roomRepository.GetRoomsWithEquipmentName(name);
        }
        /*
        public void MoveStaticEquipment(int staticId, int toRoom)
        {
            StaticEquipment staticEquipment = staticService.GetById(staticId);
            Room room = GetById(staticEquipment.RoomId);

            room.StaticEquipments.Remove(staticEquipment);
            Room room2 = GetById(toRoom);

            staticEquipment.RoomId = room2.Id;
            room2.StaticEquipments.Add(staticEquipment);
            staticService.Update(staticEquipment);

            Update(room);
            Update(room2);
        }


        public void AttachRooms(int roomAId, int roomBId)
        {
            Room roomA = GetById(roomAId);
            Room roomB = GetById(roomBId);


            ExtractEquipment(roomB, roomA);
            roomA.Name = roomA.Name + "/" + roomB.Name;

            Update(roomA);
            Delete(roomBId);
        }

        private void ExtractEquipment(Room fromRoom, Room toRoom)
        {
            foreach (StaticEquipment staticEquipment in fromRoom.StaticEquipments)
                toRoom.StaticEquipments.Add(staticEquipment);
        }

        public void DettachRooms(int roomId)
        {
            Room roomA = GetById(roomId);
            Save(roomA.Name + "-A", roomA.RoomType, roomA.Floor, roomA.Detail); //room b
        }
        */
    }
}