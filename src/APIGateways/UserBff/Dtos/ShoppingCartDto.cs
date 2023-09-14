
namespace UserBff.Dtos
{
    public class ShoppingCartDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public List<ShoppingCartItemDto> Items { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
