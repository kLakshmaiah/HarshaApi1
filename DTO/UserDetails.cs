namespace HarshaApi1.DTO
{
    public class UserDetails
    {
        public string? UserName { get; set; }
        public string? UserRole { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? RoleDescription { get; set; }
        public string? PhoneNumber { get; set; }
        public string? CompayName { get; set; }

        public override string ToString()
        {
            return $"{nameof(UserName)} is {UserName} {nameof(UserRole)} is {UserRole} {nameof(Password)} is {Password} {nameof(Email)} is {Email} {nameof(RoleDescription)} is {RoleDescription}" +
                $" {nameof(PhoneNumber)} is {PhoneNumber}  {nameof(CompayName)} is {CompayName}";
        }
    }
}
