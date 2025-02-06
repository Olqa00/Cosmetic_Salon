namespace CosmeticSalon.Domain.ValueObjects;

using CosmeticSalon.Domain.Exceptions;

public sealed record Email
{
    private static readonly TimeSpan MATCH_TIMEOUT = TimeSpan.FromMilliseconds(100);

    private static readonly Regex REGEX = new(
        @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
        RegexOptions.Compiled,
        MATCH_TIMEOUT);

    public string Value { get; }

    public Email(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidEmailException(value);
        }

        if (value.Length > 100)
        {
            throw new InvalidEmailException(value);
        }

        value = value.ToLowerInvariant();

        try
        {
            if (REGEX.IsMatch(value) is false)
            {
                throw new InvalidEmailException(value);
            }
        }
        catch (RegexMatchTimeoutException)
        {
            throw new EmailVerificationTimeoutException(value);
        }

        this.Value = value;
    }

    public override string ToString() => this.Value;
}
