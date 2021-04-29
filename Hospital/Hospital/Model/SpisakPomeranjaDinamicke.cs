using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    class SpisakPomeranjaDinamicke
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public String Name { get; set; }


        public SpisakPomeranjaDinamicke(int id, int quantity, String name)
        {
            this.Id = id;
            this.Quantity = quantity;
            this.Name = name;         
        }
    }
}
