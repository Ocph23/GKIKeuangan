namespace MainApp;

public class Periode
{
    public int Id { get; set; }

    public int Tahun { get; set; }
    public double Jemaat { get; set; }
    public double YPK { get; set; }
    public double Klasis { get; set; }
    public double Sinode { get; set; }

    public bool Aktif { get; set; }

    public string? Catatan { get; set; }

    public ICollection<AnggaranBelanjaItem> RencanaAnggaranBalanja { get; set; } = new List<AnggaranBelanjaItem>();
}
