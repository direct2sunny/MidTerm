using System;

public class InventoryItem
{
    // Properties
    public string ItemName { get; set; }
    public int ItemId { get; set; }
    public double Price { get; set; }
    public int QuantityInStock { get; set; }

    // Constructor
    public InventoryItem(string itemName, int itemId, double price, int quantityInStock)
    {
        ItemName = itemName;
        ItemId = itemId;
        Price = price;
        QuantityInStock = quantityInStock;
    }

    // Methods

    /// Updates the price of the item to the new price specified.
    /// <param name="newPrice">The new price for the item.</param>
    public void UpdatePrice(double newPrice)
    {
        Price = newPrice;
    }

    /// Increases the item's stock quantity by the additional quantity specified.
    /// <param name="additionalQuantity">The quantity to add to the item's stock.</param>
    public void RestockItem(int additionalQuantity)
    {
        QuantityInStock += additionalQuantity;
    }

    /// Decreases the item's stock quantity by the specified amount, ensuring the quantity does not go negative.
    /// <param name="quantitySold">The quantity of the item to sell.</param>
    /// <returns>True if the sale was successful; otherwise, false.</returns>
    public bool SellItem(int quantitySold)
    {
        if (QuantityInStock >= quantitySold)
        {
            QuantityInStock -= quantitySold;
            return true;
        }
        else
        {
            Console.WriteLine("Error: Items are not enough in stock.");
            return false;
        }
    }

    /// Checks if the item is currently in stock.
    /// <returns>True if the item's quantity in stock is greater than 0; otherwise, false.</returns>
    public bool IsInStock()
    {
        return QuantityInStock > 0;
    }

    /// Prints the details of the item, including its name, ID, price, and quantity in stock.
    public void PrintDetails()
    {
        Console.WriteLine($"Item Name: {ItemName}, Item ID: {ItemId}, Price: ${Price}, Quantity in Stock: {QuantityInStock}");
    }
}

class Program
{
    /// The main entry point for the application.
    /// <remarks>
    /// This method demonstrates the functionality of the InventoryItem class by allowing the user to create an item and perform various actions such as restocking, selling, checking stock, and updating the price.
    /// </remarks>
    static void Main(string[] args)
    {
        Console.WriteLine("Enter item name:");
        string itemName = Console.ReadLine();

        Console.WriteLine("Enter item ID:");
        int itemId = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter price:");
        double price = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter quantity in stock:");
        int quantityInStock = int.Parse(Console.ReadLine());

        InventoryItem item = new InventoryItem(itemName, itemId, price, quantityInStock);

        bool running = true;
        while (running)
        {
            Console.WriteLine("\nChoose an action:");
            Console.WriteLine("1. Print item details");
            Console.WriteLine("2. Sell item");
            Console.WriteLine("3. Restock item");
            Console.WriteLine("4. Check if item is in stock");
            Console.WriteLine("5. Update price");
            Console.WriteLine("6. Exit");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    item.PrintDetails();
                    break;
                case "2":
                    Console.WriteLine("Enter quantity to sell:");
                    int quantitySold = int.Parse(Console.ReadLine());
                    bool success = item.SellItem(quantitySold);
                    if (success)
                    {
                        Console.WriteLine("Item sold.");
                    }
                    break;
                case "3":
                    Console.WriteLine("Enter additional quantity to restock:");
                    int additionalQuantity = int.Parse(Console.ReadLine());
                    item.RestockItem(additionalQuantity);
                    Console.WriteLine("Item restocked.");
                    break;
                case "4":
                    // Modified to show quantity in stock
                    Console.WriteLine($"{item.ItemName} is {(item.IsInStock() ? "in stock" : "not in stock")}, Quantity in Stock: {item.QuantityInStock}.");
                    break;
                case "5":
                    Console.WriteLine("Enter new price:");
                    double newPrice = double.Parse(Console.ReadLine());
                    item.UpdatePrice(newPrice);
                    Console.WriteLine("Price updated.");
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option, try again.");
                    break;
            }
        }
    }
}
