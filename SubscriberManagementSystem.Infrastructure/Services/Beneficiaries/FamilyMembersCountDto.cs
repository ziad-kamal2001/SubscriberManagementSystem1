namespace SubscriberManagementSystem.Infrastructure.Services.Beneficiaries
{
  
    public class FamilyMembersCountDto
    {
        // Females
        public int Female0To2 { get; set; }
        public int Female3To5 { get; set; }
        public int Female6To18 { get; set; }
        public int Female19To59 { get; set; }
        public int Female60Plus { get; set; }

        // Males
        public int Male0To2 { get; set; }
        public int Male3To5 { get; set; }
        public int Male6To18 { get; set; }
        public int Male19To59 { get; set; }
        public int Male60Plus { get; set; }

        // Aggregate indicators
        public int ChronicIllnessCount { get; set; }
        public int DisabledCount { get; set; }
        public int MartyrsCount { get; set; }
        public int InjuredCount { get; set; }
    }
}
