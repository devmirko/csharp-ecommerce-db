// See https://aka.ms/new-console-template for more information
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.ConstrainedExecution;

Console.WriteLine("Hello, World!");

CommerceContext db = new CommerceContext();
Console.WriteLine("Benvenuti da Unieuro");
Console.WriteLine("Sei un cliente o un dipendente");
Console.WriteLine("1- dipendente");
Console.WriteLine("2- cliente");
Console.WriteLine("3- esci");

int response = Convert.ToInt32(Console.ReadLine());
Employee.AddEmployee();
Customer.AddCustomer();
bool semaforo = true;

switch (response)
{
	case 1:
		while (semaforo)
		{
            Product.AddProduct();
            Console.WriteLine("benvenuto dipendente");
            Console.WriteLine("1 - visualizza tutti i prodotti");
            Console.WriteLine("2 - aggiungi un ordine");
            Console.WriteLine("3 - visualizza gli ordini");
            Console.WriteLine("4 - elimina un ordine");
            Console.WriteLine("5 - modifica un ordine");
            int risposta = Convert.ToInt32(Console.ReadLine());
            switch (risposta)
            {
                case 1:
                    Product.StampaProduct();
                    break;
                case 2:
                    Product.StampaProduct();
                    Console.WriteLine("inserisci il prodotto che vuoi ordinare");
                    string nomeProdotto = Console.ReadLine();
                    NewOrder(nomeProdotto);


                    break;
                case 3:
                    ListaOrdini();

                    break;
                case 4:
                    Console.WriteLine("inserisci id del ordine che vuoi eliminare");
                    ListaOrdini();
                    int idUser = Convert.ToInt32(Console.ReadLine());
                    Delete(idUser);
                    break;
                case 5:
                    Console.WriteLine("inserisci id del ordine che vuoi modificare");
                    ListaOrdini();
                    int idUserMod = Convert.ToInt32(Console.ReadLine());
                    ModificaOrdine(idUserMod);

                    break;
                default:
                    break;

            }
           

        }
        break;
    case 2:
        while (semaforo)
        {
            Console.Write("Ciao, inserisci il tuo nome: ");
            string name = Console.ReadLine();
            Console.Write("Il tuo cognome: ");
            string surname = Console.ReadLine();
            Customer RicercaCliente = db.Customers.Where(customer => customer.Name == name || customer.Surname == surname).FirstOrDefault();

            if (RicercaCliente != null)
            {
                ListaOrdini();
                Console.Write("inserisci il numero del ordine che vuoi acquistare");
                int idUserMod = Convert.ToInt32(Console.ReadLine());
                Order ordineRicercato = db.Orders.Where(i => i.OrderId == idUserMod).FirstOrDefault();
                ordineRicercato.CustomerId = RicercaCliente.CustomerId;
                db.SaveChanges();
                Console.Write("l'ordine è stato effettuato correttamente");

            }

        }
        break;
    default:
		break;
}

void NewOrder(string nome)
{
    CommerceContext db = new CommerceContext();
    Product product = db.Products.Where(prodotto => prodotto.Name == nome).First();
    List<Product> products = new List<Product>();
    products.Add(product);
    int randomCustomer = new Random().Next(1, 3);
    Customer customer = db.Customers.Where(c => c.CustomerId == randomCustomer).First();
    int randomemployee = new Random().Next(1, 3);
    Employee employee = db.Employees.Where(e => e.EmployeeId == randomemployee).First();
    int random = new Random().Next(0, 2);
    bool stato = false;
    if (random == 1) {
        stato = true;
    }
        
    Order order = new Order() { date = new DateTime(), Amount = product.price, Status = stato, EmployeeId = employee.EmployeeId, CustomerId = customer.CustomerId, ProductOrder = products};
    db.Orders.Add(order);
    db.SaveChanges();


}

void ListaOrdini()
{
    CommerceContext db = new CommerceContext();
    List<Order> orders = db.Orders.ToList();
    int i = 0;
    foreach (Order order in orders)
    {
        
        
     Console.WriteLine((i + 1) + " - " + order.EmployeeId + "-" + order.date + "-" + order.Status);
     i++;
        
        
    }
}

void Delete(int id)
{
    CommerceContext db = new CommerceContext();
    Order order = db.Orders.Where(i => i.OrderId == id).First();
    if( order == null)
    {
        Console.WriteLine("non hai trovato nessun ordine");

    }

    db.Orders.Remove(order);
    db.SaveChanges();



}

void ModificaOrdine(int id)
{
    CommerceContext db = new CommerceContext();
    Order order = db.Orders.Where(o => o.OrderId == id).FirstOrDefault();
    Console.WriteLine("inserisci il nuovo prezzo");
    int price = Convert.ToInt32(Console.ReadLine());
    order.Amount = price;
    Console.WriteLine("inserisci una nuova data");
    string DataStringa = Console.ReadLine();
    DateTime data = DateTime.Parse(DataStringa);
    order.date = data;
    db.SaveChanges();

}











