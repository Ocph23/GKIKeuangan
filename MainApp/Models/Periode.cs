namespace MainApp;

public class Periode{
    public int Id { get; set; }

    public int Tahun { get; set; }

    public bool Aktif { get; set; }

    public int Catatan { get; set; }

    public ICollection<AnggaranBelanjaItem> RencanaAnggaranBalanja { get; set; } = new List<AnggaranBelanjaItem>();
}
