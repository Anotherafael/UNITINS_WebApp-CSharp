using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace a1_hotel.Models
{
    public class RoomType
    {
        public int ID { get; set; }
        [DisplayName("Tipo de Quarto")]
        public string Name { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }

        public RoomType() {
            this.Rooms = new HashSet<Room>();
        }

        public RoomType(string name) {
            this.Name = name;
        }

    }
}