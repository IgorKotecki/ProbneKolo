namespace PróbneKol2.DTO_s;

public class ClientDTO
{
    public int IdClient { get; set; }
    public string Name { get; set; }
    public string Lastname { get; set; }
    public DateTime Birthday { get; set; }
    public string Pesel { get; set; }
    public string Email { get; set; }
    public int IdClientCategory { get; set; }
}