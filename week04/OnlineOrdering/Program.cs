using System;

class Program
{
    static void Main(string[] args)
    {
        // Order 1: USA Customer
        Address address1 = new Address("123 Maple Street", "Seattle", "WA", "USA");
        Customer customer1 = new Customer("John Doe", address1);
        Order order1 = new Order(customer1);

        Product product1 = new Product("Ergonomic Keyboard", "KBD-100", 79.99, 1);
        Product product2 = new Product("Wireless Mouse", "MS-200", 29.99, 2);
        Product product3 = new Product("USB-C Hub", "HUB-300", 19.99, 1);

        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);

        // Order 2: International Customer (Non-USA)
        Address address2 = new Address("456 Rue de Rivoli", "Paris", "Île-de-France", "France");
        Customer customer2 = new Customer("Marie Dubois", address2);
        Order order2 = new Order(customer2);

        Product product4 = new Product("Leather Journal", "JNL-500", 15.50, 3);
        Product product5 = new Product("Fountain Pen", "PEN-600", 45.00, 1);

        order2.AddProduct(product4);
        order2.AddProduct(product5);

        // Display Order 1 Details
        Console.WriteLine("===============================================================================");
        Console.WriteLine("                           ONLINE ORDER PROCESSING                             ");
        Console.WriteLine("===============================================================================");
        Console.WriteLine();
        Console.WriteLine("---------------------------------- ORDER #1 -----------------------------------");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine($"Total Cost: ${order1.CalculateTotalCost():F2} (includes USA shipping of $5.00)");
        Console.WriteLine();

        // Display Order 2 Details
        Console.WriteLine("---------------------------------- ORDER #2 -----------------------------------");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine($"Total Cost: ${order2.CalculateTotalCost():F2} (includes International shipping of $35.00)");
        Console.WriteLine();
        Console.WriteLine("===============================================================================");
    }
}