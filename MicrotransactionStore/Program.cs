using System.Data;

Console.WriteLine("Välkommen till min butik, du kan välja mellan tre produkter att köpa");
int money = 100;
string[] produkter = ["Potatis", "Tomat", "Chips"];

Dictionary<string, int> dictionary = new Dictionary<string, int>();

dictionary.Add("Potatis", 20);
dictionary.Add("Tomat", 15);
dictionary.Add("Chips", 40);

bool checkOut = false;
int price = 0;

List<string> cart =  new List<string>();

while (!checkOut)
{
    Console.WriteLine("Produkter:");
    for (int i = 0; i < produkter.Length; i++)
    {
        Console.WriteLine($"{i + 1}. {produkter[i]}");
    }
    Console.WriteLine("\n" + "Välj en produkt att köpa med produkterns siffra");
    bool correctParse = false;
    int produkt1 = 0;
    while (!correctParse || produkt1 <= 0 || produkt1 > produkter.Length)
    {
        string produkt1String = Console.ReadLine();
        correctParse = int.TryParse(produkt1String, out produkt1);
        if (!correctParse || produkt1 - 1 < 0 || produkt1 > produkter.Length)
        {
            Console.WriteLine("Skriv ett giltigt siffra");
        }
    }

    if (dictionary.ContainsKey(produkter[produkt1 - 1]))
    {
        money -= dictionary[produkter[produkt1 - 1]];
        cart.Add(produkter[produkt1 - 1]);
        price += dictionary[produkter[produkt1 - 1]];
    }

    Console.WriteLine("Din kundvagn:");
    for (int i = 1; i <= cart.Count; i++)
    {
        Console.WriteLine(cart[i - 1] + $" {dictionary[cart[i - 1]]}kr" + "\n");
    }

    Console.WriteLine("Vill du gå till betalnig, skriv in 'ja', om inte skriv vad som helst och fortsätt att handla");
    string proceedCheckout = Console.ReadLine().ToLower();

    if (proceedCheckout == "ja")
    {
        checkOut = true;
    }


}   

if (money >= price)
{
    Console.WriteLine($"Pris : {price}");
    Console.WriteLine("Tryck enter för att betala" + "\n");
}
else
{
    Console.WriteLine("Du har inte tillräckligt med pengar");
}


Console.ReadLine();
