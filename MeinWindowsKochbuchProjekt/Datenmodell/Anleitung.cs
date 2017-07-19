using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeinWindowsKochbuchProjekt.Datenmodell
{
    [Table("tb_anleitung")]
    class Anleitung
    {

        private int anleitungsId;
        private string anleitungsText;
        private int rezID;

        [Key, Column("al_id", Order = 1)]
        public int AnleitungsId { get => anleitungsId; set => anleitungsId = value; }

        [Column("al_name", Order = 2), Required]
        public string AnleitungsText { get => anleitungsText; set => anleitungsText = value; }

        [Column("al_zeit", Order = 3), Required]
        public string AnleitungsZeit { get => anleitungsText; set => anleitungsText = value; }



        [Column("fk_rez_id", Order = 3)]
        public int RezID { get => rezID; set => rezID = value; }

        [ForeignKey("RezID")]
        public Rezept Rezept { get; set; }
    }
}
