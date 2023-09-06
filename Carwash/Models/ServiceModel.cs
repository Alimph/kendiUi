using Carwash.Entities;

namespace Carwash.Models
{
    public class ServiceModel
    {
        public long Id { get; set; }
        public long CarId { get; set; }
        public string CarName { get; set; }
        public string Time { get; set; }
        public string CustomerName { get; set; }
        public string NumberPhone { get; set; }
        public bool IsCompleted { get; set; }
    }
}
