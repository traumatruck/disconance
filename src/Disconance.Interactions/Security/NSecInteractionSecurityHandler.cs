using System.Text;
using NSec.Cryptography;

namespace Disconance.Interactions.Security;

/// <summary>
///     Represents a security handler for interaction validations, specifically using NSec for scenarios requiring
///     signature-based verification using the Ed25519 algorithm.
/// </summary>
public class NSecInteractionSecurityHandler : IInteractionSecurityHandler
{
    /// <inheritdoc />
    public bool ValidateInteractionSignature(string body, string signature, string timestamp, string publicKey)
    {
        // Convert hex strings to byte arrays
        var signatureBytes = Convert.FromHexString(signature);
        var publicKeyBytes = Convert.FromHexString(publicKey);

        // Create the message to verify (timestamp + body)
        var messageToSign = timestamp + body;
        var message = Encoding.UTF8.GetBytes(messageToSign);

        // Import the public key and verify the signature
        var algorithm = SignatureAlgorithm.Ed25519;
        var key = PublicKey.Import(algorithm, publicKeyBytes, KeyBlobFormat.RawPublicKey);

        // Perform the signature verification
        var result = algorithm.Verify(key, message, signatureBytes);

        // Return the result
        return result;
    }
}