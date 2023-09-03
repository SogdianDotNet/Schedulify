using System.Text;

namespace Schedulify.Application.Encoders;

public class Base64Encoder
{
    /// <summary>
    /// Encode the byte array to a base64 string
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static string Encode(byte[] input)
    {
        return Convert.ToBase64String(input);
    }

    /// <summary>
    /// Encode a string into a base64 string
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static string Encode(string input)
    {
        var bytes = Encoding.UTF8.GetBytes(input);
        return Encode(bytes);
    }

    /// <summary>
    /// Decode a base64 string back to a string
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static string Decode(string input)
    {
        var bytes = Convert.FromBase64String(input);
        return Encoding.UTF8.GetString(bytes);
    }
}