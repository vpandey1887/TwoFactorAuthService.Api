using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoFactorAuthService
{
    public interface ITwoFactorService
    {
        bool SendCode(string phone);
        bool VerifyCode(string phone, string code);
    }
}
