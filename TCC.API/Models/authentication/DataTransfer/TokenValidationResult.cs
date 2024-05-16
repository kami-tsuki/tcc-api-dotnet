using System.Text.Json.Serialization;

namespace TCC.API.models.authentication.DataTransfer;

public class TokenValidationResult
{
    public bool IsValid { get; set; }
    public string Reason { get; set; }
    [JsonIgnore]
    public Exception? Exception { get; set; }
    
    public string? ExceptionMessage => Exception?.Message;
    
    public string? ExceptionStackTrace => Exception?.StackTrace;
    
    public string? ExceptionType => Exception?.GetType().Name;
    
    public string? ExceptionSource => Exception?.Source;
    
    public string? ExceptionTargetSite => Exception?.TargetSite?.Name;
    
    public string? ExceptionHelpLink => Exception?.HelpLink;
}