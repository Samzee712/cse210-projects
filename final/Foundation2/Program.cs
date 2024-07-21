public class Program
{
    public static void Main()
    {
        var address1 = new Address("56 Main St", "Springfield", "IL", "USA");
        var address2 = new Address("456 Maple Ave", "Toronto", "ON", "Canada");
        var address3 = new Address("Etta Agbor", "Cross River", "Calabar", "Nigeria");

        var customer1 = new Customer("John White", address1);
        var customer2 = new Customer("Janet Sampson", address2);
        var customer3 = new Customer("Sam Larry", address3);

        var product1 = new Product("Laptop", "A173", 999.99, 1);
        var product2 = new Product("Mouse", "B956", 19.99, 2);
        var product3 = new Product("Keyboard", "C089", 49.99, 1);
        var product4 = new Product("Printing Machine", "G759T", 109.58, 1);

        var order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        var order2 = new Order(customer2);
        order2.AddProduct(product3);

        var order3 = new Order(customer3);
        order3.AddProduct(product4);

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost():F2}\n");

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.GetTotalCost():F2}\n");

        Console.WriteLine(order3.GetPackingLabel());
        Console.WriteLine(order3.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order3.GetTotalCost():F2}\n");
    }
}
