using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Elm St", "Provo", "UT", "USA");
        Customer customer1 = new Customer("Alice Johnson", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Notebook", "A001", 2.50, 4));
        order1.AddProduct(new Product("Pen", "B002", 1.25, 6));

        Address address2 = new Address("45 Queen St", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Bob Smith", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Book", "C003", 15.00, 1));
        order2.AddProduct(new Product("Backpack", "D004", 30.00, 1));
        order2.AddProduct(new Product("Water Bottle", "E005", 10.00, 2));

        DisplayOrder(order1);
        Console.WriteLine("----------------------------");
        DisplayOrder(order2);
    }

    static void DisplayOrder(Order order)
    {
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine("Total Price: $" + order.GetTotalPrice().ToString("0.00"));
        Console.WriteLine();
    }
}
