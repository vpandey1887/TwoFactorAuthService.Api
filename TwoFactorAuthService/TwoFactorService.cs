using System.Collections.Concurrent;

namespace TwoFactorAuthService
{
    public class TwoFactorService : ITwoFactorService
    {
        private readonly IDictionary<string, List<DateTime>> activeCodes;
        private readonly TimeSpan codeLifetime;

        public TwoFactorService(TimeSpan codeLifetime)
        {
            this.activeCodes = new ConcurrentDictionary<string, List<DateTime>>();
            this.codeLifetime = codeLifetime;
        }

        public bool SendCode(string phone)
        {
            if (!activeCodes.ContainsKey(phone))
            {
                activeCodes[phone] = new List<DateTime>();
            }

            if (activeCodes[phone].Count >= 5) // Adjust the limit as needed
            {
                return false; // Too many active codes for the phone
            }

            var code = GenerateCode();
            activeCodes[phone].Add(DateTime.UtcNow);

            // Log the code for debugging purposes
            Console.WriteLine($"Code sent to {phone}: {code}");

            return true;
        }

        public bool VerifyCode(string phone, string code)
        {
            if (activeCodes.TryGetValue(phone, out var codes))
            {
                var now = DateTime.UtcNow;
                foreach (var sentTime in codes)
                {
                    if (now - sentTime <= codeLifetime)
                    {
                        // Log the verification attempt for debugging purposes
                        Console.WriteLine($"Code verification for {phone}: {code} is successful.");
                        return true;
                    }
                }
            }

            // Log the verification attempt for debugging purposes
            Console.WriteLine($"Code verification for {phone}: {code} failed.");

            return false;
        }

        private string GenerateCode()
        {
            // Generate a simple 6-digit code for demonstration purposes
            return new Random().Next(100000, 999999).ToString();
        }
    }
}
