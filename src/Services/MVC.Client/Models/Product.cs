namespace MVC.Client.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // The price provided by the seller
        public decimal UnitPrice { get; set; }

        // The price provided by the Discount Service
        public decimal OfferPrice { get; set; }

        public int AvailableQuantity { get; set; }

        // The Price shown to the User
        // If the Offer Price has been set by Discount Service, show that price,
        // Else show Unit Price
        public decimal DiscountedPrice { get; set; }
    }
}
