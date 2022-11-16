// See https://aka.ms/new-console-template for more information
public class Order
{
    public int OrderId { get; set; }
    public DateTime date { get; set; }
    public int Amount { get; set; }
    public bool Status { get; set; }

    //chiavi esterne
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }

    public int CustomerId { get; set; }

    public Customer Customer { get; set; }

    public List<Product> ProductOrder { get; set; }

    public List<Payment> PaymentOrder { get; set; }


}
