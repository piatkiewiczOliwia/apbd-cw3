namespace app_cw3.Exceptions;

public class TooLowTemperatureException : Exception
{
    public TooLowTemperatureException()
    { }

    public TooLowTemperatureException(string? message) : base(message)
    {
    }
}