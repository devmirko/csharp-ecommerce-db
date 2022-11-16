// See https://aka.ms/new-console-template for more information
public class Customer
{
    public int CustomerId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }

    public string Email { get; set; }

    public List<Order> CustomerOrder { get; set; }


    public static void AddCustomer()
    {

        CommerceContext db = new CommerceContext();
        //creo una lista di utenti
        List<Customer> customers = new List<Customer>();
        //aggiugo alla lista 
        customers.Add(new Customer { Name = "gianni", Surname = "pintus",Email = "gianni@gmail.com" });
        customers.Add(new Customer { Name = "gino", Surname = "fazio", Email = "gino@gmail.com" });
        customers.Add(new Customer { Name = "Mario", Surname = "Polli", Email = "Mario@gmail.com" });
        //faccio un for ed inserisco nel db 
        foreach (Customer customer in customers)
        {
            db.Customers.Add(customer);
        }

        db.SaveChanges();

    }


}

