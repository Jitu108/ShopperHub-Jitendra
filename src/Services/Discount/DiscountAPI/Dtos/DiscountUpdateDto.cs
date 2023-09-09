namespace DiscountAPI.Dtos
{
    public class DiscountUpdateDto
    {
        public int ProductId { get; set; }
        public decimal Discount { get; set; }
        public bool IsPercent { get; set; }

    }
}
