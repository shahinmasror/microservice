namespace DiscountAPI.Models
{
    public class Cupon
    {
        public int Id { get; set; }
        public string ProductId { get; set; }

        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }

    }


    public class CuponDTO
    {
        public int id { get; set; }
        public string name { get; set; }


    }
}
