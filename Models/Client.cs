using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace a1_hotel.Models
{
    public class Client
    {
        public int ID { get; set; }
        [DisplayName("Nome do Cliente")]
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Index(IsUnique = true)]
        [Required]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "Cpf inválido.")]
        public string Cpf { get; set; }
        [Required]
        [EmailAddress]
        [Index(IsUnique = true)]
        [StringLength(120)]
        public string Email { get; set; }
        [StringLength(13, MinimumLength = 13, ErrorMessage = "Número de telefone inválido.")]
        [Required]
        [DisplayName("Número de Telefone")]
        [Index(IsUnique = true)]
        public string PhoneNumber { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }

        public Client() {
            this.Bookings = new List<Booking>();
        }

        public Client(string name, string email, string cpf, string phoneNumber)
        {
            this.Name = name;
            this.Email = email;
            this.Cpf = cpf;
            this.PhoneNumber = phoneNumber;
            this.Bookings = new List<Booking>();
        }

        public override string ToString()
        {
            return "Name: " + this.Name + "; Email: " + this.Email + "; CPF: " + this.Cpf + "; PhoneNumber: " + this.PhoneNumber;
        }
    }
}