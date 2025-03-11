using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Globalization;
using System.Runtime.Remoting.Messaging;
using System.Xml.Serialization;


namespace Grocery_Store_Discount_Calculator
{
    public class Cashier
    {
        public double CalculateTotalCost(Cart cart)
        {
            double totalCost = 0;
            for (int i = 0; i < cart.Count; i++)
            {
                totalCost += cart.GetItem(i).price * cart.GetItem(i).quantity;
            }
            return totalCost;
        }

        public double CalculateDiscount(double totalCost)
        {
            if (totalCost >= 100)
            {
                return totalCost * 0.1;
            }
            else if (totalCost >= 200)
            {
                return totalCost * 0.15;
            }
            else if (totalCost >= 500)
            {
                return totalCost * 0.2;
            }
            else
            {
                return 0;
            }
        }

        public double CalculateNetTotal(double totalCost, double discount)
        {
            return totalCost - discount;
        }

        public void Reciept(Cart cart)
        {
            double subtotal = CalculateTotalCost(cart);
            double discount = CalculateDiscount(subtotal);
            double grandTotal = CalculateNetTotal(subtotal, discount);
            Console.WriteLine("\n===============================================");
            Console.WriteLine("                    RECEIPT                 ");
            Console.WriteLine("===============================================");
            cart.View();
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine($"Subtotal:                        ${subtotal}");
            Console.WriteLine($"Discount:                        ${discount:F2}");
            Console.WriteLine($"Grand Total:                     ${grandTotal:F2}");
            Console.WriteLine("===============================================");
            Console.WriteLine("          Thank you for your purchase!      ");
            Console.WriteLine("===============================================\n\n");
            cart.RemoveAll();
        }


    }

    public class Cart
    {
        private readonly List<Item> list = new List<Item>();

        public void Add(Item item)
        {
            list.Add(item);
        }

        public bool Remove(string name)
        {
            int index = GetIndex(name);
            if (index != -1)
            {
                list.RemoveAt(index);
                return true;
            }
            return false;
        }

        public bool RemoveAll()
        {
            if (list.Count > 0)
            {
                list.Clear();
            }
            return true;
        }

        public int GetIndex(string name)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].name == name)
                {
                    return i;
                }
            }
            return -1;
        }

        public Item GetItem(int index)
        {
            return list[index];
        }

        public void View()
        {
            string format = "{0,-25} | ${1,-7} | {2,6}";

            Console.WriteLine(format, "Item", "Price", "Quantity");
            Console.WriteLine("===============================================");

            foreach (var item in list)
            {
                Console.WriteLine(format, item.name, item.price.ToString("0.00"), item.quantity);
            }

            Console.WriteLine("===============================================\n");
        }

        public int Count => list.Count;
    }

    public class Item
    {
        public readonly string name;
        public readonly double price;
        public readonly int quantity;

        public Item(string name, double price, int quantity)
        {
            this.name = name;
            this.price = price;
            this.quantity = quantity;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Cashier cashier = new Cashier();
            Cart cart = new Cart();

            int choice;
            do
            {
                MainMenu();
                choice = EnterInt("Enter your choice: ");

                switch (choice)
                {
                    case 1:
                        // vegetable
                        int choice1;
                        do
                        {
                            VegetableMenu();
                            choice1 = EnterInt("Enter  your choice: ");
                            int quantity;
                            switch (choice1)
                            {
                                case 1:
                                    quantity = EnterInt("Enter quantity: ");
                                    cart.Add(new Item("Kamungay", 2.1, quantity));
                                    Console.WriteLine("Item added to cart");
                                    break;
                                case 2:
                                    quantity = EnterInt("Enter quantity: ");
                                    cart.Add(new Item("Kamatis", 2.4, quantity));
                                    Console.WriteLine("Item added to cart");
                                    break;
                                case 3:
                                    quantity = EnterInt("Enter quantity: ");
                                    cart.Add(new Item("Sibuyas", 4.2, quantity));
                                    Console.WriteLine("Item added to cart");
                                    break;
                                case 4:
                                    quantity = EnterInt("Enter quantity: ");
                                    cart.Add(new Item("Ahos", 5.6, quantity));
                                    Console.WriteLine("Item added to cart");
                                    break;
                                case 5:
                                    quantity = EnterInt("Enter quantity: ");
                                    cart.Add(new Item("Luy-a", 3.2, quantity));
                                    Console.WriteLine("Item added to cart");
                                    break;
                                case 6:
                                    break;
                                default:

                                    Console.WriteLine("Invalid choice");
                                    break;
                            }
                        } while (choice1 != 6);
                        break;
                    case 2:
                        // meat                        
                        int choice2;
                        do
                        {

                            MeatMenu();
                            choice2 = EnterInt("Enter your choice: ");
                            int quantity2;
                            switch (choice2)
                            {
                                case 1:
                                    quantity2 = EnterInt("Enter quantity: ");
                                    cart.Add(new Item("A5 Wagyu", 500.25, quantity2));
                                    Console.WriteLine("Item added to cart");
                                    break;
                                case 2:
                                    quantity2 = EnterInt("Enter quantity: ");
                                    cart.Add(new Item("Ribeye", 100.2, quantity2));
                                    Console.WriteLine("Item added to cart");
                                    break;
                                case 3:
                                    quantity2 = EnterInt("Enter quantity: ");
                                    cart.Add(new Item("Magnolia Chicken", 2.1, quantity2));
                                    Console.WriteLine("Item added to cart");
                                    break;
                                case 4:
                                    quantity2 = EnterInt("Enter quantity: ");
                                    cart.Add(new Item("Pork", 5.5, quantity2));
                                    Console.WriteLine("Item added to cart");
                                    break;
                                case 5:
                                    quantity2 = EnterInt("Enter quantity: ");
                                    cart.Add(new Item("Brisket", 60.23, quantity2));
                                    Console.WriteLine("Item added to cart");
                                    break;
                                case 6:
                                    break;
                                default:

                                    Console.WriteLine("Invalid choice");
                                    break;
                            }
                        } while (choice2 != 6);
                        break;
                    case 3:
                        // liquor                     
                        int choice3;
                        do
                        {

                            LiquorMenu();
                            choice3 = EnterInt("Enter your choice: ");
                            int quantity3;
                            switch (choice3)
                            {
                                case 1:
                                    quantity3 = EnterInt("Enter quantity: ");
                                    cart.Add(new Item("Vodka(Absolut Vodka)", 20.99, quantity3));
                                    Console.WriteLine("Item added to cart");
                                    break;
                                case 2:
                                    quantity3 = EnterInt("Enter quantity: ");
                                    cart.Add(new Item("Beer(RedHorse)", 2.89, quantity3));
                                    Console.WriteLine("Item added to cart");
                                    break;
                                case 3:
                                    quantity3 = EnterInt("Enter quantity: ");
                                    cart.Add(new Item("Wine(SAUVIGNON BLANC)", 14.38, quantity3));
                                    Console.WriteLine("Item added to cart");
                                    break;
                                case 4:
                                    quantity3 = EnterInt("Enter quantity: ");
                                    cart.Add(new Item("Tequila(Casamigos)", 20.00, quantity3));
                                    Console.WriteLine("Item added to cart");
                                    break;
                                case 5:
                                    quantity3 = EnterInt("Enter quantity: ");
                                    cart.Add(new Item("Rum(BACARDI)", 100.00, quantity3));
                                    Console.WriteLine("Item added to cart");
                                    break;
                                case 6:
                                    break;
                                default:

                                    Console.WriteLine("Invalid choice");
                                    break;
                            }
                        } while (choice3 != 6);
                        break;
                    case 4:
                        // cart
                        cart.View();
                        CartMenu();
                        int choice4 = EnterInt("Enter your choice: ");
                        switch (choice4)
                        {
                            case 1:
                                string name = EnterString("Enter item name to remove: ");
                                if (cart.Remove(name))
                                {
                                    Console.WriteLine("Item removed from cart");
                                }
                                else
                                {
                                    Console.WriteLine("Item not found in cart");
                                }
                                break;
                            case 2:
                                cashier.Reciept(cart);
                                break;
                            case 3:
                                break;
                            default:
                                Console.WriteLine("Invalid choice");
                                break;
                        }
                        break;
                    case 5:
                        cart.Add(new Item(
                            EnterString("Enter item name: "),
                            EnterDouble("Enter item price: "),
                            EnterInt("Enter item quantity: ")));
                        Console.WriteLine("Item added to cart");
                        break;
                    case 6:
                        Console.WriteLine("Thank you for shopping at Joshua Sarry sarry store");
                        break;
                    default:

                        Console.WriteLine("Invalid choice");
                        break;
                }
            } while (choice != 6);

        }

        static void MainMenu()
        {

            Console.WriteLine("\n[WELCOME TO JOSHUA SARRY SARRY STORE]\n");
            Console.WriteLine("Select 1 to Vegetable Section");
            Console.WriteLine("Select 2 to Meat/Pork Section");
            Console.WriteLine("Select 3 to Liquor Section");
            Console.WriteLine("Select 4 to Check Cart");
            Console.WriteLine("Select 5 to Add Custom Item");
            Console.WriteLine("Select 6 to Exit\n");
        }

        //vegetable menu
        static void VegetableMenu()
        {
            Console.WriteLine("\nSelect your item:");
            Console.WriteLine("1. Kamungay  -  $2.1");
            Console.WriteLine("2. Kamatis   -  $2.4");
            Console.WriteLine("3. Sibuyas   -  $4.2");
            Console.WriteLine("4. Ahos      -  $5.6");
            Console.WriteLine("5. Luy-a     -  $3.2");
            Console.WriteLine("6. Return to Main Menu\n");
        }

        //liqour menu
        static void LiquorMenu()
        {
            Console.WriteLine("\nSelect your item");
            Console.WriteLine("1. Vodka(Absolut Vodka)   -  $20.99");
            Console.WriteLine("2. Beer(RedHorse)         -  $ 2.89");
            Console.WriteLine("3. Wine(SAUVIGNON BLANC)  -  $14.38");
            Console.WriteLine("4. Tequila(Casamigos)     -  $20.00");
            Console.WriteLine("5. Rum(BACARDI)           -  $100.00");
            Console.WriteLine("6. Return to Main Menu\n");
        }

        //meat menu
        static void MeatMenu()
        {
            Console.WriteLine("\nSelect your item:");
            Console.WriteLine("1. A5 Wagyu           -  $500.25");
            Console.WriteLine("2. Ribeye             -  $100.2");
            Console.WriteLine("3. Magnolia Chicken   -  $2.1");
            Console.WriteLine("4. Pork               -  $5.5");
            Console.WriteLine("5. Brisket            -  $60.23");
            Console.WriteLine("6. Return to Main Menu.\n");
        }

        static void CartMenu()
        {
            Console.WriteLine("\nSelect 1 to Remove Item");
            Console.WriteLine("Select 2 to Check Out");
            Console.WriteLine("Select 3 to Return to Main Menu\n");
        }

        static string EnterString(string prompt)
        {
            string input = "";
            while (true)
            {
                Console.Write(prompt);
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                    Console.WriteLine("Your input cannot be empty. Please try again.");
                else break;
            }
            return input;
        }

        static int EnterInt(string prompt)
        {
            string input = "";
            while (true)
            {
                Console.Write(prompt);
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                    Console.WriteLine("Your input cannot be empty. Please try again.");
                else if (ContainsLetter(input))
                    Console.WriteLine("Error. There is a character that is not a number.");
                else break;
            }
            return int.Parse(input);
        }

        static double EnterDouble(string prompt)
        {
            string input = "";
            while (true)
            {
                Console.Write(prompt);
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                    Console.WriteLine("Your input cannot be empty. Please try again.");
                else if (ContainsLetter(input))
                    Console.WriteLine("Error. There is a character that is not a number.");
                else break;
            }
            return double.Parse(input);
        }

        private static bool ContainsLetter(string input)
        {
            foreach (char c in input)
            {
                if (char.IsLetter(c))
                    return true;
            }
            return false;
        }
    }
}