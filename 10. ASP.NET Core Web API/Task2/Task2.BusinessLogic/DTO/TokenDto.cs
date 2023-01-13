namespace Task2.BusinessLogic.DTO;

public class TokenDto
{
    public string JwtToken { get; set; }

    public DateTime ValidTo { get; set; }
}