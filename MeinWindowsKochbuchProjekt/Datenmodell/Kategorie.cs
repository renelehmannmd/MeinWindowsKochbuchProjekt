using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeinWindowsKochbuchProjekt.Datenmodell
{
    [Table("tb_kategorie")]
    public class Kategorie
    {
        private int kategorieID;
        private string kategorieName;
        private string kategorieBeschreibung;

        [Key, Column("kat_id", Order = 1)]
        public int KategorieID { get => kategorieID; set => kategorieID = value; }

        [Column("kat_name", Order = 2), Required]
        public string KategorieName { get => kategorieName; set => kategorieName = value; }

        [Column("kat_beschreibung", Order = 3), Required]
        public string KategorieBeschreibung { get => kategorieBeschreibung; set => kategorieBeschreibung = value; }

        public List<RezeptKategorie> RezeptKategorien { get; set; }
    }
}
