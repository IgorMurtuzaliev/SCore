namespace SCore.Models
{
    public class CartLine
    {
        public CartLine()
        {

        }
        public int CartLineId { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
    }
}