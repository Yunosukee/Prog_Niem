public static class DataStore
{
    public static List<Transaction> Transactions { get; set; } = new List<Transaction>();
    public static List<string> Products { get; set; } = new List<string> { "Produkt 1", "Produkt 2", "Produkt 3" };
}