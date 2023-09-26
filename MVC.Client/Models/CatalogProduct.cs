namespace MVC.Client.Models
{
    public class CatalogProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // The price provided by the seller
        public decimal UnitPrice { get; set; }

        // The price provided by the Discount Service
        public decimal OfferPrice { get; set; }

        public decimal Discount => UnitPrice - OfferPrice;

        public int Quantity { get; set; }
        public int AvailableQuantity { get; set; }
    }
}
