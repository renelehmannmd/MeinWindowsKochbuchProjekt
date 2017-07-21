using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeinWindowsKochbuchProjekt.Datenmodell
{
    [Table("tb_rezept")]
    public class Rezept
    {
        private int rezId;
        private string rezName;
        private string rezBeschreibung;

        [Key, Column("rez_id", Order = 1)]
        public int RezId { get => rezId; set => rezId = value; }

        [Column("rez_name", Order = 2), Required]
        public string RezName { get => rezName; set => rezName = value; }

        [Column("rez_beschreibung", Order = 3), Required]
        public string RezBeschreibung { get => rezBeschreibung; set => rezBeschreibung = value; }

        public List<RezeptKategorie> RezeptKategorien { get; set; }
    }
}
