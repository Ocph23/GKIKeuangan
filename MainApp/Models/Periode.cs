using MainApp.Models;

namespace MainApp;

public class Periode
{
    public int Id { get; set; }
    public int Tahun { get; set; }
    public string? Catatan { get; set; }
    public double UtangAkhir { get; set; }
    public double SaldoAkhir { get; set; }
    public StatusKas Status { get; set; }
    public ICollection<AnggaranBelanjaItem> RencanaAnggaranBalanja { get; set; } = new List<AnggaranBelanjaItem>();
    public bool CanEdit => Status is StatusKas.Baru or StatusKas.Ditolak;

}
