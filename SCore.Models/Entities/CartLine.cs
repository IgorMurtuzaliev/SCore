namespace SCore.Models
{
    public class CartLine
    {
        public CartLine()
        {

        }
        public int CartLineId { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}