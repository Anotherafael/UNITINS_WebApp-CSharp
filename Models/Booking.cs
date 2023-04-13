using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace a1_hotel.Models
{
    public enum BookingStatus
    {
        Pendente, Aprovado, Cancelado
    }

    public class Booking
    {
     
        public int ID { get; set; }
        [Required]
        [DisplayName("Data de Entrada (mês/dia/ano)")]
        public DateTime EntryDate { get; set; }
        [Required]
        [DisplayName("Data de Saída (mês/dia/ano)")]
        public DateTime DepartureDate { get; set; }
        [Required]
        [DisplayName("Quantidade de Convidados")]
        [Range(0, 5)]
        public int Guests { get; set; }
        public BookingStatus Status { get; set; }
        [Required]
        [DisplayName("Preço da Reserva")]
        public double Price { get; set; }

        public int ClientID { get; set; }
        public int RoomID { get; set; }

        public virtual Client Client { get; set; }
        public virtual Room Room { get; set; }

        public Booking() {
        }

        public Booking(DateTime entryDate, DateTime departureDate, int guests, double price, int clientID, int roomID, int status)
        {
            EntryDate = entryDate;
            DepartureDate = departureDate;
            Guests = guests;
            Price = price;
            ClientID = clientID;
            RoomID = roomID;
            if (status == 0) Status = BookingStatus.Pendente;
            else if (status == 1) Status = BookingStatus.Aprovado;
            else if (status == 2) Status = BookingStatus.Cancelado;
            else Status = BookingStatus.Cancelado;
        }
    }
}