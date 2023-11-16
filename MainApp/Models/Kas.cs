namespace MainApp;

public class Kas
{
    public int Id { get; set; }
    public DateTime? Tanggal { get; set; } = DateTime.Now;

    public Akun? Akun { get; set; }

    public double Jumlah { get; set; }

    public string? Catatan{get;set;}

}
