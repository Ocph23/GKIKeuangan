namespace MainApp;

public class Akun
{
    public int Id { get; set; }
    public Kategori Kategori { get; set; }
    public string? Kode { get; set; }
    public string? Uraian { get; set; }
    public AkunType Tipe { get; set; }

    public bool Jemaat { get; set; }
    public bool YPK { get; set; }
    public bool Klasis { get; set; }
    public bool Sinode { get; set; }

    public string? Keterangan { get; set; }
}
