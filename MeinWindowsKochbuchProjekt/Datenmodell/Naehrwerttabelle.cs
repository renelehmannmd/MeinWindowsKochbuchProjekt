using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeinWindowsKochbuchProjekt.Datenmodell
{
    [Table("tb_naehrwerttabelle")]
    public class Naehrwerttabelle
    {
        private int naehrwertId;
        private double naehrwertGrundmenge;
        private double naehwertEiweiss;
        private double naehrwertKohlenhydrate;
        private double naehrwertFett;
        private double naehrwertBrennwert;
        private double naehrwertZuckeranteil;
        private double naehrwertBallaststoffgeahalt;
        private double naehrwertAlkoholgehalt;

        [Key, Column("nwt_id", Order = 1)]
        public int NaehrwertId { get => naehrwertId; set => naehrwertId = value; }

        [Column("nwt_grundmenge", Order = 3), Required]
        public double NaehrwertGrundmenge { get => naehrwertGrundmenge; set => naehrwertGrundmenge = value; }

        [Column("nwt_eiweiss", Order = 4), Required]
        public double NaehwertEiweiss { get => naehwertEiweiss; set => naehwertEiweiss = value; }

        [Column("nwt_kohlenhydrate", Order = 5), Required]
        public double NaehrwertKohlenhydrate { get => naehrwertKohlenhydrate; set => naehrwertKohlenhydrate = value; }

        [Column("nwt_fett", Order = 6), Required]
        public double NaehrwertFett { get => naehrwertFett; set => naehrwertFett = value; }

        [Column("nwt_brennwert", Order = 7), Required]
        public double NaehrwertBrennwert { get => naehrwertBrennwert; set => naehrwertBrennwert = value; }

        [Column("nwt_zuckergehalt", Order = 8), Required]
        public double NaehrwertZuckeranteil { get => naehrwertZuckeranteil; set => naehrwertZuckeranteil = value; }

        [Column("nwt_balaststoffe", Order = 9), Required]
        public double NaehrwertBallaststoffgeahalt { get => naehrwertBallaststoffgeahalt; set => naehrwertBallaststoffgeahalt = value; }

        [Column("nwt_alkoholgehalt", Order = 10), Required]
        public double NaehrwertAlkoholgehalt { get => naehrwertAlkoholgehalt; set => naehrwertAlkoholgehalt = value; }

        [Column("fk_lm_id", Order = 2)]
        public int LebensmittelId { get; set; }

        [ForeignKey("LebensmittelId")]
        public Lebensmittel Lebensmittel { get; set; }
    }
}
