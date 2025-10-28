namespace BankSystem.Enum
{
    public enum DocumentVerifiedStatus
    {
        Pending,    // Uploaded but not yet verified
        Approved,   // Verified and approved by BankUser
        Rejected    // Rejected by BankUser
    }
}
