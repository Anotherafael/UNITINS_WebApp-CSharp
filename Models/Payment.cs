using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace a1_hotel.Models
{

    public enum PaymentStatus
    {
        Aguardando, Negado, Aprovado
    }
    public class Payment
    {
        public int ID { get; set; }
        [DisplayName("Preço à Pagar")]
        public double Price { get; set; }
        [DisplayName("Data de Criação (mês/dia/ano)")]
        public DateTime CreatedAt { get; set; }
        [DisplayName("Data do Pagamento (mês/dia/ano)")]
        public DateTime? PaymentDate { get; set; }

        [DisplayName("ID da Reserva")]
        public int BookingID { get; set; }
        [DisplayName("Tipo de Pagamento")]
        public PaymentStatus PaymentStatus { get; set; }

        public virtual Booking Booking { get; set; }

        public Payment () {}

        public Payment (Booking booking)
        {
            this.Price = booking.Price;
            this.CreatedAt = DateTime.Now;
            this.BookingID = booking.ID;
            this.PaymentStatus = PaymentStatus.Aguardando;
            this.Booking = booking;
        }
    }
}