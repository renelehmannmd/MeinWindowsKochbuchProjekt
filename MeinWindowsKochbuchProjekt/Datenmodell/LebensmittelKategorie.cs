using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeinWindowsKochbuchProjekt.Datenmodell
{
    [Table("tb_lebensmittel_kats")]
    public class LebensmittelKategorie
    {
        
        private int _leKaId;
        private string _leKaName;
        private string _leKaBeschreibung;

        [Key, Column("lk_id", Order = 1)]
        public int LeKaId { get => _leKaId; set => _leKaId = value; }

        [Column("lk_name", Order = 2)]
        public string LeKaName { get => _leKaName; set => _leKaName = value; }

        [Column("lk_beschreibung", Order = 3)]
        public string LeKaBeschreibung { get => _leKaBeschreibung; set => _leKaBeschreibung = value; }
    }
}

