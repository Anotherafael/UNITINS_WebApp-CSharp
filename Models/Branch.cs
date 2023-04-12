using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace a1_hotel.Models
{
    public class Branch
    {
        public int ID { get; set; }
        [StringLength(80)]
        [DisplayName("Nome da Filial")]
        public string Name { get; set; }
        [Index(IsUnique = true)]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(100)]
        [DisplayName("Endereço da Filial")]
        public string Address { get; set; }
        [StringLength(13, MinimumLength = 13, ErrorMessage = "Número de telefone inválido.")]
        [Index(IsUnique = true)]
        [DisplayName("Número de Telefone")]
        public string PhoneNumber { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }

        public Branch() { }

        public Branch(string name, string email, string address, string phoneNumber)
        {
            this.Name = name;
            this.Email = email;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
        }
    }
}