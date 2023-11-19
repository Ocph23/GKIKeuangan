namespace MainApp;

public class Akun
{
    public int Id { get; set; }
    public Kategori Kategori { get; set; }
    public string? Kode { get; set; }
    public string? Uraian { get; set; }
    public AkunType Tipe { get; set; }
    public bool AlokasiProsentese { get; set; }
    public bool SetoranWajib { get; set; }
    public double Jemaat { get; set; }
    public double YPK { get; set; }
    public double Klasis { get; set; }
    public double Sinode { get; set; }
    public string? Keterangan { get; set; }
}
