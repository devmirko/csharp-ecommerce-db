// See https://aka.ms/new-console-template for more information
public class Payment
{
    public int PaymentId { get; set; }
    public DateTime date { get; set; }
    public int Amount { get; set; }

    public bool  Status { get; set; }

    public int OrderId { get; set; }

    public Order Order { get; set; }



}