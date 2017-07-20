using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MeinWindowsKochbuchProjekt.Datenmodell;

namespace MeinWindowsKochbuchProjekt.Migrations
{
    [DbContext(typeof(RezeptDataContext))]
    [Migration("20170720084853_M0")]
    partial class M0
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("MeinWindowsKochbuchProjekt.Datenmodell.Anleitung", b =>
                {
                    b.Property<int>("AnleitungsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("al_id");

                    b.Property<string>("AnleitungsText")
                        .IsRequired()
                        .HasColumnName("al_name");

                    b.Property<string>("AnleitungsZeit")
                        .IsRequired()
                        .HasColumnName("al_zeit");

                    b.Property<int>("RezID")
                        .HasColumnName("fk_rez_id");

                    b.HasKey("AnleitungsId");

                    b.HasIndex("RezID");

                    b.ToTable("tb_anleitung");
                });

            modelBuilder.Entity("MeinWindowsKochbuchProjekt.Datenmodell.Bild", b =>
                {
                    b.Property<int>("BildID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("bild_id");

                    b.Property<byte[]>("Bildchen")
                        .HasColumnName("bild_blob");

                    b.HasKey("BildID");

                    b.ToTable("tb_bilder");
                });

            modelBuilder.Entity("MeinWindowsKochbuchProjekt.Datenmodell.Kategorie", b =>
                {
                    b.Property<int>("KategorieID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("kat_id");

                    b.Property<string>("KategorieBeschreibung")
                        .IsRequired()
                        .HasColumnName("kat_beschreibung");

                    b.Property<string>("KategorieName")
                        .IsRequired()
                        .HasColumnName("kat_name");

                    b.HasKey("KategorieID");

                    b.ToTable("tb_kategorie");
                });

            modelBuilder.Entity("MeinWindowsKochbuchProjekt.Datenmodell.Lebensmittel", b =>
                {
                    b.Property<int>("LebensmittelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("lm_id");

                    b.Property<int>("BildId")
                        .HasColumnName("bild_id");

                    b.Property<string>("LebensmittelBeschreibung")
                        .HasColumnName("lm_beschreibung");

                    b.Property<string>("LebensmittelInformationen")
                        .HasColumnName("lm_informationen");

                    b.Property<int>("LebensmittelKatId")
                        .HasColumnName("leka_id");

                    b.Property<string>("LebensmittelName")
                        .IsRequired()
                        .HasColumnName("lm_name");

                    b.HasKey("LebensmittelId");

                    b.HasIndex("BildId");

                    b.HasIndex("LebensmittelKatId");

                    b.ToTable("tb_lebensmittel");
                });

            modelBuilder.Entity("MeinWindowsKochbuchProjekt.Datenmodell.LebensmittelKategorie", b =>
                {
                    b.Property<int>("LeKaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("lk_id");

                    b.Property<string>("LeKaBeschreibung")
                        .HasColumnName("lk_beschreibung");

                    b.Property<string>("LeKaName")
                        .HasColumnName("lk_name");

                    b.HasKey("LeKaId");

                    b.ToTable("tb_lebensmittel_kats");
                });

            modelBuilder.Entity("MeinWindowsKochbuchProjekt.Datenmodell.Naehrwerttabelle", b =>
                {
                    b.Property<int>("NaehrwertId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("nwt_id");

                    b.Property<int>("LebensmittelId")
                        .HasColumnName("fk_lm_id");

                    b.Property<double>("NaehrwertAlkoholgehalt")
                        .HasColumnName("nwt_alkoholgehalt");

                    b.Property<double>("NaehrwertBallaststoffgeahalt")
                        .HasColumnName("nwt_balaststoffe");

                    b.Property<double>("NaehrwertBrennwert")
                        .HasColumnName("nwt_brennwert");

                    b.Property<double>("NaehrwertFett")
                        .HasColumnName("nwt_fett");

                    b.Property<double>("NaehrwertGrundmenge")
                        .HasColumnName("nwt_grundmenge");

                    b.Property<double>("NaehrwertKohlenhydrate")
                        .HasColumnName("nwt_kohlenhydrate");

                    b.Property<double>("NaehrwertZuckeranteil")
                        .HasColumnName("nwt_zuckergehalt");

                    b.Property<double>("NaehwertEiweiss")
                        .HasColumnName("nwt_eiweiss");

                    b.HasKey("NaehrwertId");

                    b.HasIndex("LebensmittelId")
                        .IsUnique();

                    b.ToTable("tb_naehrwerttabelle");
                });

            modelBuilder.Entity("MeinWindowsKochbuchProjekt.Datenmodell.Rezept", b =>
                {
                    b.Property<int>("RezId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("rez_id");

                    b.Property<string>("RezBeschreibung")
                        .IsRequired()
                        .HasColumnName("rez_beschreibung");

                    b.Property<string>("RezName")
                        .IsRequired()
                        .HasColumnName("rez_name");

                    b.HasKey("RezId");

                    b.ToTable("tb_rezept");
                });

            modelBuilder.Entity("MeinWindowsKochbuchProjekt.Datenmodell.RezeptKategorie", b =>
                {
                    b.Property<int>("RezeptID")
                        .HasColumnName("fk_rez_id");

                    b.Property<int>("KategorieID")
                        .HasColumnName("fk_kat_id");

                    b.HasKey("RezeptID", "KategorieID");

                    b.HasIndex("KategorieID");

                    b.ToTable("tb_rez_kat");
                });

            modelBuilder.Entity("MeinWindowsKochbuchProjekt.Datenmodell.Anleitung", b =>
                {
                    b.HasOne("MeinWindowsKochbuchProjekt.Datenmodell.Rezept", "Rezept")
                        .WithMany()
                        .HasForeignKey("RezID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MeinWindowsKochbuchProjekt.Datenmodell.Lebensmittel", b =>
                {
                    b.HasOne("MeinWindowsKochbuchProjekt.Datenmodell.Bild", "Bild")
                        .WithMany()
                        .HasForeignKey("BildId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MeinWindowsKochbuchProjekt.Datenmodell.LebensmittelKategorie", "LebensmittelKategorie")
                        .WithMany()
                        .HasForeignKey("LebensmittelKatId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MeinWindowsKochbuchProjekt.Datenmodell.Naehrwerttabelle", b =>
                {
                    b.HasOne("MeinWindowsKochbuchProjekt.Datenmodell.Lebensmittel", "Lebensmittel")
                        .WithOne("Naehrwerttabelle")
                        .HasForeignKey("MeinWindowsKochbuchProjekt.Datenmodell.Naehrwerttabelle", "LebensmittelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MeinWindowsKochbuchProjekt.Datenmodell.RezeptKategorie", b =>
                {
                    b.HasOne("MeinWindowsKochbuchProjekt.Datenmodell.Kategorie", "Kategorie")
                        .WithMany("RezeptKategorien")
                        .HasForeignKey("KategorieID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MeinWindowsKochbuchProjekt.Datenmodell.Rezept", "Rezept")
                        .WithMany("RezeptKategorien")
                        .HasForeignKey("RezeptID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
