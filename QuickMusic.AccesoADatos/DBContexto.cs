using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickMusic.EntidadesDeNegocio;
using Microsoft.EntityFrameworkCore;

namespace QuickMusic.AccesoADatos
{
    public class DBContexto : DbContext
    {
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Artista> Artista { get; set; }
        public DbSet<Genero> Genero { get; set; }
        public DbSet<Canciones> Canciones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-E348I49E\SQLEXPRESS; Initial Catalog = QuickMusic; Integrated Security=True");
        }

    }
}
