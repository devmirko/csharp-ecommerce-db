// See https://aka.ms/new-console-template for more information
public class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public string description { get; set; }

    public int price { get; set; }
    public List<Order> OrderProduct { get; set; }

    public static void AddProduct()
    {

        CommerceContext db = new CommerceContext();
        //creo una lista di prodotti
        List<Product> products = new List<Product>();
        //aggiugo alla lista 
        products.Add(new Product { Name = "xbox", description = "console", price = 499 });
        products.Add(new Product { Name = "Playstation", description = "console", price = 499 });
        products.Add(new Product { Name = "Nintendo", description = "console", price = 299 });
        products.Add(new Product { Name = "hp", description = "pc", price = 299 });
        products.Add(new Product { Name = "lenovo", description = "pc", price = 499 });
        products.Add(new Product { Name = "macbook", description = "pc", price = 999 });
        products.Add(new Product { Name = "samsung", description = "phone", price = 999 });
        products.Add(new Product { Name = "iphone", description = "phone", price = 1299 });
        products.Add(new Product { Name = "xiami", description = "phone", price = 299 });
        products.Add(new Product { Name = "apple watch", description = "smartwatch", price = 499 });
        //faccio un for ed inserisco nel db 
        foreach (Product product in products)
        {
            db.Products.Add(product);
        }

        db.SaveChanges();

    }

    public static void StampaProduct()
    {
        CommerceContext db = new CommerceContext();
        List<Product> products = db.Products.ToList<Product>();
        int i = 0;
        foreach (Product product in products)
        {
            Console.WriteLine(++i + " - " + product.Name + " - " + product.description + " - " + product.price + "€");
        }



    }
}
