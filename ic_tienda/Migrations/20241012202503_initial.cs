using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ic_tienda_presentacion.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Security");

            migrationBuilder.EnsureSchema(
                name: "Tienda");

            migrationBuilder.EnsureSchema(
                name: "Movimientos");

            migrationBuilder.CreateTable(
                name: "categorias",
                schema: "Tienda",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_categoria = table.Column<int>(type: "int", nullable: true),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categorias", x => x.id);
                    table.ForeignKey(
                        name: "FK_categorias_categorias_id_categoria",
                        column: x => x.id_categoria,
                        principalSchema: "Tienda",
                        principalTable: "categorias",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ingresos",
                schema: "Movimientos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_provedor = table.Column<int>(type: "int", nullable: false),
                    id_usuario = table.Column<int>(type: "int", nullable: false),
                    tipo_comprobante = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    serie_comprobante = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numero_comprobante = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    total = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    impuesto = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingresos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "marcas",
                schema: "Tienda",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_marcas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "personas",
                schema: "Security",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tipo_documento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numero_documento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "rols",
                schema: "Security",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rols", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ventas",
                schema: "Movimientos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_cliente = table.Column<int>(type: "int", nullable: false),
                    tipo_comprobante = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    serie_comprobante = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numero_comprobante = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    total = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    impuesto = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ventas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "productos",
                schema: "Tienda",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_categoria = table.Column<int>(type: "int", nullable: false),
                    id_marca = table.Column<int>(type: "int", nullable: false),
                    codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    precio_venta = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    stock = table.Column<int>(type: "int", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productos", x => x.id);
                    table.ForeignKey(
                        name: "FK_productos_categorias_id_categoria",
                        column: x => x.id_categoria,
                        principalSchema: "Tienda",
                        principalTable: "categorias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_productos_marcas_id_marca",
                        column: x => x.id_marca,
                        principalSchema: "Tienda",
                        principalTable: "marcas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "app_usuarios",
                schema: "Security",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_persona = table.Column<int>(type: "int", nullable: false),
                    id_rol = table.Column<int>(type: "int", nullable: false),
                    correo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    clave = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    salt = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_app_usuarios", x => x.id);
                    table.ForeignKey(
                        name: "FK_app_usuarios_personas_id_persona",
                        column: x => x.id_persona,
                        principalSchema: "Security",
                        principalTable: "personas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_app_usuarios_rols_id_rol",
                        column: x => x.id_rol,
                        principalSchema: "Security",
                        principalTable: "rols",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "imagen_productos",
                schema: "Tienda",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_producto = table.Column<int>(type: "int", nullable: false),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_imagen_productos", x => x.id);
                    table.ForeignKey(
                        name: "FK_imagen_productos_productos_id_producto",
                        column: x => x.id_producto,
                        principalSchema: "Tienda",
                        principalTable: "productos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ingreso_detalle",
                schema: "Movimientos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_ingreso = table.Column<int>(type: "int", nullable: false),
                    id_producto = table.Column<int>(type: "int", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    costo = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingreso_detalle", x => x.id);
                    table.ForeignKey(
                        name: "FK_ingreso_detalle_ingresos_id_ingreso",
                        column: x => x.id_ingreso,
                        principalSchema: "Movimientos",
                        principalTable: "ingresos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ingreso_detalle_productos_id_producto",
                        column: x => x.id_producto,
                        principalSchema: "Tienda",
                        principalTable: "productos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ventas_detalle",
                schema: "Movimientos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_venta = table.Column<int>(type: "int", nullable: false),
                    id_producto = table.Column<int>(type: "int", nullable: false),
                    id_oferta = table.Column<int>(type: "int", nullable: true),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    precio = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    descuento = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ventas_detalle", x => x.id);
                    table.ForeignKey(
                        name: "FK_ventas_detalle_productos_id_producto",
                        column: x => x.id_producto,
                        principalSchema: "Tienda",
                        principalTable: "productos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ventas_detalle_ventas_id_venta",
                        column: x => x.id_venta,
                        principalSchema: "Movimientos",
                        principalTable: "ventas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Tienda",
                table: "categorias",
                columns: new[] { "id", "descripcion", "estado", "id_categoria", "nombre" },
                values: new object[,]
                {
                    { 1, "Juegos de mesa", true, null, "Juegos de mesa" },
                    { 2, "Juegos de rol", true, null, "Juegos de rol" },
                    { 3, "Accesorios", true, null, "Wargames" }
                });

            migrationBuilder.InsertData(
                schema: "Tienda",
                table: "marcas",
                columns: new[] { "id", "descripcion", "estado", "nombre" },
                values: new object[,]
                {
                    { 1, "Wizard", true, "WoTC" },
                    { 2, "Games Workshop", true, "Games Workshop" },
                    { 3, "Peru games", true, "Peru games" }
                });

            migrationBuilder.InsertData(
                schema: "Security",
                table: "personas",
                columns: new[] { "id", "apellidos", "estado", "nombres", "numero_documento", "telefono", "tipo_documento" },
                values: new object[,]
                {
                    { 1, "Madero", true, "Jose", "45454545", "999666331", "dni" },
                    { 2, "Damian", true, "Arturo", "45454546", "999666332", "dni" },
                    { 3, "Pereira", true, "Roberto", "45454547", "999666333", "dni" }
                });

            migrationBuilder.InsertData(
                schema: "Security",
                table: "rols",
                columns: new[] { "id", "descripcion", "estado", "nombre" },
                values: new object[,]
                {
                    { 1, "Administrador del sistema", true, "Administrador" },
                    { 2, "Vendedor del sistema", true, "Vendedor" },
                    { 3, "Cliente del sistema", true, "Cliente" }
                });

            migrationBuilder.InsertData(
                schema: "Movimientos",
                table: "ventas",
                columns: new[] { "id", "estado", "fecha", "id_cliente", "impuesto", "numero_comprobante", "serie_comprobante", "tipo_comprobante", "total" },
                values: new object[] { 1, true, new DateTime(2024, 6, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), 3, 30m, "1", "1", "boleta", 300m });

            migrationBuilder.InsertData(
                schema: "Security",
                table: "app_usuarios",
                columns: new[] { "id", "clave", "correo", "estado", "id_persona", "id_rol", "salt" },
                values: new object[,]
                {
                    { 1, "123456", "admin@admin.com", true, 1, 1, "qweretrt21212" },
                    { 2, "123456", "user1@user.com", true, 2, 2, "qweretrt21213" },
                    { 3, "123456", "user2@user.com", true, 3, 3, "qweretrt21213" }
                });

            migrationBuilder.InsertData(
                schema: "Tienda",
                table: "productos",
                columns: new[] { "id", "codigo", "descripcion", "estado", "id_categoria", "id_marca", "nombre", "precio_venta", "stock" },
                values: new object[,]
                {
                    { 1, "00001", "Wizard", true, 2, 1, "Manual del jugador DnD 5e", 160m, 10 },
                    { 2, "00002", "Games Workshop", true, 3, 2, "Deadnougth redemptor", 250m, 5 },
                    { 3, "00003", "Peru games", true, 1, 3, "Virus", 35m, 20 }
                });

            migrationBuilder.InsertData(
                schema: "Movimientos",
                table: "ventas_detalle",
                columns: new[] { "id", "cantidad", "descuento", "id_oferta", "id_producto", "id_venta", "precio" },
                values: new object[] { 1, 10, 0m, null, 3, 1, 30m });

            migrationBuilder.CreateIndex(
                name: "IX_app_usuarios_id_persona",
                schema: "Security",
                table: "app_usuarios",
                column: "id_persona",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_app_usuarios_id_rol",
                schema: "Security",
                table: "app_usuarios",
                column: "id_rol");

            migrationBuilder.CreateIndex(
                name: "IX_categorias_id_categoria",
                schema: "Tienda",
                table: "categorias",
                column: "id_categoria");

            migrationBuilder.CreateIndex(
                name: "IX_imagen_productos_id_producto",
                schema: "Tienda",
                table: "imagen_productos",
                column: "id_producto");

            migrationBuilder.CreateIndex(
                name: "IX_ingreso_detalle_id_ingreso",
                schema: "Movimientos",
                table: "ingreso_detalle",
                column: "id_ingreso");

            migrationBuilder.CreateIndex(
                name: "IX_ingreso_detalle_id_producto",
                schema: "Movimientos",
                table: "ingreso_detalle",
                column: "id_producto");

            migrationBuilder.CreateIndex(
                name: "IX_productos_id_categoria",
                schema: "Tienda",
                table: "productos",
                column: "id_categoria");

            migrationBuilder.CreateIndex(
                name: "IX_productos_id_marca",
                schema: "Tienda",
                table: "productos",
                column: "id_marca");

            migrationBuilder.CreateIndex(
                name: "IX_ventas_detalle_id_producto",
                schema: "Movimientos",
                table: "ventas_detalle",
                column: "id_producto");

            migrationBuilder.CreateIndex(
                name: "IX_ventas_detalle_id_venta",
                schema: "Movimientos",
                table: "ventas_detalle",
                column: "id_venta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "app_usuarios",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "imagen_productos",
                schema: "Tienda");

            migrationBuilder.DropTable(
                name: "ingreso_detalle",
                schema: "Movimientos");

            migrationBuilder.DropTable(
                name: "ventas_detalle",
                schema: "Movimientos");

            migrationBuilder.DropTable(
                name: "personas",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "rols",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "ingresos",
                schema: "Movimientos");

            migrationBuilder.DropTable(
                name: "productos",
                schema: "Tienda");

            migrationBuilder.DropTable(
                name: "ventas",
                schema: "Movimientos");

            migrationBuilder.DropTable(
                name: "categorias",
                schema: "Tienda");

            migrationBuilder.DropTable(
                name: "marcas",
                schema: "Tienda");
        }
    }
}
