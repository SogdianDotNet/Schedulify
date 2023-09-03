namespace Schedulify.Domain.Commands;

public class SendEmailCommand
{
    /// <summary>
    /// Unique Correlation ID.
    /// </summary>
    public Guid CorrelationId { get; } = Guid.NewGuid();

    /// <summary>
    /// A list of emails. 
    /// </summary>
    public string[] To { get; set; } = Array.Empty<string>();

    /// <summary>
    /// The subject of the email to be.
    /// </summary>
    public string Subject { get; set; } = string.Empty;

    /// <summary>
    /// The body of the email.
    /// </summary>
    public string Body { get; set; } = string.Empty;

    /// <summary>
    /// Extra data to be sent.
    /// </summary>

    public Dictionary<string, object> Data { get; set; } = new();
}