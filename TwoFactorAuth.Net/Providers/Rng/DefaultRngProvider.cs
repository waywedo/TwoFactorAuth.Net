﻿using System.Security.Cryptography;

namespace TwoFactorAuthNet.Providers.Rng;

/// <summary>
/// Provides a cryptographically secure RNG provider.
/// </summary>
/// <remarks>
/// The <see cref="DefaultRngProvider"/> is based on a <see cref="RNGCryptoServiceProvider"/>.
/// </remarks>
/// <seealso cref="IRngProvider"/>
public class DefaultRngProvider : IRngProvider
{
    private static readonly RandomNumberGenerator _rngcryptoserviceprovider = RandomNumberGenerator.Create();

    /// <summary>
    /// Gets whether the provider is cryptographically secure.
    /// </summary>
    /// <remarks>
    /// The <see cref="DefaultRngProvider"/> is cryptographically secure.
    /// </remarks>
    /// <seealso cref="CryptoSecureRequirement"/>
    public bool IsCryptographicallySecure { get { return true; } }

    /// <summary>
    /// Fills an array of bytes with a cryptographically secure sequence of random values.
    /// </summary>
    /// <param name="bytes">The desired number of bytes to return.</param>
    /// <returns>An array with a cryptographically secure sequence of random values.</returns>
    public byte[] GetRandomBytes(int bytes)
    {
        var buff = new byte[bytes];
        _rngcryptoserviceprovider.GetBytes(buff);
        return buff;
    }
}
