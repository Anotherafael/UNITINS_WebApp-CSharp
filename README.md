# Web Application in C# (with Entity Framework)

Um projeto desenvolvido para concluir o a discplina de Tópicos de Programação III na Universidade Estadual do Tocantins (UNITINS)

Sua função principal é gerenciar as atividades de reserva de quartos/apartamentos/kitnets/... Neste projeto estão inclusas as funções de:
- criar, editar, visualizar e deletar das entidades: 
  - Booking (Reserva);
  - Branch (Filial);
  - Client (Cliente); 
  - Payment (Pagamento); 
  - Room (Quarto);
  - RoomType (Tipo de Quarto);
- validações:
  - CPF (Formatação e Singularidade);
  - Email (Formatação e Singularidade);
  - PhoneNumber (Formatação e Singularidade);
  - EntryDate e Departure Date (Não é permitido o cadastro de uma Data de Saída anterior ou igual a Data de Entrada)
  - Status (Ao atualizar o Status de Pagamento será atualizado automaticamente o Status da Reserva)
  - Price (Não é permitido o cadastro de preços negativos)
- migration e seeds:

# Rodar o projeto

## OBS: É necessário a instalação do VisualStudio e SQLServer.

1️⃣ Primeiro faça a extração do conteúdo desse git.

2️⃣ Execute a aplicação 'a1-hotel.sln'.

3️⃣ Altere no web.config para o endereço de conexão do SQL Server da sua máquina 'Data Source'.

4️⃣ Execute no Package Manager Console o código: 'Update-Database'. Para assim criar o banco de dados a partir da migration.

5️⃣ Compile o projeto. 👍

 
