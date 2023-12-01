namespace MainApp.Models
{
    public class PeriodeKas
    {
        public int Id { get; set; }
        public int Bulan { get; set; }
        public DateOnly Mulai { get; set; }
        public DateOnly Berakhir { get; set; }
        public int PeriodeId { get; set; }
        public Periode Periode { get; set; }
        public double SaldoLalu { get; set; }
        public double UtangLalu { get; set; }
        public double Penerimaan { get; set; }
        public double Pengeluaran { get; set; }
        public double PembayaranUtang { get; set; }
        public string PemegangKas { get; set; }
        public DateOnly? TanggalPenutupan { get; set; }
        public double Sinode { get; set; }
        public double YPK { get; set; }
        public double Klasis { get; set; }
        public double Jemaat { get; set; }
        public double Saldo => SaldoLalu + Penerimaan - Pengeluaran;
        public double Utang => UtangLalu + Sinode + Klasis + YPK - PembayaranUtang;
        public StatusKas Status { get; set; }
    }
}
