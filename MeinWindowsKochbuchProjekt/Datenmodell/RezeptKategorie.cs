using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeinWindowsKochbuchProjekt.Datenmodell
{
    [Table("tb_rez_kat")]
    class RezeptKategorie
    {
        [Column("fk_rez_id", Order = 1)]
        public int RezeptID { get; set; }

        [ForeignKey("RezeptID")]
        public Rezept Rezept { get; set; }

        [Column("fk_kat_id")]
        public int KategorieID { get; set; }

        [ForeignKey("KategorieID")]
        public Kategorie Kategorie { get; set; }

    }
}
