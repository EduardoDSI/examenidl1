using ic_tienda_data.sources.BaseDeDatos.Tables;
using Microsoft.EntityFrameworkCore;
using System;


namespace ic_tienda_data.sources.BaseDeDatos.Seeds {
  public static class ModelBuilderExtensions
  {
    public static void Seed(this ModelBuilder modelBuilder)
    {
      #region Security
      modelBuilder.Entity<RolTable>().HasData(
          new RolTable { id = 1, nombre = "Administrador", descripcion = "Administrador del sistema", estado = true },
          new RolTable { id = 2, nombre = "Vendedor", descripcion = "Vendedor del sistema", estado = true },
          new RolTable { id = 3, nombre = "Cliente", descripcion = "Cliente del sistema", estado = true }
      );

      modelBuilder.Entity<PersonaTable>().HasData(
          new PersonaTable { id = 1, nombres = "Jose", apellidos = "Madero", 
            tipo_documento="dni", numero_documento="45454545", telefono="999666331", estado=true },
          new PersonaTable { id = 2, nombres = "Arturo", apellidos = "Damian", 
            tipo_documento="dni", numero_documento="45454546", telefono="999666332", estado=true },
          new PersonaTable { id = 3, nombres = "Roberto", apellidos = "Pereira", 
            tipo_documento="dni", numero_documento="45454547", telefono="999666333", estado=true },
          new PersonaTable { id = 4, nombres = "Dr Chapatin", apellidos = "Chespirito", 
            tipo_documento="dni", numero_documento="45454547", telefono="999666334", estado=true },
          new PersonaTable { id = 5, nombres = "Dr Octavio", apellidos = "Octopus", 
            tipo_documento="dni", numero_documento="45454547", telefono="999666335", estado=true }
      );
      modelBuilder.Entity<UsuarioTable>().HasData(
          new UsuarioTable { id = 1, id_persona = 1, id_rol = 1, correo = "admin@admin.com", clave = "123456", estado = true, salt="qweretrt21212" },
          new UsuarioTable { id = 2, id_persona = 2, id_rol = 2, correo = "user1@user.com", clave = "123456", estado = true, salt="qweretrt21213"  },
          new UsuarioTable { id = 3, id_persona = 3, id_rol = 3, correo = "user2@user.com", clave = "123456", estado = true, salt="qweretrt21213"  }
      );
      #endregion Security
    
      #region Tienda
      modelBuilder.Entity<CategoriaTable>().HasData(
          new CategoriaTable { id = 1, nombre = "Juegos de mesa", descripcion = "Juegos de mesa", estado = true },
          new CategoriaTable { id = 2, nombre = "Juegos de rol", descripcion = "Juegos de rol", estado = true },
          new CategoriaTable { id = 3, nombre = "Wargames", descripcion = "Accesorios", estado = true }
      );
      modelBuilder.Entity<MarcaTable>().HasData(
          new MarcaTable { id = 1, nombre = "WoTC", descripcion = "Wizard", estado = true },
          new MarcaTable { id = 2, nombre = "Games Workshop", descripcion = "Games Workshop", estado = true },
          new MarcaTable { id = 3, nombre = "Peru games", descripcion = "Peru games", estado = true }
      );
      modelBuilder.Entity<ProductoTable>().HasData(
          new ProductoTable { id = 1, nombre = "Manual del jugador DnD 5e", descripcion = "Wizard", 
            id_categoria = 2, codigo = "00001", id_marca = 1, precio_venta=160, stock=10,
            estado = true },
          new ProductoTable { id = 2, nombre = "Deadnougth redemptor", descripcion = "Games Workshop", 
            id_categoria = 3, codigo = "00002", id_marca = 2, precio_venta=250, stock=5,
            estado = true },
          new ProductoTable { id = 3, nombre = "Virus", descripcion = "Peru games", 
            id_categoria = 1, codigo = "00003", id_marca = 3, precio_venta=35, stock=20,
            estado = true }
      );
      #endregion Tienda

      #region Movimientos
       modelBuilder.Entity<VentaTable>().HasData(
        new VentaTable{ id=1, estado=true, id_cliente=3, fecha=new DateTime(2024, 6, 1, 16,0,0),
            tipo_comprobante="boleta", serie_comprobante="1", numero_comprobante="1", impuesto=30, total=300}
       );

       modelBuilder.Entity<VentaDetalleTable>().HasData(
        new VentaDetalleTable { id = 1, cantidad=10, descuento=0, id_producto=3, id_venta=1, precio=30}
       );
      #endregion Movimientos

      #region Citas
      modelBuilder.Entity<OperadorTable>().HasData(
        new OperadorTable { id = 1, id_persona=4, correo="drchapatin@chespi.com", telefono="99988877"},
        new OperadorTable { id = 2, id_persona=5, correo="ottooctavio@villanos.com", telefono="99988877"}
      );

      modelBuilder.Entity<CargaHorariaTable>().HasData(
        new CargaHorariaTable { id = 1, id_operador=1, fecha=new DateTime(2024, 11, 12), hora_inicio=new TimeSpan(0, 8, 0, 0), hora_fin=new TimeSpan(0, 12, 0, 0)},
        new CargaHorariaTable { id = 2, id_operador=1, fecha=new DateTime(2024, 11, 13), hora_inicio=new TimeSpan(0, 9, 0, 0), hora_fin=new TimeSpan(0, 13, 0, 0)}
      );

      modelBuilder.Entity<CitaTable>().HasData(
        new CitaTable { id = 1, 
          id_carga_horaria=1, 
          id_usuario=1, 
          hora_inicio=new TimeSpan(0, 9, 0, 0), 
          estado="RESERVA"}
      );
      #endregion Citas
    }
  }
}