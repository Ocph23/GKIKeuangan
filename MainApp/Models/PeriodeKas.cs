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
        public double SaldoLalu { get; set;}
        public double Penerimaan { get; set; }
        public double Pengeluaran { get; set; }
        public double Saldo => SaldoLalu+Penerimaan-Pengeluaran;
        public string PemegangKas { get; set; }
        public DateOnly? TanggalPenutupan { get; set; } 
    }
}
