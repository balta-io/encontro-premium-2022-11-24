namespace UtmBuilder.Exceptions;

public class InvalidUtmException : Exception
{
    public InvalidUtmException(string message = "Invalid UTM parameters") : base(message)
    {
    }

    public static void ThrowIfNull(string? item, string message = "Invalid UTM parameter")
    {
        if (string.IsNullOrEmpty(item))
            throw new InvalidUtmException(message);
    }
}