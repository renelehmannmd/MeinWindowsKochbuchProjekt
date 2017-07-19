using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeinWindowsKochbuchProjekt.Datenmodell
{
    [Table("tb_lebensmittel")]
    public class Lebensmittel
    {
        private int lebensmittelId;
        private string lebensmittelName;
        private string lebensmittelBeschreibung;
        private string lebensmittelInformationen;


        [Key, Column("lm_id", Order = 1)]
        public int LebensmittelId { get => lebensmittelId; set => lebensmittelId = value; }

        [Column("lm_name", Order = 3), Required]
        public string LebensmittelName { get => lebensmittelName; set => lebensmittelName = value; }

        [Column("lm_beschreibung", Order = 4)]
        public string LebensmittelBeschreibung { get => lebensmittelBeschreibung; set => lebensmittelBeschreibung = value; }

        [Column("lm_informationen", Order = 5)]
        public string LebensmittelInformationen { get => lebensmittelInformationen; set => lebensmittelInformationen = value; }

        [Column("leka_id"), ForeignKey("LebensmittelKategorie")]
        public int LebensmittelKatId { get; set; }

        public Naehrwerttabelle Naehrwerttabelle { get; set; }
        public LebensmittelKategorie LebensmittelKategorie { get; set; }

    }
}
