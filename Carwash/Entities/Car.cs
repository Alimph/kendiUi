namespace Carwash.Entities
{
    public class Car
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<Service> Services{ get; set; }
    }
}
