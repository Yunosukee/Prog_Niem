public static class DataStore
{
    public static List<User> Users { get; set; } = new List<User>();
    public static List<Transaction> Transactions { get; set; } = new List<Transaction>();
    public static List<ProductWithID> Products { get; set; } = new List<ProductWithID>();
}