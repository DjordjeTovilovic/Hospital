using System;

namespace Model
{
    public class Room
    {
        public Room(int id, String name, RoomType roomType, int floor, string detail)
        {
            Id = id;
            Name = name;
            RoomType = roomType;
            Floor = floor;
            Detail = detail;
        }
        public int Id
        {
            get
            ;
            set
            ;
        }

        public String Name
        {
            get
            ;
            set
            ;
        }

        public RoomType RoomType
        {
            get
            ;
            set
            ;
        }

        public int Floor
        {
            get
            ;
            set
            ;
        }

        public String Detail
        {
            get
            ;
            set
            ;
        }

        public Doctor Doctor { get; set; }

    }
}