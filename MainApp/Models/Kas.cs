namespace MainApp;

public class Kas
{
    public int Id { get; set; }
    public DateTime? Tanggal { get; set; } = DateTime.Now;

    public Akun? Akun { get; set; }

    public double Jumlah { get; set; }

    public string? Catatan{get;set;}

    public double Utang => GetUtang();

    private double GetUtang()
    {
       if(Akun == null || Akun.Tipe== AkunType.Pengeluaran)
            return 0;

        return (Akun.YPK + Akun.Sinode + Akun.Klasis) / 100 * Jumlah;
    }
}
