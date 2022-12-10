namespace CustomersAPI.Models
{
    public class Customers
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public long Phone { get; set; }
        public string? City { get; set; }
        public string? Address { get; set; }
    }
}
