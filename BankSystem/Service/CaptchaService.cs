using BankSystem.DTO;
using BankSystem.Service.IService;
using System.Text.Json;

namespace BankSystem.Service
{
    public class CaptchaService:ICaptchaService
    {
        private readonly HttpClient _httpClient;
        private readonly string _secretKey;

        public CaptchaService(IConfiguration config)
        {
            _httpClient = new HttpClient();
            _secretKey = config["GoogleReCaptcha:SecretKey"];
        }

        public async Task<bool> VerifyCaptchaAsync(string token)
        {
            var response = await _httpClient.GetAsync(
                $"https://www.google.com/recaptcha/api/siteverify?secret={_secretKey}&response={token}");

            if (!response.IsSuccessStatusCode)
                return false;

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var captchaResult = JsonSerializer.Deserialize<GoogleCaptchaResponse>(jsonResponse);

            return captchaResult?.Success ?? false;
        }
    }
}
