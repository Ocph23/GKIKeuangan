namespace MainApp;

public class Kas
{
    public int Id { get; set; }

    public required Akun Akun { get; set; }

    public double Jumlah { get; set; }

    public string? Catatan{get;set;}

}
