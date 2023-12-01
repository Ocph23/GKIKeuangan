namespace MainApp.Models
{
    public class PeriodeKasModel:PeriodeKas
    {

        public PeriodeKasModel(PeriodeKas p, IEnumerable<Kas> _dataKas)
        {
            this.Id= p.Id; 
            this.Bulan = p.Bulan;
            this.Mulai= p.Mulai;
            this.Berakhir = p.Berakhir; 
            this.PeriodeId = p.PeriodeId;
            this.Periode = p.Periode;
            this.SaldoLalu = p.SaldoLalu;
            this.UtangLalu = p.UtangLalu;

            this.Penerimaan = _dataKas.Where(x => x.Akun.Tipe == AkunType.Penerimaan).Sum(x => x.Jumlah);
            this.Pengeluaran = _dataKas.Where(x => x.Akun.Tipe == AkunType.Pengeluaran).Sum(x => x.Jumlah);
            this.PembayaranUtang = _dataKas.Where(x => x.Akun.Tipe == AkunType.Pengeluaran && x.Akun.SetoranWajib).Sum(x => x.Jumlah);
            this.PemegangKas = p.PemegangKas;
           // this.TanggalPenutupan= p.TanggalPenutupan;
            
            this.Sinode = _dataKas.Where(x => x.Akun.Tipe == AkunType.Penerimaan && x.Akun.Sinode > 0).Sum(x => x.Jumlah * x.Akun.Sinode / 100);
            this.Klasis = _dataKas.Where(x => x.Akun.Tipe == AkunType.Penerimaan && x.Akun.Klasis > 0).Sum(x => x.Jumlah * x.Akun.Klasis / 100);
            this.YPK = _dataKas.Where(x => x.Akun.Tipe == AkunType.Penerimaan && x.Akun.YPK > 0).Sum(x => x.Jumlah * x.Akun.YPK / 100);
            this.Jemaat = _dataKas.Where(x => x.Akun.Tipe == AkunType.Penerimaan && x.Akun.Jemaat > 0).Sum(x => x.Jumlah * x.Akun.Jemaat / 100);
        }
    }
}
