namespace MainApp;

public class AnggaranBelanjaItem{
    public int Id { get; set; }
    public Akun? Akun { get; set; }
    public int Kegiatan { get; set; }
    public double Nilai { get; set; }
    public double Jumlah => Kegiatan * Nilai;
}
