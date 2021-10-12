using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TPI_MSI.Models
{
    public partial class EASYSTOCKBDContext : DbContext
    {
        public EASYSTOCKBDContext()
        {
        }

        public EASYSTOCKBDContext(DbContextOptions<EASYSTOCKBDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DespachosProducto> DespachosProductos { get; set; }
        public virtual DbSet<Destinatario> Destinatarios { get; set; }
        public virtual DbSet<DetallesDespacho> DetallesDespachos { get; set; }
        public virtual DbSet<DetallesDespachoXEstante> DetallesDespachoXEstantes { get; set; }
        public virtual DbSet<DetallesPedido> DetallesPedidos { get; set; }
        public virtual DbSet<DetallesPedidoXEstante> DetallesPedidoXEstantes { get; set; }
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
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Server=localhost;Port=5433;Database=EASYSTOCKBD;User Id=msiES;Password=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "English_United States.utf8");

            modelBuilder.Entity<DespachosProducto>(entity =>
            {
                entity.HasKey(e => e.Iddespachoproducto)
                    .HasName("despachos_productos_pkey");

                entity.ToTable("despachos_productos");

                entity.Property(e => e.Iddespachoproducto)
                    .HasColumnName("iddespachoproducto")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Fechaegreso)
                    .HasColumnType("date")
                    .HasColumnName("fechaegreso");

                entity.Property(e => e.Horaegreso)
                    .HasColumnType("time without time zone")
                    .HasColumnName("horaegreso");

                entity.Property(e => e.Iddestinatariofk).HasColumnName("iddestinatariofk");

                entity.HasOne(d => d.IddestinatariofkNavigation)
                    .WithMany(p => p.DespachosProductos)
                    .HasForeignKey(d => d.Iddestinatariofk)
                    .HasConstraintName("despachos_productos_iddestinatariofk_fkey");
            });

            modelBuilder.Entity<Destinatario>(entity =>
            {
                entity.HasKey(e => e.Iddestinatario)
                    .HasName("destinatarios_pkey");

                entity.ToTable("destinatarios");

                entity.Property(e => e.Iddestinatario)
                    .HasColumnName("iddestinatario")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(60)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(60)
                    .HasColumnName("direccion");
            });

            modelBuilder.Entity<DetallesDespacho>(entity =>
            {
                entity.HasKey(e => e.Iddetalledespacho)
                    .HasName("detalles_despachos_pkey");

                entity.ToTable("detalles_despachos");

                entity.Property(e => e.Iddetalledespacho)
                    .HasColumnName("iddetalledespacho")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Iddespachofk).HasColumnName("iddespachofk");

                entity.Property(e => e.Idproductofk).HasColumnName("idproductofk");

                entity.HasOne(d => d.IddespachofkNavigation)
                    .WithMany(p => p.DetallesDespachos)
                    .HasForeignKey(d => d.Iddespachofk)
                    .HasConstraintName("detalles_despachos_iddespachofk_fkey");

                entity.HasOne(d => d.IdproductofkNavigation)
                    .WithMany(p => p.DetallesDespachos)
                    .HasForeignKey(d => d.Idproductofk)
                    .HasConstraintName("detalles_despachos_idproductofk_fkey");
            });

            modelBuilder.Entity<DetallesDespachoXEstante>(entity =>
            {
                entity.HasKey(e => e.Iddetalledespachoxestante)
                    .HasName("detalles_despacho_x_estantes_pkey");

                entity.ToTable("detalles_despacho_x_estantes");

                entity.Property(e => e.Iddetalledespachoxestante)
                    .HasColumnName("iddetalledespachoxestante")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.IddetallesDespachosfk).HasColumnName("iddetalles_despachosfk");

                entity.Property(e => e.Idestantefk).HasColumnName("idestantefk");

                entity.HasOne(d => d.IddetallesDespachosfkNavigation)
                    .WithMany(p => p.DetallesDespachoXEstantes)
                    .HasForeignKey(d => d.IddetallesDespachosfk)
                    .HasConstraintName("detalles_despacho_x_estantes_iddetalles_despachosfk_fkey");

                entity.HasOne(d => d.IdestantefkNavigation)
                    .WithMany(p => p.DetallesDespachoXEstantes)
                    .HasForeignKey(d => d.Idestantefk)
                    .HasConstraintName("detalles_despacho_x_estantes_idestantefk_fkey");
            });

            modelBuilder.Entity<DetallesPedido>(entity =>
            {
                entity.HasKey(e => e.Iddetallepedido)
                    .HasName("detalles_pedido_pkey");

                entity.ToTable("detalles_pedido");

                entity.Property(e => e.Iddetallepedido)
                    .HasColumnName("iddetallepedido")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Cantidadpedida).HasColumnName("cantidadpedida");

                entity.Property(e => e.Cantidadrecibida).HasColumnName("cantidadrecibida");

                entity.Property(e => e.Idpedidofk).HasColumnName("idpedidofk");

                entity.Property(e => e.Idproductofk).HasColumnName("idproductofk");

                entity.HasOne(d => d.IdpedidofkNavigation)
                    .WithMany(p => p.DetallesPedidos)
                    .HasForeignKey(d => d.Idpedidofk)
                    .HasConstraintName("detalles_pedido_idpedidofk_fkey");

                entity.HasOne(d => d.IdproductofkNavigation)
                    .WithMany(p => p.DetallesPedidos)
                    .HasForeignKey(d => d.Idproductofk)
                    .HasConstraintName("detalles_pedido_idproductofk_fkey");
            });

            modelBuilder.Entity<DetallesPedidoXEstante>(entity =>
            {
                entity.HasKey(e => e.Iddetallepedidoxestante)
                    .HasName("detalles_pedido_x_estantes_pkey");

                entity.ToTable("detalles_pedido_x_estantes");

                entity.Property(e => e.Iddetallepedidoxestante)
                    .HasColumnName("iddetallepedidoxestante")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.IddetallesPedidofk).HasColumnName("iddetalles_pedidofk");

                entity.Property(e => e.Idestantefk).HasColumnName("idestantefk");

                entity.HasOne(d => d.IddetallesPedidofkNavigation)
                    .WithMany(p => p.DetallesPedidoXEstantes)
                    .HasForeignKey(d => d.IddetallesPedidofk)
                    .HasConstraintName("detalles_pedido_x_estantes_iddetalles_pedidofk_fkey");

                entity.HasOne(d => d.IdestantefkNavigation)
                    .WithMany(p => p.DetallesPedidoXEstantes)
                    .HasForeignKey(d => d.Idestantefk)
                    .HasConstraintName("detalles_pedido_x_estantes_idestantefk_fkey");
            });

            modelBuilder.Entity<Empaquetado>(entity =>
            {
                entity.HasKey(e => e.Idempaquetado)
                    .HasName("empaquetados_pkey");

                entity.ToTable("empaquetados");

                entity.Property(e => e.Idempaquetado)
                    .HasColumnName("idempaquetado")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("descripcion");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.Idestado)
                    .HasName("estados_pkey");

                entity.ToTable("estados");

                entity.Property(e => e.Idestado)
                    .HasColumnName("idestado")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("descripcion");
            });

            modelBuilder.Entity<Estante>(entity =>
            {
                entity.HasKey(e => e.Idestante)
                    .HasName("estantes_pkey");

                entity.ToTable("estantes");

                entity.Property(e => e.Idestante)
                    .HasColumnName("idestante")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Capacidaddisponible).HasColumnName("capacidaddisponible");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(40)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Idrackfk).HasColumnName("idrackfk");

                entity.HasOne(d => d.IdrackfkNavigation)
                    .WithMany(p => p.Estantes)
                    .HasForeignKey(d => d.Idrackfk)
                    .HasConstraintName("estantes_idrackfk_fkey");
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.HasKey(e => e.Idmarca)
                    .HasName("marcas_pkey");

                entity.ToTable("marcas");

                entity.Property(e => e.Idmarca)
                    .HasColumnName("idmarca")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("descripcion");
            });

            modelBuilder.Entity<PaisesOrigen>(entity =>
            {
                entity.HasKey(e => e.Idpaisorigen)
                    .HasName("paises_origen_pkey");

                entity.ToTable("paises_origen");

                entity.Property(e => e.Idpaisorigen)
                    .HasColumnName("idpaisorigen")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.PaisOrigen)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("pais_origen");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.Idpedido)
                    .HasName("pedidos_pkey");

                entity.ToTable("pedidos");

                entity.Property(e => e.Idpedido)
                    .HasColumnName("idpedido")
                    .UseIdentityAlwaysColumn();

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

                entity.Property(e => e.Idestadofk).HasColumnName("idestadofk");

                entity.Property(e => e.Idproveedorfk).HasColumnName("idproveedorfk");

                entity.Property(e => e.Numeroremito).HasColumnName("numeroremito");

                entity.HasOne(d => d.IdestadofkNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.Idestadofk)
                    .HasConstraintName("pedidos_idestadofk_fkey");

                entity.HasOne(d => d.IdproveedorfkNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.Idproveedorfk)
                    .HasConstraintName("pedidos_idproveedorfk_fkey");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.Idproducto)
                    .HasName("productos_pkey");

                entity.ToTable("productos");

                entity.Property(e => e.Idproducto)
                    .HasColumnName("idproducto")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Esfragil).HasColumnName("esfragil");

                entity.Property(e => e.Idempaquetadofk).HasColumnName("idempaquetadofk");

                entity.Property(e => e.Idmarcafk).HasColumnName("idmarcafk");

                entity.Property(e => e.Idpaisorigenfk).HasColumnName("idpaisorigenfk");

                entity.Property(e => e.Idrubrofk).HasColumnName("idrubrofk");

                entity.Property(e => e.Idstockfk).HasColumnName("idstockfk");

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

                entity.HasOne(d => d.IdempaquetadofkNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.Idempaquetadofk)
                    .HasConstraintName("productos_idempaquetadofk_fkey");

                entity.HasOne(d => d.IdmarcafkNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.Idmarcafk)
                    .HasConstraintName("productos_idmarcafk_fkey");

                entity.HasOne(d => d.IdpaisorigenfkNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.Idpaisorigenfk)
                    .HasConstraintName("productos_idpaisorigenfk_fkey");

                entity.HasOne(d => d.IdrubrofkNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.Idrubrofk)
                    .HasConstraintName("productos_idrubrofk_fkey");

                entity.HasOne(d => d.IdstockfkNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.Idstockfk)
                    .HasConstraintName("productos_idstockfk_fkey");
            });

            modelBuilder.Entity<Proveedore>(entity =>
            {
                entity.HasKey(e => e.Idproveedor)
                    .HasName("proveedores_pkey");

                entity.ToTable("proveedores");

                entity.Property(e => e.Idproveedor)
                    .HasColumnName("idproveedor")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Direccion)
                    .HasMaxLength(40)
                    .HasColumnName("direccion");

                entity.Property(e => e.Razonsocial)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("razonsocial");
            });

            modelBuilder.Entity<Rack>(entity =>
            {
                entity.HasKey(e => e.Idrack)
                    .HasName("racks_pkey");

                entity.ToTable("racks");

                entity.Property(e => e.Idrack)
                    .HasColumnName("idrack")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Cantidadestantes).HasColumnName("cantidadestantes");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("descripcion");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.Idrol)
                    .HasName("roles_pkey");

                entity.ToTable("roles");

                entity.Property(e => e.Idrol)
                    .HasColumnName("idrol")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("descripcion");
            });

            modelBuilder.Entity<Rubro>(entity =>
            {
                entity.HasKey(e => e.Idrubro)
                    .HasName("rubros_pkey");

                entity.ToTable("rubros");

                entity.Property(e => e.Idrubro)
                    .HasColumnName("idrubro")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("descripcion");
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.HasKey(e => e.Idstock)
                    .HasName("stocks_pkey");

                entity.ToTable("stocks");

                entity.Property(e => e.Idstock)
                    .HasColumnName("idstock")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Stockactual).HasColumnName("stockactual");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Idusuario)
                    .HasName("usuarios_pkey");

                entity.ToTable("usuarios");

                entity.Property(e => e.Idusuario)
                    .HasColumnName("idusuario")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Contrasenia)
                    .HasMaxLength(20)
                    .HasColumnName("contrasenia");

                entity.Property(e => e.Idrolfk).HasColumnName("idrolfk");

                entity.Property(e => e.Usuario1)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("usuario");

                entity.HasOne(d => d.IdrolfkNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.Idrolfk)
                    .HasConstraintName("usuarios_idrolfk_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
