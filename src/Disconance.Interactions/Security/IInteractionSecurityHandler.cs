namespace Disconance.Interactions.Security;

/// <summary>
///     Provides the definition for handling security aspects of interactions, including validating interaction signatures
///     to ensure authenticity and integrity.
/// </summary>
public interface IInteractionSecurityHandler
{
    /// <summary>
    ///     Validates the signature of an interaction to ensure its authenticity and integrity. The validation involves
    ///     checking the signature against the provided body, timestamp, and public key.
    /// </summary>
    /// <param name="body">The body of the interaction message that was signed.</param>
    /// <param name="signature">The hexadecimal string representing the digital signature to be validated.</param>
    /// <param name="timestamp">The timestamp associated with the interaction message, included in the message signature.</param>
    /// <param name="publicKey">The hexadecimal string representing the public key used to verify the signature.</param>
    /// <returns>True if the signature is valid; otherwise, false.</returns>
    bool ValidateInteractionSignature(string body, string signature, string timestamp, string publicKey);
}