namespace Carwash.Entities
{
    public class Service
    {
        public long Id { get; set; }
        public long CarId { get; set; }
        public DateTime Time { get; set; }
        public string CustomerName { get; set; }
        public string NumberPhone { get; set; }
        public bool IsCompleted { get; set; }
        public Car Car { get; set; }
    }
}
