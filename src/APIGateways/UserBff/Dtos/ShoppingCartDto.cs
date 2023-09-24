
namespace UserBff.Dtos
{
    public class ShoppingCartDto
    {
        //public ShoppingCartDto() { }
        //public ShoppingCartDto(int userId)
        //{
        //    this.UserId = userId;
        //}

        public int UserId { get; set; }
        public List<ShoppingCartItemDto> Items { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
