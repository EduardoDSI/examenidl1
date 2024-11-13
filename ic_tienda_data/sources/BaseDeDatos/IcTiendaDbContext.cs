// using ic_tienda_bussines.Auth.models;
using ic_tienda_data.sources.BaseDeDatos.Seeds;
using ic_tienda_data.sources.BaseDeDatos.Tables;
using Microsoft.EntityFrameworkCore;

namespace ic_tienda_data.sources.BaseDeDatos
{
    public class IcTiendaDbContext : DbContext
    {
        public IcTiendaDbContext(
            DbContextOptions<IcTiendaDbContext> opts
        ) : base(opts)
        {
            // AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<PersonaTable>()
                .HasOne(e => e.usuario)
                .WithOne(e => e.persona)
                .HasForeignKey<UsuarioTable>(e => e.id_persona)
                .IsRequired();
            */
            modelBuilder.Entity<PersonaTable>()
                .HasOne <UsuarioTable>()
                .WithOne()
                .HasForeignKey<UsuarioTable>(u => u.id_persona)
                .IsRequired();
            /*
            modelBuilder.Entity<RolTable>()
                .HasMany<UsuarioTable>()
                .WithOne(e => e.rol)
                .HasForeignKey(e => e.id_rol)
                .IsRequired();
            */

            modelBuilder.Entity<RolTable>()
                .HasMany<UsuarioTable>()
                .WithOne()
                .HasForeignKey(r => r.id_rol)
                .IsRequired();

            modelBuilder.Entity<CategoriaTable>()
                .HasMany<ProductoTable>()
                .WithOne()
                .HasForeignKey(p => p.id_categoria)
                .IsRequired();
            
            modelBuilder.Entity<CategoriaTable>()
                .HasMany<CategoriaTable>()
                .WithOne()
                .HasForeignKey(c => c.id_categoria);
            
            modelBuilder.Entity<MarcaTable>()
                .HasMany<ProductoTable>()
                .WithOne()
                .HasForeignKey(p => p.id_marca)
                .IsRequired();

            modelBuilder.Entity<ProductoTable>()
                .HasMany<ImagenProductoTable>()
                .WithOne()
                .HasForeignKey(ip => ip.id_producto)
                .IsRequired();

            

            // ingreso
            modelBuilder.Entity<IngresoTable>()
                .HasMany<IngresoDetalleTable>()
                .WithOne()
                .HasForeignKey(id => id.id_ingreso)
                .IsRequired();
            modelBuilder.Entity<ProductoTable>()
                .HasMany<IngresoDetalleTable>()
                .WithOne()
                .HasForeignKey(id => id.id_producto)
                .IsRequired();
            
            // ventas
            modelBuilder.Entity<VentaTable>()
                .HasMany<VentaDetalleTable>()
                .WithOne()
                .HasForeignKey(vd => vd.id_venta)
                .IsRequired();
            modelBuilder.Entity<ProductoTable>()
                .HasMany<VentaDetalleTable>()
                .WithOne()
                .HasForeignKey(vd => vd.id_producto)
                .IsRequired();
            
            // Citas
            modelBuilder.Entity<OperadorTable>()
                .HasMany<CargaHorariaTable>()
                .WithOne()
                .HasForeignKey(r => r.id_operador)
                .IsRequired();

            modelBuilder.Entity<CargaHorariaTable>()
                .HasMany<CitaTable>()
                .WithOne()
                .HasForeignKey(r => r.id_carga_horaria)
                .IsRequired();    
            modelBuilder.Entity<UsuarioTable>()
                .HasMany<CitaTable>()
                .WithOne()
                .HasForeignKey(r => r.id_usuario)
                .IsRequired();   

            // Seeders
            modelBuilder.Seed();
        }


        #region Tables Security
        public DbSet<PersonaTable> personas { get; set; }
        public DbSet<UsuarioTable> usuarios { get; set; }
        public DbSet<RolTable> roles { get; set; }

        #endregion Tables Security

        #region Tables Tienda
        public DbSet<CategoriaTable> categorias { get; set; }
        public DbSet<MarcaTable> marcas { get; set; }
        public DbSet<ProductoTable> productos { get; set; }
        public DbSet<ImagenProductoTable> imagenesProductos { get; set; }

        #endregion Tables Tienda

        #region Tables Movimientos
        public DbSet<IngresoTable> ingresos { get; set; }
        public DbSet<IngresoDetalleTable> ingresos_detalle { get; set; }
        public DbSet<VentaTable> ventas { get; set; }
        public DbSet<VentaDetalleTable> ventas_detalle { get; set; }

        #endregion Tables Movimientos

        #region Tables Citas
        public DbSet<OperadorTable> operadores { get; set; }
        public DbSet<CargaHorariaTable> cargas_horarias { get; set; }
        public DbSet<CitaTable> citas { get; set; }

        #endregion Tables Citas
    }
}
