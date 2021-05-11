namespace WebAPI.Data.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}
