namespace CodingExercise.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string OrderDescription { get; set; }
        public int Cost { get; set; }
    }
}
