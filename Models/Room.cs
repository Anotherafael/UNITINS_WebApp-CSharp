using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace a1_hotel.Models
{
    public class Room
    {
        public int ID { get; set; }
        [DisplayName("Nome do Quarto")]
        public string Name { get; set; }
        [DisplayName("Descrição do Quarto")]
        public string Description { get; set; }
        [DisplayName("Preço por Noite")]
        public double Price_per_night { get; set; }
        [DisplayName("Disponibilidade do Quarto")]
        public bool Available { get; set; }
        [DisplayName("Tipo de Quarto")]
        public int RoomTypeID { get; set; }
        [DisplayName("Nome da Filial")]
        public int BranchID { get; set; }

        public virtual Branch Branch { get; set; }
        public virtual RoomType RoomType { get; set;}
        public virtual ICollection<Booking> Bookings { get; set; }

        public Room()
        {
            this.Bookings = new HashSet<Booking>();
        }

        public Room(string name, string description, double price_per_night, bool available, int roomTypeID, int branchID)
        {
            Name = name;
            Description = description;
            Price_per_night = price_per_night;
            Available = available;
            RoomTypeID = roomTypeID;
            BranchID = branchID;
        }
    }
}