namespace TCC.API.Models.data.dto;

public class SettingsDto
{
    public static implicit operator SettingsDto(Settings settings) => 
        new SettingsDto();
    
    public static implicit operator Settings(SettingsDto settings) =>
        new Settings();
}