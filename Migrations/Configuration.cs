namespace a1_hotel.Migrations
{
    using a1_hotel.Dal;
    using a1_hotel.Models;
    using Bogus;
    using Bogus.Extensions.Brazil;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.UI.WebControls;

    internal sealed class Configuration : DbMigrationsConfiguration<a1_hotel.Dal.ProjectContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "a1_hotel.Dal.ProjectContext";
        }

        protected override void Seed(a1_hotel.Dal.ProjectContext context)
        {

            List<Client> clients = new List<Client>
            {
                new Client(name:"José Padua", email:"jose@gmail.com", cpf:"000.000.000-00", phoneNumber: "(00)000000000"),
                new Client(name:"Erick do Nascimento", email:"erick@gmail.com", cpf:"000.000.000-01", phoneNumber: "(00)000000001"),
                new Client(name:"Jucielly Macedo", email:"juci@gmail.com", cpf:"000.000.000-02", phoneNumber: "(00)000000002"),
                new Client(name:"Maria Sophia Filho", email:"mariasop@gmail.com", cpf:"000.000.000-03", phoneNumber: "(00)000000003"),
                new Client(name:"Carlos Miguel Neto", email:"carlitos@gmail.com", cpf:"000.000.000-04", phoneNumber: "(00)000000004"),
            };

            clients.ForEach(c => context.Clients.AddOrUpdate(c));
            context.SaveChanges();

            List<RoomType> roomTypes = new List<RoomType> {
                new RoomType(name: "Quarto Simples"),
                new RoomType(name: "Suíte"),
                new RoomType(name: "Suíte Master"),
                new RoomType(name: "Suíte Gold Master"),
            };

            roomTypes.ForEach(r => context.RoomTypes.AddOrUpdate(r));
            context.SaveChanges();

            List<Branch> branches = new List<Branch> {
                new Branch(name: "Filial A", email: "filiala@gmail.com", address:"ARSE 22, Alameda 2, 4", phoneNumber:"(00)000000005"),
                new Branch(name: "Filial B", email: "filialb@gmail.com", address:"ARNE 12, Alameda 6, 2", phoneNumber:"(00)000000006"),
                new Branch(name: "Filial C", email: "filialc@gmail.com", address:"ARSE 15, Alameda 10, 14", phoneNumber:"(00)000000007"),
            };

            branches.ForEach(b => context.Branchs.AddOrUpdate(b));
            context.SaveChanges();

            List<Room> rooms = new List<Room> {
                new Room(name:"Amanhecer da Lua", description:"Um quarto com vista para perfeita para a lua ...", price_per_night: 199.99, available:true, roomTypeID:roomTypes.ElementAt(3).ID, branchID:branches.ElementAt(0).ID),
                new Room(name:"Anoitecer do Sol", description:"Um quarto com vista para perfeita para o sol ...", price_per_night: 199.99, available:true, roomTypeID:roomTypes.ElementAt(3).ID, branchID:branches.ElementAt(0).ID),
                new Room(name:"Flor de Lis", description:"Um quarto com vista para perfeita ...", price_per_night: 159.99, available:false, roomTypeID:roomTypes.ElementAt(2).ID, branchID:branches.ElementAt(0).ID),
                new Room(name:"Florescer da Samambaia", description:"Um quarto com vista para ...", price_per_night: 129.99, available:true, roomTypeID:roomTypes.ElementAt(1).ID, branchID:branches.ElementAt(1).ID),
                new Room(name:"Rio das Ovelhas", description:"Um quarto com vista ...", price_per_night: 119.99, available:true, roomTypeID:roomTypes.ElementAt(0).ID, branchID:branches.ElementAt(2).ID),
                new Room(name:"Ninho de Coelhos", description:"Um quarto com ...", price_per_night: 109.99, available:false, roomTypeID:roomTypes.ElementAt(0).ID, branchID:branches.ElementAt(1).ID),
                new Room(name:"Esperança", description:"Um quarto ...", price_per_night: 59.99, available:true, roomTypeID:roomTypes.ElementAt(1).ID, branchID:branches.ElementAt(0).ID),
                new Room(name:"Casa da Reconciliação", description:"Um quarto com banheiro? ...", price_per_night: 49.99, available:true, roomTypeID:roomTypes.ElementAt(1).ID, branchID:branches.ElementAt(2).ID),
                new Room(name:"Palco da Sobriedade", description:"Um ...", price_per_night: 39.99, available:false, roomTypeID:roomTypes.ElementAt(0).ID, branchID:branches.ElementAt(1).ID),
            };

            rooms.ForEach(r => context.Rooms.AddOrUpdate(r));
            context.SaveChanges();

            List<Booking> bookings = new List<Booking>
            {
                new Booking(entryDate: DateTime.Parse("01/15/2022"), departureDate: DateTime.Parse("01/18/2023"), guests: 2, price: calculatePrice(1, 3), clientID: 1, roomID: 1, status: 1),
                new Booking(entryDate: DateTime.Parse("01/14/2022"), departureDate: DateTime.Parse("01/15/2023"), guests: 3, price: calculatePrice(2, 1), clientID: 2, roomID: 2, status: 1),
                new Booking(entryDate: DateTime.Parse("01/16/2022"), departureDate: DateTime.Parse("01/18/2023"), guests: 1, price: calculatePrice(3, 2), clientID: 4, roomID: 3, status: 2),
                new Booking(entryDate: DateTime.Parse("02/05/2022"), departureDate: DateTime.Parse("02/10/2023"), guests: 0, price: calculatePrice(1, 5), clientID: 5, roomID: 1, status: 1),
                new Booking(entryDate: DateTime.Parse("02/07/2022"), departureDate: DateTime.Parse("02/10/2023"), guests: 1, price: calculatePrice(4, 3), clientID: 3, roomID: 4, status: 2),
                new Booking(entryDate: DateTime.Parse("02/16/2022"), departureDate: DateTime.Parse("02/22/2023"), guests: 0, price: calculatePrice(1, 6), clientID: 2, roomID: 1, status: 1),
                new Booking(entryDate: DateTime.Parse("02/01/2022"), departureDate: DateTime.Parse("02/04/2023"), guests: 0, price: calculatePrice(2, 3), clientID: 1, roomID: 2, status: 1),
                new Booking(entryDate: DateTime.Parse("03/19/2022"), departureDate: DateTime.Parse("03/22/2023"), guests: 2, price: calculatePrice(3, 3), clientID: 4, roomID: 3, status: 1),
                new Booking(entryDate: DateTime.Parse("04/20/2022"), departureDate: DateTime.Parse("04/22/2023"), guests: 3, price: calculatePrice(4, 2), clientID: 5, roomID: 4, status: 1),
                new Booking(entryDate: DateTime.Parse("04/11/2022"), departureDate: DateTime.Parse("04/13/2023"), guests: 4, price: calculatePrice(5, 2), clientID: 1, roomID: 5, status: 1),
                new Booking(entryDate: DateTime.Parse("04/02/2022"), departureDate: DateTime.Parse("04/04/2023"), guests: 1, price: calculatePrice(1, 2), clientID: 2, roomID: 1, status: 1),
                new Booking(entryDate: DateTime.Parse("05/06/2022"), departureDate: DateTime.Parse("05/09/2023"), guests: 3, price: calculatePrice(2, 3), clientID: 4, roomID: 2, status: 1),
                new Booking(entryDate: DateTime.Parse("06/20/2022"), departureDate: DateTime.Parse("06/24/2023"), guests: 1, price: calculatePrice(3, 4), clientID: 3, roomID: 3, status: 2),
                new Booking(entryDate: DateTime.Parse("06/22/2022"), departureDate: DateTime.Parse("06/23/2023"), guests: 0, price: calculatePrice(4, 1), clientID: 5, roomID: 4, status: 1),
                new Booking(entryDate: DateTime.Parse("06/26/2022"), departureDate: DateTime.Parse("06/29/2023"), guests: 0, price: calculatePrice(5, 3), clientID: 1, roomID: 5, status: 2),
                new Booking(entryDate: DateTime.Parse("07/15/2022"), departureDate: DateTime.Parse("07/19/2023"), guests: 0, price: calculatePrice(6, 4), clientID: 3, roomID: 6, status: 1),
                new Booking(entryDate: DateTime.Parse("07/18/2022"), departureDate: DateTime.Parse("07/24/2023"), guests: 1, price: calculatePrice(7, 6), clientID: 2, roomID: 7, status: 2),
            };

            bookings.ForEach(b => context.Bookings.AddOrUpdate(b));
            context.SaveChanges();

            List<Payment> payments = new List<Payment>
            {
                new Payment(booking: bookings.ElementAt(0), status: 1),
                new Payment(booking: bookings.ElementAt(1), status: 1),
                new Payment(booking: bookings.ElementAt(2), status: 2),
                new Payment(booking: bookings.ElementAt(3), status: 1),
                new Payment(booking: bookings.ElementAt(4), status: 2),
                new Payment(booking: bookings.ElementAt(5), status: 1),
                new Payment(booking: bookings.ElementAt(6), status: 1),
                new Payment(booking: bookings.ElementAt(7), status: 1),
                new Payment(booking: bookings.ElementAt(8), status: 1),
                new Payment(booking: bookings.ElementAt(9), status: 1),
                new Payment(booking: bookings.ElementAt(10), status: 1),
                new Payment(booking: bookings.ElementAt(11), status: 1),
                new Payment(booking: bookings.ElementAt(12), status: 2),
                new Payment(booking: bookings.ElementAt(13), status: 1),
                new Payment(booking: bookings.ElementAt(14), status: 2),
                new Payment(booking: bookings.ElementAt(15), status: 1),
                new Payment(booking: bookings.ElementAt(16), status: 2),
            };

            payments.ForEach(p => context.Payments.AddOrUpdate(p));
            context.SaveChanges();
        }

        private double calculatePrice(int roomId, int daysDifference)
        {
            ProjectContext db = new ProjectContext();
            Room room = db.Rooms.Where(r => r.ID == roomId).First();
            double price = room.Price_per_night * daysDifference;
            return price;
        }
    }
}
