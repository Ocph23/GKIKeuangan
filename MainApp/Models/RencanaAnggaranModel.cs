
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

        public bool AlokasiPresentase { get; set; }

        public double ProsentaseJemaat { get; set; }
        public double ProsentaseYPK { get; set; }
        public double ProsentaseKlasis { get; set; }
        public double ProsentaseSinode { get; set; }


        public double Jemaat => GetAlokasi(Alokasi.Jemaat);
        public double Klasis => GetAlokasi(Alokasi.Klasis);
        public double YPK => GetAlokasi(Alokasi.YPK);
        public double Sinode => GetAlokasi(Alokasi.Sinode);

        private double GetAlokasi(Alokasi alokasi)
        {
            if (Periode == null || !AlokasiPresentase)
                return 0;

            double al = alokasi switch
            {
                Alokasi.Jemaat => ProsentaseJemaat,
                Alokasi.YPK => ProsentaseYPK,
                Alokasi.Klasis => ProsentaseKlasis,
                Alokasi.Sinode => ProsentaseSinode,
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
