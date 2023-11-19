    namespace MainApp.Models
{
    public class RealisasiModel
    {
        public string AyatPenerimaan { get; set; }
        public double Rencana { get; set; }
        public ICollection<double> Bulan { get; set; } = new List<double>();
        public double Jumlah { get; set; }
        public double Lebih => Jumlah > Rencana ? Jumlah-Rencana:0;
        public double Kurang => Jumlah < Rencana ? Rencana-Jumlah:0;

    }
}
