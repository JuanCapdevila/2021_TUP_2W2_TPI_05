using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TPI_MSI.Models
{
    public partial class StockBDContext : DbContext
    {
        public StockBDContext()
        {
        }

        public StockBDContext(DbContextOptions<StockBDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DespachosProducto> DespachosProductos { get; set; }
        public virtual DbSet<Destinatario> Destinatarios { get; set; }
        public virtual DbSet<DetallesDespacho> DetallesDespachos { get; set; }
        public virtual DbSet<DetallesPedido> DetallesPedidos { get; set; }
        public virtual DbSet<Empaquetado> Empaquetados { get; set; }
        public virtual DbSet<Estado> Estados { get; set; }
        public virtual DbSet<Estante> Estantes { get; set; }
        public virtual DbSet<Marca> Marcas { get; set; }
        public virtual DbSet<PaisesOrigen> PaisesOrigens { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Proveedore> Proveedores { get; set; }
        public virtual DbSet<Rack> Racks { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Rubro> Rubros { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
        public virtual DbSet<Sucursale> Sucursales { get; set; }
        public virtual DbSet<Ubicacione> Ubicaciones { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Server=localhost;Port=5433;Database=StockBD;User Id=prog3;Password=fortunato");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "English_United States.utf8");

            modelBuilder.Entity<DespachosProducto>(entity =>
            {
                entity.ToTable("despachos_productos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Fechaegreso)
                    .HasColumnType("date")
                    .HasColumnName("fechaegreso");

                entity.Property(e => e.Horaegreso)
                    .HasColumnType("time without time zone")
                    .HasColumnName("horaegreso");

                entity.Property(e => e.Iddestinatario).HasColumnName("iddestinatario");

                entity.Property(e => e.Idrack).HasColumnName("idrack");

                entity.HasOne(d => d.IddestinatarioNavigation)
                    .WithMany(p => p.DespachosProductos)
                    .HasForeignKey(d => d.Iddestinatario)
                    .HasConstraintName("despachos_productos_iddestinatario_fkey");
            });

            modelBuilder.Entity<Destinatario>(entity =>
            {
                entity.ToTable("destinatarios");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(60)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(60)
                    .HasColumnName("direccion");
            });

            modelBuilder.Entity<DetallesDespacho>(entity =>
            {
                entity.ToTable("detalles_despachos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cantidadegresada).HasColumnName("cantidadegresada");

                entity.Property(e => e.Iddespacho).HasColumnName("iddespacho");

                entity.Property(e => e.Idproducto).HasColumnName("idproducto");

                entity.HasOne(d => d.IddespachoNavigation)
                    .WithMany(p => p.DetallesDespachos)
                    .HasForeignKey(d => d.Iddespacho)
                    .HasConstraintName("detalles_despachos_iddespacho_fkey");

                entity.HasOne(d => d.IdproductoNavigation)
                    .WithMany(p => p.DetallesDespachos)
                    .HasForeignKey(d => d.Idproducto)
                    .HasConstraintName("detalles_despachos_idproducto_fkey");
            });

            modelBuilder.Entity<DetallesPedido>(entity =>
            {
                entity.ToTable("detalles_pedido");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cantidadpedida).HasColumnName("cantidadpedida");

                entity.Property(e => e.Cantidadrecibida).HasColumnName("cantidadrecibida");

                entity.Property(e => e.Idpedido).HasColumnName("idpedido");

                entity.Property(e => e.Idproducto).HasColumnName("idproducto");

                entity.Property(e => e.Idubicacion).HasColumnName("idubicacion");

                entity.Property(e => e.Numeroremito).HasColumnName("numeroremito");

                entity.Property(e => e.Totalrecibido).HasColumnName("totalrecibido");

                entity.HasOne(d => d.IdpedidoNavigation)
                    .WithMany(p => p.DetallesPedidos)
                    .HasForeignKey(d => d.Idpedido)
                    .HasConstraintName("detalles_pedido_idpedido_fkey");

                entity.HasOne(d => d.IdproductoNavigation)
                    .WithMany(p => p.DetallesPedidos)
                    .HasForeignKey(d => d.Idproducto)
                    .HasConstraintName("detalles_pedido_idproducto_fkey");

                entity.HasOne(d => d.IdubicacionNavigation)
                    .WithMany(p => p.DetallesPedidos)
                    .HasForeignKey(d => d.Idubicacion)
                    .HasConstraintName("detalles_pedido_idubicacion_fkey");
            });

            modelBuilder.Entity<Empaquetado>(entity =>
            {
                entity.ToTable("empaquetados");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("descripcion");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.ToTable("estados");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("descripcion");
            });

            modelBuilder.Entity<Estante>(entity =>
            {
                entity.ToTable("estantes");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cantidadubicaciones).HasColumnName("cantidadubicaciones");

                entity.Property(e => e.Capacidaddisponible).HasColumnName("capacidaddisponible");

                entity.Property(e => e.Idrack).HasColumnName("idrack");

                entity.HasOne(d => d.IdrackNavigation)
                    .WithMany(p => p.Estantes)
                    .HasForeignKey(d => d.Idrack)
                    .HasConstraintName("estantes_idrack_fkey");
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.ToTable("marcas");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("descripcion");
            });

            modelBuilder.Entity<PaisesOrigen>(entity =>
            {
                entity.ToTable("paises_origen");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PaisOrigen)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("pais_origen");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.ToTable("pedidos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Fechapedido)
                    .HasColumnType("date")
                    .HasColumnName("fechapedido");

                entity.Property(e => e.Fecharealingreso)
                    .HasColumnType("date")
                    .HasColumnName("fecharealingreso");

                entity.Property(e => e.Fecharecepcion)
                    .HasColumnType("date")
                    .HasColumnName("fecharecepcion");

                entity.Property(e => e.Idestado).HasColumnName("idestado");

                entity.Property(e => e.Idproveedor).HasColumnName("idproveedor");

                entity.Property(e => e.Numeroremito).HasColumnName("numeroremito");

                entity.HasOne(d => d.IdestadoNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.Idestado)
                    .HasConstraintName("pedidos_idestado_fkey");

                entity.HasOne(d => d.IdproveedorNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.Idproveedor)
                    .HasConstraintName("pedidos_idproveedor_fkey");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("productos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Esfragil)
                    .HasColumnType("bit(1)")
                    .HasColumnName("esfragil");

                entity.Property(e => e.Idempaquetado).HasColumnName("idempaquetado");

                entity.Property(e => e.Idmarca).HasColumnName("idmarca");

                entity.Property(e => e.Idpaisorigent).HasColumnName("idpaisorigent");

                entity.Property(e => e.Idrubro).HasColumnName("idrubro");

                entity.Property(e => e.Idubicacion).HasColumnName("idubicacion");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("nombre");

                entity.Property(e => e.Peso)
                    .HasPrecision(5, 2)
                    .HasColumnName("peso");

                entity.Property(e => e.Unidadmedicion)
                    .HasMaxLength(60)
                    .HasColumnName("unidadmedicion");

                entity.HasOne(d => d.IdempaquetadoNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.Idempaquetado)
                    .HasConstraintName("productos_idempaquetado_fkey");

                entity.HasOne(d => d.IdmarcaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.Idmarca)
                    .HasConstraintName("productos_idmarca_fkey");

                entity.HasOne(d => d.IdpaisorigentNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.Idpaisorigent)
                    .HasConstraintName("productos_idpaisorigent_fkey");

                entity.HasOne(d => d.IdrubroNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.Idrubro)
                    .HasConstraintName("productos_idrubro_fkey");

                entity.HasOne(d => d.IdubicacionNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.Idubicacion)
                    .HasConstraintName("productos_idUbicaion_fkey");
            });

            modelBuilder.Entity<Proveedore>(entity =>
            {
                entity.ToTable("proveedores");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Razonsocial)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("razonsocial");
            });

            modelBuilder.Entity<Rack>(entity =>
            {
                entity.ToTable("racks");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cantidadestantes).HasColumnName("cantidadestantes");

                entity.Property(e => e.Cantidadubicaciones).HasColumnName("cantidadubicaciones");

                entity.Property(e => e.Capacidaddisponible).HasColumnName("capacidaddisponible");

                entity.Property(e => e.Capacidadtotal).HasColumnName("capacidadtotal");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("descripcion");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("roles");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("descripcion");
            });

            modelBuilder.Entity<Rubro>(entity =>
            {
                entity.ToTable("rubros");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("descripcion");
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.ToTable("stocks");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Idproducto).HasColumnName("idproducto");

                entity.Property(e => e.Idsucursal).HasColumnName("idsucursal");

                entity.Property(e => e.Stockactual).HasColumnName("stockactual");

                entity.HasOne(d => d.IdproductoNavigation)
                    .WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.Idproducto)
                    .HasConstraintName("stocks_idproducto_fkey");

                entity.HasOne(d => d.IdsucursalNavigation)
                    .WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.Idsucursal)
                    .HasConstraintName("stocks_idsucursal_fkey");
            });

            modelBuilder.Entity<Sucursale>(entity =>
            {
                entity.ToTable("sucursales");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(100)
                    .HasColumnName("direccion");

                entity.Property(e => e.Telefono).HasColumnName("telefono");
            });

            modelBuilder.Entity<Ubicacione>(entity =>
            {
                entity.ToTable("ubicaciones");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Disponible).HasColumnName("disponible");

                entity.Property(e => e.Idestante).HasColumnName("idestante");

                entity.HasOne(d => d.IdestanteNavigation)
                    .WithMany(p => p.Ubicaciones)
                    .HasForeignKey(d => d.Idestante)
                    .HasConstraintName("ubicaciones_idestante_fkey");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuarios");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Idrol).HasColumnName("idrol");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .HasColumnName("password");

                entity.Property(e => e.Usuario1)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("usuario");

                //entity.HasOne(d => d.IdrolNavigation)
                   // .WithMany(p => p.Usuarios)
                   // .HasForeignKey(d => d.Idrol)
                   // .HasConstraintName("usuarios_idrol_fkey");
            });

            modelBuilder.HasSequence("seq_pk").HasMax(9999999999);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
