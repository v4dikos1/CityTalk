using Application.Abstractions;
using System.Security.Cryptography;

namespace Infrastructure.Services;

internal class VerificationService : IVerificationService
{
    /// <summary>
    /// Confirmation code generation
    /// </summary>
    /// <returns></returns>
    public string CreateVerificationToken()
    {
        return Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
    }
}