namespace Principle.Models {
    // العميل
    public class Client {
        public Guid Id { get; }
        public string Name { get; }
        public string CompanyName { get; }
        public string PhoneNumber { get; }
        public string Email { get; }
        public Client(string name, string companyName, string phoneNumber, string email) {
            Id = Guid.NewGuid();
            Name = name;
            CompanyName = companyName;
            PhoneNumber = phoneNumber;
            Email = email;
        }
        public override string ToString() {
            return $"""
                    Client Id     : {Id}
                    Name          : {Name}
                    Company       : {CompanyName}
                    Phone         : {PhoneNumber}
                    Email         : {Email}
                    """;
        }
    }
}

