using Model;
using System;
using Service;
using System.Collections.Generic;

namespace Controller
{
    public class RoomController
    {
        private readonly IService<Room> roomService;
        
        public RoomController(IService<Room> service)
        {
            roomService = service;
        }

        public List<Room> GetAll()
        {
            return (List<Room>)roomService.GetAll();
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
            Room room = new Room(GenerateNewId(), name, roomType, floor, detail, true);
            roomService.Save(room);
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

        public bool Renovation(int roomId, DateTime renovationDate, double duration)
        {
            return true;
        }

        public List<Room> GetRoomsByRoomType(RoomType roomType)
        {
            return (List<Room>)roomService.GetAll();
        }

        public List<Room> GetRoomsWithEquipmentName(string name)
        {
            return (List<Room>)roomService.GetAll();
        }
        public void MoveStaticEquipment(int staticId, int toRoom)
        {
            
        }
        public void DettachRooms(int roomId)
        {
            
        }
        public void AttachRooms(int roomAId, int roomBId)
        {
            
        }

    }
}