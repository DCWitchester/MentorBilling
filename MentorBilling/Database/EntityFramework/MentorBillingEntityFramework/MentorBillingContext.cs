using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MentorBilling.Database.EntityFramework.MentorBillingEntityFramework
{
    public partial class MentorBillingContext : DbContext
    {
        public MentorBillingContext()
        {
        }

        public MentorBillingContext(DbContextOptions<MentorBillingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Abonamente> Abonamente { get; set; }
        public virtual DbSet<AbonamenteUtilizatori> AbonamenteUtilizatori { get; set; }
        public virtual DbSet<AnafInfo> ANAFInfo { get; set; }
        public virtual DbSet<ClaseDrepturi> ClaseDrepturi { get; set; }
        public virtual DbSet<ClaseDrepturiPredefinite> ClaseDrepturiPredefinite { get; set; }
        public virtual DbSet<ConturiBancareCumparatori> ConturiBancareCumparatori { get; set; }
        public virtual DbSet<ConturiBancareFurnizori> ConturiBancareFurnizori { get; set; }
        public virtual DbSet<CoteTva> CoteTva { get; set; }
        public virtual DbSet<CoteTvaUtilizatori> CoteTvaUtilizatori { get; set; }
        public virtual DbSet<Cumparatori> Cumparatori { get; set; }
        public virtual DbSet<DateExpeditie> DateExpeditie { get; set; }
        public virtual DbSet<Delegati> Delegati { get; set; }
        public virtual DbSet<Drepturi> Drepturi { get; set; }
        public virtual DbSet<DrepturiUtilizatori> DrepturiUtilizatori { get; set; }
        public virtual DbSet<Factura> Factura { get; set; }
        public virtual DbSet<FacturaDetalii> FacturaDetalii { get; set; }
        public virtual DbSet<FormeJuridie> FormeJuridice { get; set; }
        public virtual DbSet<Furnizori> Furnizori { get; set; }
        public virtual DbSet<Grupuri> Grupuri { get; set; }
        public virtual DbSet<GrupuriUtilizatori> GrupuriUtilizatori { get; set; }
        public virtual DbSet<InstitutiiBancare> InstitutiiBancare { get; set; }
        public virtual DbSet<Judete> Judete { get; set; }
        public virtual DbSet<LogActiuni> LogActiuni { get; set; }
        public virtual DbSet<LogUtilizatori> LogUtilizatori { get; set; }
        public virtual DbSet<MeniuUtilizator> MeniuUtilizator { get; set; }
        public virtual DbSet<PlajeDocumente> PlajeDocumente { get; set; }
        public virtual DbSet<Produse> Produse { get; set; }
        public virtual DbSet<Setari> Setari { get; set; }
        public virtual DbSet<SetariUtilizatori> SetariUtilizatori { get; set; }
        public virtual DbSet<Tari> Tari { get; set; }
        public virtual DbSet<Utilizatori> Utilizatori { get; set; }
        public virtual DbSet<UtilizatoriLastUsed> UtilizatoriLastUsed { get; set; }
        public virtual DbSet<UtilizatoriPlaje> UtilizatoriPlaje { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(Settings.Settings.DatabaseConnectionSettings.CurrentConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Abonamente>(entity =>
            {
                entity.ToTable("abonamente", "users");

                entity.HasComment("Tabela aceasta va contine valori standard predefinite ale viitoarelor abonamente");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activ)
                    .IsRequired()
                    .HasColumnName("activ")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Denumire)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("denumire")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.DimensiuneMaximaGrup)
                    .HasColumnName("dimensiune_maxima_grup")
                    .HasDefaultValueSql("1")
                    .HasComment("Coloana aceasta va contine dimensiunea maxima admisa a grupului");

                entity.Property(e => e.Explicatii)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("explicatii")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.PerioadaPlata)
                    .HasColumnName("perioada_plata")
                    .HasDefaultValueSql("30")
                    .HasComment("Coloana aceasta va contine perioada de activitate a abonamentului in zile");

                entity.Property(e => e.ValoareLunara)
                    .HasColumnName("valoare_lunara")
                    .HasComment("Coloana aceasta va contine valoarea lunara de baza a unui abonament. Aceasta poate suferi costuri aditionale.");
            });

            modelBuilder.Entity<AbonamenteUtilizatori>(entity =>
            {
                entity.ToTable("abonamente_utilizatori", "users");

                entity.HasComment("Tabela de legatura intre tabela de abonamente si tabela de utilizatori");

                entity.HasIndex(e => new { e.UtilizatorId, e.AbonamentId }, "abonamente_utilizatori_utilizator_id_abonament_id_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AbonamentId).HasColumnName("abonament_id");

                entity.Property(e => e.Activ)
                    .IsRequired()
                    .HasColumnName("activ")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.DimensiuneMaximaGrup)
                    .HasColumnName("dimensiune_maxima_grup")
                    .HasDefaultValueSql("1")
                    .HasComment("Coloana aceasta va contine dimensiunea maxima admisa a grupului");

                entity.Property(e => e.PerioadaActiva)
                    .HasColumnName("perioada_activa")
                    .HasDefaultValueSql("30")
                    .HasComment("Coloana aceasta va contine perioada e activitate pentru abonamentul curent de la ultima plata in numar de zile");

                entity.Property(e => e.UltimaPlata)
                    .HasColumnName("ultima_plata")
                    .HasDefaultValueSql("('now'::text)::timestamp without time zone")
                    .HasComment("Coloana aceasta va contine data efectiva a ultimei plati pe abonamentul curent");

                entity.Property(e => e.UtilizatorId).HasColumnName("utilizator_id");

                entity.Property(e => e.ValoareLunara)
                    .HasColumnName("valoare_lunara")
                    .HasComment("Coloana aceasta va contine valoare efectiva de plata a utilizatorului curent");

                entity.HasOne(d => d.Abonament)
                    .WithMany(p => p.AbonamenteUtilizatori)
                    .HasForeignKey(d => d.AbonamentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("abonamente_utilizatori_abonament_id_fkey");

                entity.HasOne(d => d.Utilizator)
                    .WithMany(p => p.AbonamenteUtilizatori)
                    .HasForeignKey(d => d.UtilizatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("abonamente_utilizatori_utilizator_id_fkey");
            });

            modelBuilder.Entity<AnafInfo>(entity =>
            {
                entity.ToTable("anaf_info", "glossary");

                entity.HasComment("Tabela aceasta va contine pe perioade starile societatilor preluate de la anaf pe baza interogarilor clientilor");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CodFiscal)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("cod_fiscal")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.InfoFile)
                    .HasColumnType("json")
                    .HasColumnName("info_file");

                entity.Property(e => e.MomentFinal).HasColumnName("moment_final");

                entity.Property(e => e.MomentInitial)
                    .HasColumnName("moment_initial")
                    .HasDefaultValueSql("('01.01.1900'::text)::timestamp without time zone");
            });

            modelBuilder.Entity<ClaseDrepturi>(entity =>
            {
                entity.ToTable("clase_drepturi", "users");

                entity.HasComment("Tabela de legatura intre tabela users.clase_drepturi_predefinite si tabela drepturi");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activ)
                    .IsRequired()
                    .HasColumnName("activ")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.ClasaId).HasColumnName("clasa_id");

                entity.Property(e => e.DreptId).HasColumnName("drept_id");

                entity.Property(e => e.ValoareDrept)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("valoare_drept")
                    .HasDefaultValueSql("''::character varying")
                    .HasComment("Coloana asta va contine valoare efectiva a dreptului relativ la coloana de tip_drept din tabela de drepturi");

                entity.HasOne(d => d.Clasa)
                    .WithMany(p => p.ClaseDrepturi)
                    .HasForeignKey(d => d.ClasaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("clase_drepturi_clasa_id_fkey");

                entity.HasOne(d => d.Drept)
                    .WithMany(p => p.ClaseDrepturi)
                    .HasForeignKey(d => d.DreptId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("clase_drepturi_drept_id_fkey");
            });

            modelBuilder.Entity<ClaseDrepturiPredefinite>(entity =>
            {
                entity.ToTable("clase_drepturi_predefinite", "users");

                entity.HasComment("Tabela aceasta va contine niste clase predefinite de drepturi pentru accesul in program");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activ)
                    .IsRequired()
                    .HasColumnName("activ")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Denumire)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("denumire")
                    .HasDefaultValueSql("''::character varying");
            });

            modelBuilder.Entity<ConturiBancareCumparatori>(entity =>
            {
                entity.ToTable("conturi_bancare_cumparatori", "buyer");

                entity.HasComment("Tabela aceasta va cuprinde toate conturile bancare ale unui cumparator");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activ)
                    .IsRequired()
                    .HasColumnName("activ")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Banca)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("banca")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Cont)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("cont")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.CumparatoriId).HasColumnName("cumparatori_id");

                entity.HasOne(d => d.Cumparatori)
                    .WithMany(p => p.ConturiBancareCumparatori)
                    .HasForeignKey(d => d.CumparatoriId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("conturi_bancare_cumparatori_cumparatori_id_fkey");
            });

            modelBuilder.Entity<ConturiBancareFurnizori>(entity =>
            {
                entity.ToTable("conturi_bancare_furnizori", "seller");

                entity.HasComment("Tabela aceasta va contine toate conturile bancare aferente unei anume societati");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activ)
                    .IsRequired()
                    .HasColumnName("activ")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Banca)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("banca")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Cont)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("cont")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.FurnizorId).HasColumnName("furnizor_id");

                entity.HasOne(d => d.Furnizor)
                    .WithMany(p => p.ConturiBancareFurnizori)
                    .HasForeignKey(d => d.FurnizorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("conturi_bancare_furnizori_furnizor_id_fkey");
            });

            modelBuilder.Entity<CoteTva>(entity =>
            {
                entity.ToTable("cote_tva", "glossary");

                entity.HasComment("Tabela aceasta cuprinde nomenclatorul de cote de tva din program. Nici un client nu o poate altera");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activ)
                    .IsRequired()
                    .HasColumnName("activ")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Cod)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("cod")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Cota)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("cota")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.IndiceCasaMarcat)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("indice_casa_marcat")
                    .HasDefaultValueSql("''::character varying")
                    .HasComment("Coloana aceasta va cuprinde valoarea default a indicelui casei de marcat");

                entity.Property(e => e.Tva)
                    .HasPrecision(2)
                    .HasColumnName("tva");
            });

            modelBuilder.Entity<CoteTvaUtilizatori>(entity =>
            {
                entity.ToTable("cote_tva_utilizatori", "settings");

                entity.HasComment("Tabela aceasta va contine legatura intre glosarul de cote de tva si setarile specifice ale utilizatorului");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activ)
                    .IsRequired()
                    .HasColumnName("activ")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.CotaTvaId).HasColumnName("cota_tva_id");

                entity.Property(e => e.IndiceCasaMarcat)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("indice_casa_marcat")
                    .HasDefaultValueSql("0")
                    .HasComment("Coloana necesara pentru imprimarea bonului fiscal pe casa de marcat");

                entity.Property(e => e.UtilizatorId).HasColumnName("utilizator_id");

                entity.HasOne(d => d.CotaTva)
                    .WithMany(p => p.CoteTvaUtilizatori)
                    .HasForeignKey(d => d.CotaTvaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cote_tva_utilizatori_cota_tva_id_fkey");

                entity.HasOne(d => d.Utilizator)
                    .WithMany(p => p.CoteTvaUtilizatori)
                    .HasForeignKey(d => d.UtilizatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cote_tva_utilizatori_utilizator_id_fkey");
            });

            modelBuilder.Entity<Cumparatori>(entity =>
            {
                entity.ToTable("cumparatori", "buyer");

                entity.HasComment("Tabela aceasta va cuprinde lista completa de cumparatori pentru un anume client");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activ)
                    .IsRequired()
                    .HasColumnName("activ")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.AdresaLivrare)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("adresa_livrare")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.CodFiscal)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("cod_fiscal")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.CodPartener)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("cod_partener")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Denumire)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("denumire")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("email")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Judetul).HasColumnName("judetul");

                entity.Property(e => e.NrRegistruComert)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("nr_registru_comert")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Sediul)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("sediul")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Tara).HasColumnName("tara");

                entity.Property(e => e.UtilizatorId).HasColumnName("utilizator_id");

                entity.HasOne(d => d.JudetulNavigation)
                    .WithMany(p => p.Cumparatori)
                    .HasForeignKey(d => d.Judetul)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cumparatori_judetul_fkey");

                entity.HasOne(d => d.TaraNavigation)
                    .WithMany(p => p.Cumparatori)
                    .HasForeignKey(d => d.Tara)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cumparatori_tara_fkey");

                entity.HasOne(d => d.Utilizator)
                    .WithMany(p => p.Cumparatori)
                    .HasForeignKey(d => d.UtilizatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cumparatori_utilizator_id_fkey");
            });

            modelBuilder.Entity<DateExpeditie>(entity =>
            {
                entity.ToTable("date_expeditie", "invoice");

                entity.HasComment("Tabela curenta contine datele de expeditie aferente unei facturi");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activ)
                    .IsRequired()
                    .HasColumnName("activ")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.DataExpediere)
                    .HasColumnName("data_expediere")
                    .HasDefaultValueSql("('now'::text)::timestamp without time zone");

                entity.Property(e => e.DelegatId).HasColumnName("delegat_id");

                entity.Property(e => e.FacturaId).HasColumnName("factura_id");

                entity.HasOne(d => d.Delegat)
                    .WithMany(p => p.DateExpeditie)
                    .HasForeignKey(d => d.DelegatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("date_expeditie_delegat_id_fkey");

                entity.HasOne(d => d.Factura)
                    .WithMany(p => p.DateExpeditie)
                    .HasForeignKey(d => d.FacturaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("date_expeditie_factura_id_fkey");
            });

            modelBuilder.Entity<Delegati>(entity =>
            {
                entity.ToTable("delegati", "seller");

                entity.HasComment("Tabela curenta contine toti delegatii unui utilizator");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activ)
                    .IsRequired()
                    .HasColumnName("activ")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Denumire)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("denumire")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.EliberatorBuletin)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("eliberator_buletin")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.MijlocTransport)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("mijloc_transport")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.NumarBuletin)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("numar_buletin")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.NumarMijlocTranspot)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("numar_mijloc_transpot")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.SerieBuletin)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("serie_buletin")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.UtilizatorId).HasColumnName("utilizator_id");

                entity.HasOne(d => d.Utilizator)
                    .WithMany(p => p.Delegati)
                    .HasForeignKey(d => d.UtilizatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("delegati_utilizator_id_fkey");
            });

            modelBuilder.Entity<Drepturi>(entity =>
            {
                entity.ToTable("drepturi", "users");

                entity.HasComment("Tabela de drepturi pentru program care va contine toate drepturile posibile din program");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activ)
                    .IsRequired()
                    .HasColumnName("activ")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Drept)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("drept")
                    .HasDefaultValueSql("''::character varying")
                    .HasComment("Coloana asta va contine denumirea dreptului folosita pentru afisare");

                entity.Property(e => e.TipDrept)
                    .HasColumnName("tip_drept")
                    .HasComment("Coloana va fi legata de un enum din program care da tipul de valoarea al coloanei");
            });

            modelBuilder.Entity<DrepturiUtilizatori>(entity =>
            {
                entity.ToTable("drepturi_utilizatori", "users");

                entity.HasComment("Tabela de legatura intre tabela de drepturi si cea de utilizatori");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activ)
                    .IsRequired()
                    .HasColumnName("activ")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.DreptId).HasColumnName("drept_id");

                entity.Property(e => e.UtilizatorId).HasColumnName("utilizator_id");

                entity.Property(e => e.ValoareDrept)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("valoare_drept")
                    .HasDefaultValueSql("''::character varying")
                    .HasComment("Coloana asta va contine valoare efectiva a dreptului relativ la coloana de tip_drept din tabela de drepturi");

                entity.HasOne(d => d.Drept)
                    .WithMany(p => p.DrepturiUtilizatori)
                    .HasForeignKey(d => d.DreptId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("drepturi_utilizatori_drept_id_fkey");

                entity.HasOne(d => d.Utilizator)
                    .WithMany(p => p.DrepturiUtilizatori)
                    .HasForeignKey(d => d.UtilizatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("drepturi_utilizatori_utilizator_id_fkey");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.ToTable("factura", "invoice");

                entity.HasComment("Tabela aceasta va contine toate facturile unui utilizator");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activ)
                    .IsRequired()
                    .HasColumnName("activ")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.CreatorId)
                    .HasColumnName("creator_id")
                    .HasComment("Coloana aceasta va contine utilizatorul care a creat acest document. Folositor doar in cazul grupurilor");

                entity.Property(e => e.CumparatorId).HasColumnName("cumparator_id");

                entity.Property(e => e.DataDocument)
                    .HasColumnName("data_document")
                    .HasDefaultValueSql("('now'::text)::timestamp without time zone");

                entity.Property(e => e.FurnizorId).HasColumnName("furnizor_id");

                entity.Property(e => e.NumarAviz).HasColumnName("numar_aviz");

                entity.Property(e => e.NumarDocumet).HasColumnName("numar_documet");

                entity.Property(e => e.SerieDocument)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("serie_document")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.TotalTva).HasColumnName("total_tva");

                entity.Property(e => e.TotalValoare).HasColumnName("total_valoare");

                entity.Property(e => e.TvaIncasare).HasColumnName("tva_incasare");

                entity.Property(e => e.UtilizatorId).HasColumnName("utilizator_id");

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.FacturaCreator)
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("factura_creator_id_fkey");

                entity.HasOne(d => d.Cumparator)
                    .WithMany(p => p.Factura)
                    .HasForeignKey(d => d.CumparatorId)
                    .HasConstraintName("factura_cumparator_id_fkey");

                entity.HasOne(d => d.Furnizor)
                    .WithMany(p => p.Factura)
                    .HasForeignKey(d => d.FurnizorId)
                    .HasConstraintName("factura_furnizor_id_fkey");

                entity.HasOne(d => d.Utilizator)
                    .WithMany(p => p.FacturaUtilizator)
                    .HasForeignKey(d => d.UtilizatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("factura_utilizator_id_fkey");
            });

            modelBuilder.Entity<FacturaDetalii>(entity =>
            {
                entity.ToTable("factura_detalii", "invoice");

                entity.HasComment("Tabela aceasta va cuprinde toate detaliile aferente unei facturi");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activ)
                    .IsRequired()
                    .HasColumnName("activ")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Cantitate).HasColumnName("cantitate");

                entity.Property(e => e.Discount).HasColumnName("discount");

                entity.Property(e => e.FacturaId).HasColumnName("factura_id");

                entity.Property(e => e.PretUnitar).HasColumnName("pret_unitar");

                entity.Property(e => e.ProdusId).HasColumnName("produs_id");

                entity.HasOne(d => d.Factura)
                    .WithMany(p => p.FacturaDetalii)
                    .HasForeignKey(d => d.FacturaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("factura_detalii_factura_id_fkey");

                entity.HasOne(d => d.Produs)
                    .WithMany(p => p.FacturaDetalii)
                    .HasForeignKey(d => d.ProdusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("factura_detalii_produs_id_fkey");
            });

            modelBuilder.Entity<FormeJuridie>(entity =>
            {
                entity.ToTable("forme_juridice", "glossary");

                entity.HasComment("Tabela aceasta va contine toate formele juridice posibile. Momentan nu va fi folosit.");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cod)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("cod")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Denumire)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("denumire")
                    .HasDefaultValueSql("''::character varying");
            });

            modelBuilder.Entity<Furnizori>(entity =>
            {
                entity.ToTable("furnizori", "seller");

                entity.HasComment("Tabela aceasta va contine toate societatile pentru care un utilizator poate emite facturi");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activ)
                    .IsRequired()
                    .HasColumnName("activ")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.CapitalSocial).HasColumnName("capital_social");

                entity.Property(e => e.CodFiscal)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("cod_fiscal")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Denumire)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("denumire")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("email")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.NrRegistruComert)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("nr_registru_comert")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.PunctLucru)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("punct_lucru")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Sediul)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("sediul")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Sigla)
                    .IsRequired()
                    .HasColumnName("sigla")
                    .HasDefaultValueSql("'\\x'::bytea")
                    .HasComment("Coloana aceasta va contine sigla societatii ca array de biti");

                entity.Property(e => e.Telefon)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("telefon")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.UtilizatorId).HasColumnName("utilizator_id");

                entity.HasOne(d => d.Utilizator)
                    .WithMany(p => p.Furnizori)
                    .HasForeignKey(d => d.UtilizatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("furnizori_utilizator_id_fkey");
            });

            modelBuilder.Entity<Grupuri>(entity =>
            {
                entity.ToTable("grupuri", "users");

                entity.HasComment("Tabela centrala pentru structura de grupuri, folosita pentru a grupa n-utilizatori");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activ)
                    .IsRequired()
                    .HasColumnName("activ")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.AdministratorGrup)
                    .HasColumnName("administrator_grup")
                    .HasComment("Administratorul grupului va fi cel de care legam facturile, clienti, firmele si alte inregistrari");

                entity.Property(e => e.Denumire)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("denumire")
                    .HasDefaultValueSql("''::character varying");

                entity.HasOne(d => d.AdministratorGrupNavigation)
                    .WithMany(p => p.Grupuri)
                    .HasForeignKey(d => d.AdministratorGrup)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("grupuri_administrator_grup_fkey");
            });

            modelBuilder.Entity<GrupuriUtilizatori>(entity =>
            {
                entity.ToTable("grupuri_utilizatori", "users");

                entity.HasComment("Tabela de legatura intre grupuri si utilizatori");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activ)
                    .IsRequired()
                    .HasColumnName("activ")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.GrupId).HasColumnName("grup_id");

                entity.Property(e => e.UtilizatorId).HasColumnName("utilizator_id");

                entity.HasOne(d => d.Grup)
                    .WithMany(p => p.GrupuriUtilizatori)
                    .HasForeignKey(d => d.GrupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("grupuri_utilizatori_grup_id_fkey");

                entity.HasOne(d => d.Utilizator)
                    .WithMany(p => p.GrupuriUtilizatori)
                    .HasForeignKey(d => d.UtilizatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("grupuri_utilizatori_utilizator_id_fkey");
            });

            modelBuilder.Entity<InstitutiiBancare>(entity =>
            {
                entity.ToTable("institutii_bancare", "glossary");

                entity.HasComment("Tabela aceasta va contine toate institutiile bancare folosite pe teritoriul Romaniei");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CodIban)
                    .IsRequired()
                    .HasMaxLength(4)
                    .HasColumnName("cod_iban")
                    .HasDefaultValueSql("''::character varying")
                    .HasComment("In general primele 4 caractere ale codului BIC folosite pentru identificarea codului IBAN");

                entity.Property(e => e.CodSwift)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasColumnName("cod_swift")
                    .HasDefaultValueSql("''::character varying")
                    .HasComment("Codul swift sau cod BIC reprezinta codul unic de identificare al unei banci la nivel international");

                entity.Property(e => e.Denumire)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("denumire")
                    .HasDefaultValueSql("''::character varying");
            });

            modelBuilder.Entity<Judete>(entity =>
            {
                entity.ToTable("judete", "glossary");

                entity.HasComment("Tabela aceasta cuprinde nomenclatorul de judete din program. Nici un client nu o poate altera");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activ)
                    .IsRequired()
                    .HasColumnName("activ")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.CodJudet)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnName("cod_judet")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.DenJudet)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("den_judet")
                    .HasDefaultValueSql("''::character varying");
            });

            modelBuilder.Entity<LogActiuni>(entity =>
            {
                entity.ToTable("log_actiuni", "log");

                entity.HasComment("Tabela curenta va contine toate actiunile unui anume utilizator");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Actiune)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("actiune")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Comanda)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("comanda")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.IpActiune)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("ip_actiune")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.OraActiune)
                    .HasColumnName("ora_actiune")
                    .HasDefaultValueSql("('now'::text)::timestamp without time zone");

                entity.Property(e => e.UtilizatorId).HasColumnName("utilizator_id");

                entity.HasOne(d => d.Utilizator)
                    .WithMany(p => p.LogActiuni)
                    .HasForeignKey(d => d.UtilizatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("log_actiuni_utilizator_id_fkey");
            });

            modelBuilder.Entity<LogUtilizatori>(entity =>
            {
                entity.ToTable("log_utilizatori", "log");

                entity.HasComment("Tabela curenta contine toate logarile si delogari utilizatorilor");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateLogare)
                    .IsRequired()
                    .HasColumnType("json")
                    .HasColumnName("date_logare")
                    .HasDefaultValueSql("'{}'::json");

                entity.Property(e => e.IpLogare)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("ip_logare")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Logged).HasColumnName("logged");

                entity.Property(e => e.OraLogare)
                    .HasColumnName("ora_logare")
                    .HasDefaultValueSql("('now'::text)::timestamp without time zone");

                entity.Property(e => e.UtilizatorId).HasColumnName("utilizator_id");

                entity.HasOne(d => d.Utilizator)
                    .WithMany(p => p.LogUtilizatori)
                    .HasForeignKey(d => d.UtilizatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("log_utilizatori_utilizator_id_fkey");
            });

            modelBuilder.Entity<MeniuUtilizator>(entity =>
            {
                entity.ToTable("meniu_utilizator", "settings");

                entity.HasComment("Tabela aceasta va contine inregistrarea specifica a utilizatorului");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activ)
                    .IsRequired()
                    .HasColumnName("activ")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.InregistrareMeniu)
                    .HasColumnName("inregistrare_meniu")
                    .HasComment("Vom mentine legatura intre enumul din program si cel din baza");

                entity.Property(e => e.UtilizatorId).HasColumnName("utilizator_id");

                entity.HasOne(d => d.Utilizator)
                    .WithMany(p => p.MeniuUtilizator)
                    .HasForeignKey(d => d.UtilizatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("meniu_utilizator_utilizator_id_fkey");
            });

            modelBuilder.Entity<PlajeDocumente>(entity =>
            {
                entity.ToTable("plaje_documente", "settings");

                entity.HasComment("Tabela aceasta va contine plajele de documente(facturi,chitante) create de un utilizator");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activ)
                    .IsRequired()
                    .HasColumnName("activ")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.CreatorPlaja)
                    .HasColumnName("creator_plaja")
                    .HasComment("Coloana aceasta va contine creatorul plajei. Va fi folosit in cazul in care utilizatorul nu va apartine niciunui grup.");

                entity.Property(e => e.Serie)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("serie")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.TipDocument).HasColumnName("tip_document");

                entity.Property(e => e.ValoareCurenta)
                    .HasColumnName("valoare_curenta")
                    .HasComment("Coloana aceasta va contine valoarea curenta a plajei. Se incrementeaza la fiecare document");

                entity.Property(e => e.ValoareFinala).HasColumnName("valoare_finala");

                entity.Property(e => e.ValoareInitiala).HasColumnName("valoare_initiala");

                entity.HasOne(d => d.CreatorPlajaNavigation)
                    .WithMany(p => p.PlajeDocumente)
                    .HasForeignKey(d => d.CreatorPlaja)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("plaje_documente_creator_plaja_fkey");
            });

            modelBuilder.Entity<Produse>(entity =>
            {
                entity.ToTable("produse", "invoice");

                entity.HasComment("Tabela aceasta va contine toate produsele unui utilizator. Tabela aceasta exista doar in cazul in care unii clienti vor vrea");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activ)
                    .IsRequired()
                    .HasColumnName("activ")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.CodProdus)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("cod_produs")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.CotaTvaId).HasColumnName("cota_tva_id");

                entity.Property(e => e.Denumire)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("denumire")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.PretUnitar).HasColumnName("pret_unitar");

                entity.Property(e => e.UnitateMasura)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("unitate_masura")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.UtilizatorId).HasColumnName("utilizator_id");

                entity.HasOne(d => d.CotaTva)
                    .WithMany(p => p.Produse)
                    .HasForeignKey(d => d.CotaTvaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("produse_cota_tva_id_fkey");

                entity.HasOne(d => d.Utilizator)
                    .WithMany(p => p.Produse)
                    .HasForeignKey(d => d.UtilizatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("produse_utilizator_id_fkey");
            });

            modelBuilder.Entity<Setari>(entity =>
            {
                entity.ToTable("setari", "settings");

                entity.HasComment("Tabela aceasta va contine toate setarile programului la nivel de setare");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activ)
                    .IsRequired()
                    .HasColumnName("activ")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Placeholder)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("placeholder")
                    .HasDefaultValueSql("''::character varying")
                    .HasComment("Folosit pentru afisarea in pagina de setari pentru anumite tipuri de date");

                entity.Property(e => e.Setare)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("setare")
                    .HasDefaultValueSql("''::character varying")
                    .HasComment("Setare va fi textul afisat utilizatorului final");

                entity.Property(e => e.TipDateSetare)
                    .HasColumnName("tip_date_setare")
                    .HasComment("Coloana aceasta va contine tipul de date al setarii legata de un enum din program");

                entity.Property(e => e.TipInputSetare)
                    .HasColumnName("tip_input_setare")
                    .HasComment("Coloana aceasta va contine tipul obiectului de input pentru aceasta setare legat de un enum din program");

                entity.Property(e => e.Tooltip)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("tooltip")
                    .HasDefaultValueSql("''::character varying")
                    .HasComment("Folosit pentru afisarea in pagina de setari a tooltipuri aditionale");

                entity.Property(e => e.ValoareInitiala)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("valoare_initiala")
                    .HasDefaultValueSql("''::character varying")
                    .HasComment("Valoarea initiala a setari se va salva ca string: base value for all types");
            });

            modelBuilder.Entity<SetariUtilizatori>(entity =>
            {
                entity.ToTable("setari_utilizatori", "settings");

                entity.HasComment("Tabela aceasta va contine toate setarile aferente utilizatorilor la nivel de valoare");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activ)
                    .IsRequired()
                    .HasColumnName("activ")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.SetareId).HasColumnName("setare_id");

                entity.Property(e => e.UtilizatorId).HasColumnName("utilizator_id");

                entity.Property(e => e.ValoareSetare)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("valoare_setare")
                    .HasDefaultValueSql("''::character varying")
                    .HasComment("Coloana aceasta va contine valoarea efectiva a setari pentru utilizatorul selectat");

                entity.HasOne(d => d.Setare)
                    .WithMany(p => p.SetariUtilizatori)
                    .HasForeignKey(d => d.SetareId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("setari_utilizatori_setare_id_fkey");

                entity.HasOne(d => d.Utilizator)
                    .WithMany(p => p.SetariUtilizatori)
                    .HasForeignKey(d => d.UtilizatorId)
                    .HasConstraintName("setari_utilizatori_utilizator_id_fkey");
            });

            modelBuilder.Entity<Tari>(entity =>
            {
                entity.ToTable("tari", "glossary");

                entity.HasComment("Tabela aceasta cuprinde nomenclatorul de tari din program. Nici un client nu o poate altera");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activ)
                    .IsRequired()
                    .HasColumnName("activ")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.CodTaraIso2)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnName("cod_tara_iso2")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.CodTaraIso3)
                    .IsRequired()
                    .HasMaxLength(3)
                    .HasColumnName("cod_tara_iso3")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.CodTaraIsoM49)
                    .IsRequired()
                    .HasMaxLength(3)
                    .HasColumnName("cod_tara_iso_m49")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.DenTaraEn)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("den_tara_en")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.DenTaraRo)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("den_tara_ro")
                    .HasDefaultValueSql("''::character varying");
            });

            modelBuilder.Entity<Utilizatori>(entity =>
            {
                entity.ToTable("utilizatori", "users");

                entity.HasComment("Tabela centrala pentru structura de utilizatori");

                entity.HasIndex(e => e.Email, "utilizatori_email_key")
                    .IsUnique();

                entity.HasIndex(e => e.NumeUtilizator, "utilizatori_nume_utilizator_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activ)
                    .IsRequired()
                    .HasColumnName("activ")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("email")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Nume)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("nume")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.NumeUtilizator)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("nume_utilizator")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Parola)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("parola")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.ParolaAutogenerata)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("parola_autogenerata")
                    .HasDefaultValueSql("''::character varying")
                    .HasComment("Parola autogenerata va fi folosita doar cand se uita parola si se doreste modificarea ei");

                entity.Property(e => e.Prenume)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("prenume")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Sysadmin).HasColumnName("sysadmin");
            });

            modelBuilder.Entity<UtilizatoriLastUsed>(entity =>
            {
                entity.ToTable("utilizatori_last_used", "seller");

                entity.HasComment("Tabela curenta va contine toate setarile legate de ultima factura pentru autocomplete");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activ)
                    .IsRequired()
                    .HasColumnName("activ")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.ConturiBancareLastUsed).HasColumnName("conturi_bancare_last_used");

                entity.Property(e => e.DelegatiLastUsed).HasColumnName("delegati_last_used");

                entity.Property(e => e.FurnizoriLastUsed).HasColumnName("furnizori_last_used");

                entity.Property(e => e.UtilizatorId).HasColumnName("utilizator_id");

                entity.HasOne(d => d.ConturiBancareLastUsedNavigation)
                    .WithMany(p => p.UtilizatoriLastUsed)
                    .HasForeignKey(d => d.ConturiBancareLastUsed)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("utilizatori_last_used_conturi_bancare_last_used_fkey");

                entity.HasOne(d => d.DelegatiLastUsedNavigation)
                    .WithMany(p => p.UtilizatoriLastUsed)
                    .HasForeignKey(d => d.DelegatiLastUsed)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("utilizatori_last_used_delegati_last_used_fkey");

                entity.HasOne(d => d.FurnizoriLastUsedNavigation)
                    .WithMany(p => p.UtilizatoriLastUsed)
                    .HasForeignKey(d => d.FurnizoriLastUsed)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("utilizatori_last_used_furnizori_last_used_fkey");

                entity.HasOne(d => d.Utilizator)
                    .WithMany(p => p.UtilizatoriLastUsed)
                    .HasForeignKey(d => d.UtilizatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("utilizatori_last_used_utilizator_id_fkey");
            });

            modelBuilder.Entity<UtilizatoriPlaje>(entity =>
            {
                entity.ToTable("utilizatori_plaje", "settings");

                entity.HasComment("Tabela aceasta este tabela de legatura intre tabelele de utilizatori si cea de plaje");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activ)
                    .IsRequired()
                    .HasColumnName("activ")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.PlajeDocumentId).HasColumnName("plaje_document_id");

                entity.Property(e => e.UtilizatorId).HasColumnName("utilizator_id");

                entity.HasOne(d => d.PlajeDocument)
                    .WithMany(p => p.UtilizatoriPlaje)
                    .HasForeignKey(d => d.PlajeDocumentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("utilizatori_plaje_plaje_document_id_fkey");

                entity.HasOne(d => d.Utilizator)
                    .WithMany(p => p.UtilizatoriPlaje)
                    .HasForeignKey(d => d.UtilizatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("utilizatori_plaje_utilizator_id_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
