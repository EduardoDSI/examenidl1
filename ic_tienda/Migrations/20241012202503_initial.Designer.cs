﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ic_tienda_data.sources.BaseDeDatos;

#nullable disable

namespace ic_tienda_presentacion.Migrations
{
    [DbContext(typeof(IcTiendaDbContext))]
    [Migration("20241012202503_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.31")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ic_tienda_data.sources.BaseDeDatos.Tables.CategoriaTable", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.Property<int?>("id_categoria")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("id_categoria");

                    b.ToTable("categorias", "Tienda");

                    b.HasData(
                        new
                        {
                            id = 1,
                            descripcion = "Juegos de mesa",
                            estado = true,
                            nombre = "Juegos de mesa"
                        },
                        new
                        {
                            id = 2,
                            descripcion = "Juegos de rol",
                            estado = true,
                            nombre = "Juegos de rol"
                        },
                        new
                        {
                            id = 3,
                            descripcion = "Accesorios",
                            estado = true,
                            nombre = "Wargames"
                        });
                });

            modelBuilder.Entity("ic_tienda_data.sources.BaseDeDatos.Tables.ImagenProductoTable", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.Property<int>("id_producto")
                        .HasColumnType("int");

                    b.Property<string>("url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("id_producto");

                    b.ToTable("imagen_productos", "Tienda");
                });

            modelBuilder.Entity("ic_tienda_data.sources.BaseDeDatos.Tables.IngresoDetalleTable", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("cantidad")
                        .HasColumnType("int");

                    b.Property<decimal>("costo")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("id_ingreso")
                        .HasColumnType("int");

                    b.Property<int>("id_producto")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("id_ingreso");

                    b.HasIndex("id_producto");

                    b.ToTable("ingreso_detalle", "Movimientos");
                });

            modelBuilder.Entity("ic_tienda_data.sources.BaseDeDatos.Tables.IngresoTable", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("id_provedor")
                        .HasColumnType("int");

                    b.Property<int>("id_usuario")
                        .HasColumnType("int");

                    b.Property<decimal>("impuesto")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("numero_comprobante")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("serie_comprobante")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tipo_comprobante")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("total")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("id");

                    b.ToTable("ingresos", "Movimientos");
                });

            modelBuilder.Entity("ic_tienda_data.sources.BaseDeDatos.Tables.MarcaTable", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("marcas", "Tienda");

                    b.HasData(
                        new
                        {
                            id = 1,
                            descripcion = "Wizard",
                            estado = true,
                            nombre = "WoTC"
                        },
                        new
                        {
                            id = 2,
                            descripcion = "Games Workshop",
                            estado = true,
                            nombre = "Games Workshop"
                        },
                        new
                        {
                            id = 3,
                            descripcion = "Peru games",
                            estado = true,
                            nombre = "Peru games"
                        });
                });

            modelBuilder.Entity("ic_tienda_data.sources.BaseDeDatos.Tables.PersonaTable", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("apellidos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.Property<string>("nombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("numero_documento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tipo_documento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("personas", "Security");

                    b.HasData(
                        new
                        {
                            id = 1,
                            apellidos = "Madero",
                            estado = true,
                            nombres = "Jose",
                            numero_documento = "45454545",
                            telefono = "999666331",
                            tipo_documento = "dni"
                        },
                        new
                        {
                            id = 2,
                            apellidos = "Damian",
                            estado = true,
                            nombres = "Arturo",
                            numero_documento = "45454546",
                            telefono = "999666332",
                            tipo_documento = "dni"
                        },
                        new
                        {
                            id = 3,
                            apellidos = "Pereira",
                            estado = true,
                            nombres = "Roberto",
                            numero_documento = "45454547",
                            telefono = "999666333",
                            tipo_documento = "dni"
                        });
                });

            modelBuilder.Entity("ic_tienda_data.sources.BaseDeDatos.Tables.ProductoTable", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.Property<int>("id_categoria")
                        .HasColumnType("int");

                    b.Property<int>("id_marca")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("precio_venta")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("stock")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("id_categoria");

                    b.HasIndex("id_marca");

                    b.ToTable("productos", "Tienda");

                    b.HasData(
                        new
                        {
                            id = 1,
                            codigo = "00001",
                            descripcion = "Wizard",
                            estado = true,
                            id_categoria = 2,
                            id_marca = 1,
                            nombre = "Manual del jugador DnD 5e",
                            precio_venta = 160m,
                            stock = 10
                        },
                        new
                        {
                            id = 2,
                            codigo = "00002",
                            descripcion = "Games Workshop",
                            estado = true,
                            id_categoria = 3,
                            id_marca = 2,
                            nombre = "Deadnougth redemptor",
                            precio_venta = 250m,
                            stock = 5
                        },
                        new
                        {
                            id = 3,
                            codigo = "00003",
                            descripcion = "Peru games",
                            estado = true,
                            id_categoria = 1,
                            id_marca = 3,
                            nombre = "Virus",
                            precio_venta = 35m,
                            stock = 20
                        });
                });

            modelBuilder.Entity("ic_tienda_data.sources.BaseDeDatos.Tables.RolTable", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("rols", "Security");

                    b.HasData(
                        new
                        {
                            id = 1,
                            descripcion = "Administrador del sistema",
                            estado = true,
                            nombre = "Administrador"
                        },
                        new
                        {
                            id = 2,
                            descripcion = "Vendedor del sistema",
                            estado = true,
                            nombre = "Vendedor"
                        },
                        new
                        {
                            id = 3,
                            descripcion = "Cliente del sistema",
                            estado = true,
                            nombre = "Cliente"
                        });
                });

            modelBuilder.Entity("ic_tienda_data.sources.BaseDeDatos.Tables.UsuarioTable", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("clave")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<string>("correo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.Property<int>("id_persona")
                        .HasColumnType("int");

                    b.Property<int>("id_rol")
                        .HasColumnType("int");

                    b.Property<string>("salt")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("id");

                    b.HasIndex("id_persona")
                        .IsUnique();

                    b.HasIndex("id_rol");

                    b.ToTable("app_usuarios", "Security");

                    b.HasData(
                        new
                        {
                            id = 1,
                            clave = "123456",
                            correo = "admin@admin.com",
                            estado = true,
                            id_persona = 1,
                            id_rol = 1,
                            salt = "qweretrt21212"
                        },
                        new
                        {
                            id = 2,
                            clave = "123456",
                            correo = "user1@user.com",
                            estado = true,
                            id_persona = 2,
                            id_rol = 2,
                            salt = "qweretrt21213"
                        },
                        new
                        {
                            id = 3,
                            clave = "123456",
                            correo = "user2@user.com",
                            estado = true,
                            id_persona = 3,
                            id_rol = 3,
                            salt = "qweretrt21213"
                        });
                });

            modelBuilder.Entity("ic_tienda_data.sources.BaseDeDatos.Tables.VentaDetalleTable", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("cantidad")
                        .HasColumnType("int");

                    b.Property<decimal>("descuento")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)");

                    b.Property<int?>("id_oferta")
                        .HasColumnType("int");

                    b.Property<int>("id_producto")
                        .HasColumnType("int");

                    b.Property<int>("id_venta")
                        .HasColumnType("int");

                    b.Property<decimal>("precio")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("id");

                    b.HasIndex("id_producto");

                    b.HasIndex("id_venta");

                    b.ToTable("ventas_detalle", "Movimientos");

                    b.HasData(
                        new
                        {
                            id = 1,
                            cantidad = 10,
                            descuento = 0m,
                            id_producto = 3,
                            id_venta = 1,
                            precio = 30m
                        });
                });

            modelBuilder.Entity("ic_tienda_data.sources.BaseDeDatos.Tables.VentaTable", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("id_cliente")
                        .HasColumnType("int");

                    b.Property<decimal>("impuesto")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)");

                    b.Property<string>("numero_comprobante")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("serie_comprobante")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tipo_comprobante")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("total")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("id");

                    b.ToTable("ventas", "Movimientos");

                    b.HasData(
                        new
                        {
                            id = 1,
                            estado = true,
                            fecha = new DateTime(2024, 6, 1, 16, 0, 0, 0, DateTimeKind.Unspecified),
                            id_cliente = 3,
                            impuesto = 30m,
                            numero_comprobante = "1",
                            serie_comprobante = "1",
                            tipo_comprobante = "boleta",
                            total = 300m
                        });
                });

            modelBuilder.Entity("ic_tienda_data.sources.BaseDeDatos.Tables.CategoriaTable", b =>
                {
                    b.HasOne("ic_tienda_data.sources.BaseDeDatos.Tables.CategoriaTable", null)
                        .WithMany()
                        .HasForeignKey("id_categoria");
                });

            modelBuilder.Entity("ic_tienda_data.sources.BaseDeDatos.Tables.ImagenProductoTable", b =>
                {
                    b.HasOne("ic_tienda_data.sources.BaseDeDatos.Tables.ProductoTable", null)
                        .WithMany()
                        .HasForeignKey("id_producto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ic_tienda_data.sources.BaseDeDatos.Tables.IngresoDetalleTable", b =>
                {
                    b.HasOne("ic_tienda_data.sources.BaseDeDatos.Tables.IngresoTable", null)
                        .WithMany()
                        .HasForeignKey("id_ingreso")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ic_tienda_data.sources.BaseDeDatos.Tables.ProductoTable", null)
                        .WithMany()
                        .HasForeignKey("id_producto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ic_tienda_data.sources.BaseDeDatos.Tables.ProductoTable", b =>
                {
                    b.HasOne("ic_tienda_data.sources.BaseDeDatos.Tables.CategoriaTable", null)
                        .WithMany()
                        .HasForeignKey("id_categoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ic_tienda_data.sources.BaseDeDatos.Tables.MarcaTable", null)
                        .WithMany()
                        .HasForeignKey("id_marca")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ic_tienda_data.sources.BaseDeDatos.Tables.UsuarioTable", b =>
                {
                    b.HasOne("ic_tienda_data.sources.BaseDeDatos.Tables.PersonaTable", null)
                        .WithOne()
                        .HasForeignKey("ic_tienda_data.sources.BaseDeDatos.Tables.UsuarioTable", "id_persona")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ic_tienda_data.sources.BaseDeDatos.Tables.RolTable", null)
                        .WithMany()
                        .HasForeignKey("id_rol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ic_tienda_data.sources.BaseDeDatos.Tables.VentaDetalleTable", b =>
                {
                    b.HasOne("ic_tienda_data.sources.BaseDeDatos.Tables.ProductoTable", null)
                        .WithMany()
                        .HasForeignKey("id_producto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ic_tienda_data.sources.BaseDeDatos.Tables.VentaTable", null)
                        .WithMany()
                        .HasForeignKey("id_venta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
