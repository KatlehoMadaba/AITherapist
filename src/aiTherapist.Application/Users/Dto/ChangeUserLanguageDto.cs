using System.ComponentModel.DataAnnotations;

namespace aiTherapist.Users.Dto;

public class ChangeUserLanguageDto
{
    [Required]
    public string LanguageName { get; set; }
}