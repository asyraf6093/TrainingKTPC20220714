using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingKTPC20220714.Models
{
    public class Bangunan
    {
        public Bangunan()
        {

        }

        public Bangunan(string Name,string Alamat,int BilTingkat)
        {
            this.Name = Name;
            this.Alamat = Alamat;
            this.BilTingkat = BilTingkat;

            if (BilTingkat > 20)
                this.Kategori = "Tinggi";
            else
                this.Kategori = "Rendah";
        }

        [Key]
        public int IdKey { get; set; }
        public string Name { get; set; }
        public string Alamat { get; set; }
        public int BilTingkat { get; set; }
        public string Kategori { get; set; }
        public int LokasiID { get; set; }

        [ForeignKey("LokasiID")] public Lokasi lokasi { get; set; }
    }
}
