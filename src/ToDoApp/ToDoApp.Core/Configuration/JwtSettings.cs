namespace ToDoApp.Core.Configuration
{
    public class JwtSettings
    {
        public string Secret { get; set; }
        public TokenGeneration TokenGeneration { get; set; }
    }
    public class TokenGeneration
    {
        public string ClaimType { get; set; }
        public int DaysUntilExpiration { get; set; }
        public string HashingAlgorithm { get; set; }
    }
}
