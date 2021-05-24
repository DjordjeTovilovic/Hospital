using Model;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class RoomController
    {
        public Service.RoomService roomService = new Service.RoomService();


        public List<Room> GetAll()
        {
            return roomService.GetAll();
        }

        public Room GetById(int id)
        {
            return roomService.GetById(id);
        }

        public Room GetByName(String name)
        {
            return roomService.GetByName(name);
        }

        public void Save(String name, RoomType roomType, int floor, String detail)
        {
            roomService.Save(name, roomType, floor, detail);
        }

        public void Delete(int id)
        {
            roomService.Delete(id);
        }

        public void Update(Room room)
        {
            roomService.Update(room);
        }
        public int GenerateNewId()
        {
            return roomService.GenerateNewId();
        }

        public void Renovation(int roomId, DateTime renovationDate)
        {
            roomService.Renovation(roomId, renovationDate);
        }

        public List<Room> GetRoomsByRoomType(RoomType roomType)
        {
            return roomService.GetRoomsByRoomType(roomType);
        }

        public List<Room> GetRoomsWithEquipmentName(string name)
        {
            return roomService.GetRoomsWithEquipmentName(name);
        }

        public void MoveStaticEquipment(int staticId, int toRoom, DateTime time)
        {
            roomService.MoveStaticEquipment(staticId, toRoom, time);
        }

    }
}