using System.Text.Json.Serialization;

namespace BasketAPI.Models
{
    public class ShoppingCart
    {

        public ShoppingCart(string name)
        {
            Name = name;
        }
        public ShoppingCart() { }
        public string Name {  get; set; }
        public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();
        public decimal TotalPrice
        {
            get
            {
                decimal toatalprice = 0;
                foreach (var item in Items)
                {
                    toatalprice += item.Price;
                }
                return toatalprice;
            }
        }

    }


    public class ShoppingCarDto
    {
        public string Name { get; set; }
        public List<ShoppingCartItem> Items { get; set; }
        public decimal TotalPrice { get; set; }
        
    }

}
