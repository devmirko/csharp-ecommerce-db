// See https://aka.ms/new-console-template for more information
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.ConstrainedExecution;

Console.WriteLine("Hello, World!");
Console.WriteLine("Hello, World!");

//Seconda Parte
//Considerando che:
//ci sono clienti che effettuano ordini.
//Un ordine viene preparato da un dipendente.
//Un ordine ha associato uno o più pagamenti (considerando eventuali tentativi falliti)

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
            Console.WriteLine("1- visualizza tutti i prodotti");
            Console.WriteLine("2- aggiungi un ordine");
            Console.WriteLine("3- visualizza gli ordini");
            Console.WriteLine("3- modifica un ordine");
            int risposta = Convert.ToInt32(Console.ReadLine());
            switch (risposta)
            {
                case 1:
                    Product.StampaProduct();
                    break;
                case 2:
                    Console.WriteLine("inserisci il prodotto che vuoi ordinare");
                    string nomeProdotto = Console.ReadLine();
                    NewOrder(nomeProdotto);


                    break;
                case 3:
                    ListaOrdini();

                    break;
                default:
                    break;

            }
            
            //aggiugni un ordine
            //elimina un ordine
            //modifica un ordine
            //esci


        }
        break;
    case 2:
        while (semaforo)
        {

            //fai un ordine

        }
        break;
    case 3:
       
        break;
    default:
		break;
}

void NewOrder(string nome)
{
    CommerceContext db = new CommerceContext();
    Product product = db.Products.Where(prodotto => prodotto.Name == nome).First();

    Customer customer = db.Customers.First();

    Employee employee = db.Employees.First();
    int random = new Random().Next(0, 2);
    bool stato = false;
    if (random == 1) {
        stato = true;
    }
        




    Order order = new Order() { date = new DateTime(), Amount = product.price, Status = stato, EmployeeId = employee.EmployeeId, CustomerId = customer.CustomerId };
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
        Console.WriteLine((i + 1) + " - " + order.EmployeeId + "" + order.date );
        i++;
    }



    
}











