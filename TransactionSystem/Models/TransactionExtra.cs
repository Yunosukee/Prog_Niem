namespace TransactionSystem.Models
{
    public class TransactionExtra : TransactionWithID
    {
        public string? Customer_name { get; set; }
        public string? Product_name { get; set; }
        public long Price { get; set; }
    }
}
