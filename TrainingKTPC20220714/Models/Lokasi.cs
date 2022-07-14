using System.ComponentModel.DataAnnotations;

namespace TrainingKTPC20220714.Models
{
    public class Lokasi
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Bangunan> bangunanList { get; set; }
    }
}
