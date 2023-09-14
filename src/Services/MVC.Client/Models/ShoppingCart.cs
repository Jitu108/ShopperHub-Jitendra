namespace MVC.Client.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public List<ShoppingCartItem> Items { get; set; }
        public decimal TotalPrice { get; set; }

        public class ShoppingCartItem
        {
            public int Id { get; set; }
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public decimal UnitPrice { get; set; }
            public int Quantity { get; set; }
        }
    }
}
