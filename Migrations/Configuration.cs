namespace a1_hotel.Migrations
{
    using a1_hotel.Models;
    using Bogus;
    using Bogus.Extensions.Brazil;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

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
        }
    }
}
