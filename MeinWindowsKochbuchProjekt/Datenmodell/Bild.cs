using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeinWindowsKochbuchProjekt.Datenmodell
{
    [Table("tb_bilder")]
    public class Bild
    {
        [Key, Column("bild_id", Order = 1)]
        public int BildID { get; set; }

        [Column("bild_blob", Order = 3)]
        public byte[] Bildchen { get; set; }


    }
}
