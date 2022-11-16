// See https://aka.ms/new-console-template for more information
public class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public string description { get; set; }

    public int price { get; set; }
    public List<Order> OrderProduct { get; set; }
}
