namespace BankSystem.Enum
{
    public enum DocumentType
    {
        IDProof,        // Passport, Aadhaar, Driving License
        AddressProof,   // Utility Bill, Rent Agreement, Bank Statement
        CompanyRegistration, // For corporate clients
        PANCard,        // Tax identification
        GSTCertificate, // For business verification
        Other           // Any other document
    }
}
