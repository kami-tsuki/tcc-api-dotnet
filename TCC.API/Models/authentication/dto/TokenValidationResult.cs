namespace TCC.API.Models.authentication.dto;

public class TokenValidationResult
{
    public bool IsValid { get; set; }
    public string Reason { get; set; } = string.Empty;
    [JsonIgnore, NotMapped]
    public Exception? Exception { get; set; }
    
    public string? ExceptionMessage => Exception?.Message;
    
    public string? ExceptionStackTrace => Exception?.StackTrace;
    
    public string? ExceptionType => Exception?.GetType().Name;
    
    public string? ExceptionSource => Exception?.Source;
    
    public string? ExceptionTargetSite => Exception?.TargetSite?.Name;
    
    public string? ExceptionHelpLink => Exception?.HelpLink;
}