namespace Model
{
    public class Medicine
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public VerificationType Verification { get; set; }

        public Medicine(int id, string name)
        {
            Id = id;
            Name = name;
            Verification = VerificationType.needsVerification;
        }
    }
}