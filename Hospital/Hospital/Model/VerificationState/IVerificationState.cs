namespace Model
{
    public interface IVerificationState
    {
        void Verify(Medicine medicine);
        void Reject(Medicine medicine);
    }
}