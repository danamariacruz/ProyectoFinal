namespace Facturacion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifi1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Facturas",
                c => new
                    {
                        FacturaID = c.Int(nullable: false, identity: true),
                        VentasID = c.Int(nullable: false),
                        ClienteID = c.Int(nullable: false),
                        Ventas_VentaID = c.Int(),
                    })
                .PrimaryKey(t => t.FacturaID)
                .ForeignKey("dbo.Clientes", t => t.ClienteID, cascadeDelete: true)
                .ForeignKey("dbo.Ventas", t => t.Ventas_VentaID)
                .Index(t => t.ClienteID)
                .Index(t => t.Ventas_VentaID);
            
            CreateTable(
                "dbo.ListaVentas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        VentaId = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        Total = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Ventas", t => t.VentaId, cascadeDelete: true)
                .Index(t => t.VentaId);
            
            CreateTable(
                "dbo.Productos",
                c => new
                    {
                        ProductoID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Descripcion = c.String(maxLength: 50),
                        PrecioUnidad = c.Double(nullable: false),
                        Disponibilidad = c.Double(nullable: false),
                        categoria_CategoriaId = c.Int(),
                        VendedoresID_VendedorID = c.Int(),
                    })
                .PrimaryKey(t => t.ProductoID)
                .ForeignKey("dbo.Categorias", t => t.categoria_CategoriaId)
                .ForeignKey("dbo.Vendedores", t => t.VendedoresID_VendedorID)
                .Index(t => t.categoria_CategoriaId)
                .Index(t => t.VendedoresID_VendedorID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Productos", "VendedoresID_VendedorID", "dbo.Vendedores");
            DropForeignKey("dbo.Productos", "categoria_CategoriaId", "dbo.Categorias");
            DropForeignKey("dbo.ListaVentas", "VentaId", "dbo.Ventas");
            DropForeignKey("dbo.Facturas", "Ventas_VentaID", "dbo.Ventas");
            DropForeignKey("dbo.Facturas", "ClienteID", "dbo.Clientes");
            DropIndex("dbo.Productos", new[] { "VendedoresID_VendedorID" });
            DropIndex("dbo.Productos", new[] { "categoria_CategoriaId" });
            DropIndex("dbo.ListaVentas", new[] { "VentaId" });
            DropIndex("dbo.Facturas", new[] { "Ventas_VentaID" });
            DropIndex("dbo.Facturas", new[] { "ClienteID" });
            DropTable("dbo.Productos");
            DropTable("dbo.ListaVentas");
            DropTable("dbo.Facturas");
        }
    }
}
