namespace SharpitterVS.Helpers {
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Models;

    public partial class SharpitterDbMysql : DbContext {
        public SharpitterDbMysql() : base("name=SharpitterDbMysql") { }

        public virtual DbSet<Sharpp> Sharpps { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<Sharpp>()
                .Property(e => e.Autor)
                .IsUnicode(false);

            modelBuilder.Entity<Sharpp>()
                .Property(e => e.Texto)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Senha)
                .IsUnicode(false);
        }
    }
}
