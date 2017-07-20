using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using MeinWindowsKochbuchProjekt.Datenmodell;

using System.IO;
using System.Windows.Media.Imaging;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;

namespace MeinWindowsKochbuchProjekt.Extensions
{
    public static class ImportLebensmittel
    {
        public static void ImportiereLebensmittel()
        {
            RezeptDataContext rzp = new RezeptDataContext();
            string[] readLines = File.ReadAllLines("Ressourcen\\Lebensmitteltabelle.txt");
            foreach(string line in readLines)
            {
                string[] aufgesplitteZeile = line.Split(';');
                Lebensmittel lm = new Lebensmittel();
                Naehrwerttabelle nt = new Naehrwerttabelle();
                for (int i = 0; i < aufgesplitteZeile.Length; i++)
                {
                    switch (i)
                    {
                        case 0:
                            lm.LebensmittelName = aufgesplitteZeile[i];
                            break;

                        case 1:
                            nt.NaehrwertGrundmenge = TabelleneintragZuDouble(aufgesplitteZeile[i]);
                            break;
                        case 2:
                            nt.NaehwertEiweiss = TabelleneintragZuDouble(aufgesplitteZeile[i]);
                            break;
                        case 3:
                            nt.NaehrwertFett = TabelleneintragZuDouble(aufgesplitteZeile[i]);
                            break;
                        case 4:
                            nt.NaehrwertKohlenhydrate = TabelleneintragZuDouble(aufgesplitteZeile[i]);
                            break;
                        case 5:
                            nt.NaehrwertZuckeranteil = TabelleneintragZuDouble(aufgesplitteZeile[i]);
                            break;
                        case 6:
                            nt.NaehrwertBallaststoffgeahalt = TabelleneintragZuDouble(aufgesplitteZeile[i]);
                            break;
                        case 7:
                            nt.NaehrwertAlkoholgehalt = TabelleneintragZuDouble(aufgesplitteZeile[i]);
                            break;
                        case 8:
                            nt.NaehrwertBrennwert = Convert.ToDouble(aufgesplitteZeile[i]);
                            break;
                    default:
                    break;
                    }
                    lm.Naehrwerttabelle = nt;
                    lm.LebensmittelKatId = 1;
                    lm.BildId = 1;
                    rzp.Add<Lebensmittel>(lm);
                }

            }
            rzp.SaveChanges();

            

        }

        private static double TabelleneintragZuDouble(string str)
        {
            char[] carr = str.ToCharArray();
            int endPosition = 0;
            for (int i = 0; i < carr.Length; i++)
            {
                if(!(carr[i] >= 48 && carr[i] <= 57) && carr[i] != 46)
                {
                     endPosition = i;
                    break;
                }
            }
            return Convert.ToDouble(str.Substring(0, endPosition)) ;
        }

        public static void LegeRezeptKategorienAn()
        {
            using (var db = new RezeptDataContext())
            {
                db.Kategorien.Add(new Kategorie() { KategorieName = "Frühstück", KategorieBeschreibung = "Die wichtigste Malzeit des Tages" });
                db.Kategorien.Add(new Kategorie() { KategorieName = "Mittag", KategorieBeschreibung = "Die wichtigste Malzeit des Tages" });
                db.Kategorien.Add(new Kategorie() { KategorieName = "Vesper", KategorieBeschreibung = "Die wichtigste Malzeit des Tages" });
                db.Kategorien.Add(new Kategorie() { KategorieName = "Abendbrot", KategorieBeschreibung = "Die wichtigste Malzeit des Tages" });
                db.Kategorien.Add(new Kategorie() { KategorieName = "Salate", KategorieBeschreibung = "Die wichtigste Malzeit des Tages" });
                db.Kategorien.Add(new Kategorie() { KategorieName = "Süßspeisen", KategorieBeschreibung = "Die wichtigste Malzeit des Tages" });
                db.Kategorien.Add(new Kategorie() { KategorieName = "Suppen", KategorieBeschreibung = "Die wichtigste Malzeit des Tages" });
                db.Kategorien.Add(new Kategorie() { KategorieName = "Fleisch", KategorieBeschreibung = "Die wichtigste Malzeit des Tages" });
                db.Kategorien.Add(new Kategorie() { KategorieName = "Vegetarisches", KategorieBeschreibung = "Die wichtigste Malzeit des Tages" });
                db.Kategorien.Add(new Kategorie() { KategorieName = "Smoothies", KategorieBeschreibung = "Die wichtigste Malzeit des Tages" });
                db.SaveChanges();
            }
        }

        public static void LegeLebensmittelKategorienAn()
        {
            using (var db = new RezeptDataContext())
            {
                db.LebensmittelKategorien.Add(new LebensmittelKategorie() { LeKaName = "%" });
                db.LebensmittelKategorien.Add(new LebensmittelKategorie() { LeKaName = "Obst" });
                db.LebensmittelKategorien.Add(new LebensmittelKategorie() { LeKaName = "Gemüse" });
                db.LebensmittelKategorien.Add(new LebensmittelKategorie() { LeKaName = "Fleisch" });
                db.LebensmittelKategorien.Add(new LebensmittelKategorie() { LeKaName = "Gewürze" });
                db.LebensmittelKategorien.Add(new LebensmittelKategorie() { LeKaName = "Kräuter" });
                db.LebensmittelKategorien.Add(new LebensmittelKategorie() { LeKaName = "Getränke" });
                db.LebensmittelKategorien.Add(new LebensmittelKategorie() { LeKaName = "Fertiggerichte" });
                db.LebensmittelKategorien.Add(new LebensmittelKategorie() { LeKaName = "Öle & Fette" });
                db.LebensmittelKategorien.Add(new LebensmittelKategorie() { LeKaName = "Fisch" });
                db.LebensmittelKategorien.Add(new LebensmittelKategorie() { LeKaName = "Backwaren" });

                db.SaveChanges();
            }
        }

        public static void LegeStandardLebensmittelBildFest()
        {
            using (var db = new RezeptDataContext())
            {
                string path = "Ressourcen\\fruit-1181730_1280.jpg";
                FileInfo fi = new FileInfo(path);
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                Bild bi = new Bild();
                bi.Bildchen = br.ReadBytes((int) fi.Length);
                db.Bilder.Add(bi);
                db.SaveChanges();
            }
        }
    }

}
