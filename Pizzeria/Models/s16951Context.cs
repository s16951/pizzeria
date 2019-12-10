using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Pizzeria.Models
{
    public partial class s16951Context : DbContext
    {
        public s16951Context()
        {
        }

        public s16951Context(DbContextOptions<s16951Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrator> Administrator { get; set; }
        public virtual DbSet<Ciasto> Ciasto { get; set; }
        public virtual DbSet<DaneWysylki> DaneWysylki { get; set; }
        public virtual DbSet<Napoj> Napoj { get; set; }
        public virtual DbSet<NapojZamowienie> NapojZamowienie { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<PizzaCiasto> PizzaCiasto { get; set; }
        public virtual DbSet<PizzaSkladnik> PizzaSkladnik { get; set; }
        public virtual DbSet<Pracownik> Pracownik { get; set; }
        public virtual DbSet<PracownikZamowienie> PracownikZamowienie { get; set; }
        public virtual DbSet<Promocja> Promocja { get; set; }
        public virtual DbSet<RodzajPlatnosci> RodzajPlatnosci { get; set; }
        public virtual DbSet<Skladnik> Skladnik { get; set; }
        public virtual DbSet<Sos> Sos { get; set; }
        public virtual DbSet<SosZamowienie> SosZamowienie { get; set; }
        public virtual DbSet<Stanowisko> Stanowisko { get; set; }
        public virtual DbSet<Uzytkownik> Uzytkownik { get; set; }
        public virtual DbSet<Zamowienie> Zamowienie { get; set; }
        public virtual DbSet<ZamowieniePizza> ZamowieniePizza { get; set; }

       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s16951;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrator>(entity =>
            {
                entity.HasKey(e => e.IdAdmin);

                entity.Property(e => e.IdAdmin)
                    .HasColumnName("idAdmin")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Haslo)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ciasto>(entity =>
            {
                entity.HasKey(e => e.IdCiasto);

                entity.Property(e => e.IdCiasto).ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DaneWysylki>(entity =>
            {
                entity.HasKey(e => e.IdDane);

                entity.Property(e => e.IdDane)
                    .HasColumnName("idDane")
                    .ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Firma)
                    .HasColumnName("firma")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdUzytkownik)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Miasto)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NrTelefonu).HasColumnName("nr_telefonu");

                entity.Property(e => e.Ulica)
                    .IsRequired()
                    .HasColumnName("ulica")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUzytkownikNavigation)
                    .WithMany(p => p.DaneWysylki)
                    .HasForeignKey(d => d.IdUzytkownik)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("DaneWysylki_Uzytkownik");
            });

            

            modelBuilder.Entity<Napoj>(entity =>
            {
                entity.HasKey(e => e.IdNapoj);

                entity.Property(e => e.IdNapoj).ValueGeneratedNever();

                entity.Property(e => e.IdNazwa)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<NapojZamowienie>(entity =>
            {
                entity.HasKey(e => new { e.IdZamowienie, e.IdNapoj });

                entity.ToTable("Napoj_zamowienie");

                entity.HasOne(d => d.IdNapojNavigation)
                    .WithMany(p => p.NapojZamowienie)
                    .HasForeignKey(d => d.IdNapoj)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Napoj_zamowienie_Napoj");

                entity.HasOne(d => d.IdZamowienieNavigation)
                    .WithMany(p => p.NapojZamowienie)
                    .HasForeignKey(d => d.IdZamowienie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Napoj_zamowienie_Zamowienie");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.HasKey(e => e.IdPizza);

                entity.Property(e => e.IdPizza).ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PizzaCiasto>(entity =>
            {
                entity.HasKey(e => new { e.IdPizza, e.IdCiasto });

                entity.ToTable("Pizza_Ciasto");

                entity.HasOne(d => d.IdCiastoNavigation)
                    .WithMany(p => p.PizzaCiasto)
                    .HasForeignKey(d => d.IdCiasto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pizza_Ciasto_Ciasto");

                entity.HasOne(d => d.IdPizzaNavigation)
                    .WithMany(p => p.PizzaCiasto)
                    .HasForeignKey(d => d.IdPizza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pizza_Ciasto_Pizza");
            });

            modelBuilder.Entity<PizzaSkladnik>(entity =>
            {
                entity.HasKey(e => new { e.IdPizza, e.IdSkladnik });

                entity.ToTable("Pizza_skladnik");

                entity.HasOne(d => d.IdPizzaNavigation)
                    .WithMany(p => p.PizzaSkladnik)
                    .HasForeignKey(d => d.IdPizza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pizza_skladnik_Pizza");

                entity.HasOne(d => d.IdSkladnikNavigation)
                    .WithMany(p => p.PizzaSkladnik)
                    .HasForeignKey(d => d.IdSkladnik)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pizza_skladnik_Skladnik");
            });

            modelBuilder.Entity<Pracownik>(entity =>
            {
                entity.HasKey(e => e.IdPracownik);

                entity.Property(e => e.IdPracownik)
                    .HasColumnName("idPracownik")
                    .ValueGeneratedNever();

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdStanowiskoNavigation)
                    .WithMany(p => p.Pracownik)
                    .HasForeignKey(d => d.IdStanowisko)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pracownik_Stanowisko");
            });

            modelBuilder.Entity<PracownikZamowienie>(entity =>
            {
                entity.HasKey(e => new { e.IdPracownik, e.IdZamowienie });

                entity.ToTable("Pracownik_Zamowienie");

                entity.Property(e => e.IdPracownik).HasColumnName("idPracownik");

                entity.HasOne(d => d.IdPracownikNavigation)
                    .WithMany(p => p.PracownikZamowienie)
                    .HasForeignKey(d => d.IdPracownik)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pracownik_Zamowienie_Pracownik");

                entity.HasOne(d => d.IdZamowienieNavigation)
                    .WithMany(p => p.PracownikZamowienie)
                    .HasForeignKey(d => d.IdZamowienie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pracownik_Zamowienie_Zamowienie");
            });

            modelBuilder.Entity<Promocja>(entity =>
            {
                entity.HasKey(e => e.IdPromocja);

                entity.Property(e => e.IdPromocja).ValueGeneratedNever();

                entity.Property(e => e.Opis)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RodzajPlatnosci>(entity =>
            {
                entity.HasKey(e => e.IdRodzajPlatnosci);

                entity.Property(e => e.IdRodzajPlatnosci).ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Skladnik>(entity =>
            {
                entity.HasKey(e => e.IdSkladnik);

                entity.Property(e => e.IdSkladnik).ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sos>(entity =>
            {
                entity.HasKey(e => e.IdSos);

                entity.Property(e => e.IdSos).ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SosZamowienie>(entity =>
            {
                entity.HasKey(e => new { e.IdZamowienie, e.IdSos });

                entity.ToTable("Sos_Zamowienie");

                entity.HasOne(d => d.IdSosNavigation)
                    .WithMany(p => p.SosZamowienie)
                    .HasForeignKey(d => d.IdSos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Sos_Zamowienie_Sos");

                entity.HasOne(d => d.IdZamowienieNavigation)
                    .WithMany(p => p.SosZamowienie)
                    .HasForeignKey(d => d.IdZamowienie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Sos_Zamowienie_Zamowienie");
            });

            modelBuilder.Entity<Stanowisko>(entity =>
            {
                entity.HasKey(e => e.IdStanowisko);

                entity.Property(e => e.IdStanowisko).ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasColumnName("nazwa")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Uzytkownik>(entity =>
            {
                entity.HasKey(e => e.IdUzytkownik);

                entity.Property(e => e.IdUzytkownik)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Haslo)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Zamowienie>(entity =>
            {
                entity.HasKey(e => e.IdZamowienie);

                entity.Property(e => e.IdZamowienie).ValueGeneratedNever();

                entity.Property(e => e.DaneWysylkiIdDane).HasColumnName("DaneWysylki_idDane");

                entity.Property(e => e.Data).HasColumnType("date");

                entity.HasOne(d => d.DaneWysylkiIdDaneNavigation)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.DaneWysylkiIdDane)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_DaneWysylki");

                entity.HasOne(d => d.IdPromocjaNavigation)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.IdPromocja)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_Promocja");

                entity.HasOne(d => d.RodzajPlatnosciNavigation)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.RodzajPlatnosci)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_RodzajPlatnosci");
            });

            modelBuilder.Entity<ZamowieniePizza>(entity =>
            {
                entity.HasKey(e => new { e.IdZamowienie, e.IdPizza });

                entity.ToTable("Zamowienie_Pizza");

                entity.HasOne(d => d.IdPizzaNavigation)
                    .WithMany(p => p.ZamowieniePizza)
                    .HasForeignKey(d => d.IdPizza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_Pizza_Pizza");

                entity.HasOne(d => d.IdZamowienieNavigation)
                    .WithMany(p => p.ZamowieniePizza)
                    .HasForeignKey(d => d.IdZamowienie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_Pizza_Zamowienie");
            });
        }
    }
}
