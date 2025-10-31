namespace BankSystem.Service.IService
{
    public interface ICaptchaService
    {
        Task<bool> VerifyCaptchaAsync(string token);
    }
}
