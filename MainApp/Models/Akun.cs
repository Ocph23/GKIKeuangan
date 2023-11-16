namespace MainApp;

public class Akun
{
    public int Id { get; set; }
    public required Kategori Kategori { get; set; }
    public string? Kode { get; set; }
    public string? Uraian { get; set; }
    public AkunType Tipe { get; set; }
    public string? Keterangan { get; set; }
}
