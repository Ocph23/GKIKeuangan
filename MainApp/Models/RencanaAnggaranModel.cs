
namespace MainApp.Models
{
    public class RencanaAnggaranModel
    {
        public RencanaAnggaranModel(Periode periode)
        {
            Periode = periode;
        }
        public int Nomor { get; set; }

        public string KodeKategori { get; set; }
        public string Kategori { get; set; }
        public string Kode { get; set; }

        public string Uraian { get; set; }

        public int Kegiatan { get; set; }

        public double Nilai { get; set; }

        public double Jumlah => Kegiatan * Nilai;
        public Periode Periode { get; set; }

        public bool IsJemaat { get; set; }
        public bool IsYPK { get; set; }
        public bool IsKlasis { get; set; }
        public bool IsSinode { get; set; }


        public double Jemaat => !IsJemaat?0:GetAlokasi(Alokasi.Jemaat);
        public double Klasis => !IsKlasis ? 0 : GetAlokasi(Alokasi.Klasis);
        public double YPK => !IsYPK ? 0 : GetAlokasi(Alokasi.YPK);
        public double Sinode => !IsSinode ? 0 : GetAlokasi(Alokasi.Sinode);

        private double GetAlokasi(Alokasi alokasi)
        {
            if (Periode == null)
                return 0;

            double al = alokasi switch
            {
                Alokasi.Jemaat => Periode.Jemaat,
                Alokasi.YPK => Periode.YPK,
                Alokasi.Klasis => Periode.Klasis,
                Alokasi.Sinode => Periode.Sinode,
                _ => 0
            };
            return Jumlah * al / 100;
        }



    }


    public enum Alokasi
    {
        Jemaat, YPK, Klasis, Sinode
    }
}
