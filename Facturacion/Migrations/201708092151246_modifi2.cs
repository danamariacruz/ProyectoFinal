namespace Facturacion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifi2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Facturas", "ListaVentaId", c => c.Int(nullable: false));
            AddColumn("dbo.ListaVentas", "ProductoID", c => c.Int(nullable: false));
            CreateIndex("dbo.Facturas", "ListaVentaId");
            CreateIndex("dbo.ListaVentas", "ProductoID");
            AddForeignKey("dbo.ListaVentas", "ProductoID", "dbo.Productos", "ProductoID", cascadeDelete: true);
            AddForeignKey("dbo.Facturas", "ListaVentaId", "dbo.ListaVentas", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Facturas", "ListaVentaId", "dbo.ListaVentas");
            DropForeignKey("dbo.ListaVentas", "ProductoID", "dbo.Productos");
            DropIndex("dbo.ListaVentas", new[] { "ProductoID" });
            DropIndex("dbo.Facturas", new[] { "ListaVentaId" });
            DropColumn("dbo.ListaVentas", "ProductoID");
            DropColumn("dbo.Facturas", "ListaVentaId");
        }
    }
}
