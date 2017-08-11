namespace Facturacion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifi4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Productos", "categoria_CategoriaId", "dbo.Categorias");
            DropForeignKey("dbo.Productos", "VendedoresID_VendedorID", "dbo.Vendedores");
            DropIndex("dbo.Productos", new[] { "categoria_CategoriaId" });
            DropIndex("dbo.Productos", new[] { "VendedoresID_VendedorID" });
            RenameColumn(table: "dbo.Productos", name: "categoria_CategoriaId", newName: "CategoriaID");
            RenameColumn(table: "dbo.Productos", name: "VendedoresID_VendedorID", newName: "VendedorID");
            AlterColumn("dbo.Productos", "CategoriaID", c => c.Int(nullable: false));
            AlterColumn("dbo.Productos", "VendedorID", c => c.Int(nullable: false));
            CreateIndex("dbo.Productos", "VendedorID");
            CreateIndex("dbo.Productos", "CategoriaID");
            AddForeignKey("dbo.Productos", "CategoriaID", "dbo.Categorias", "CategoriaId", cascadeDelete: true);
            AddForeignKey("dbo.Productos", "VendedorID", "dbo.Vendedores", "VendedorID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Productos", "VendedorID", "dbo.Vendedores");
            DropForeignKey("dbo.Productos", "CategoriaID", "dbo.Categorias");
            DropIndex("dbo.Productos", new[] { "CategoriaID" });
            DropIndex("dbo.Productos", new[] { "VendedorID" });
            AlterColumn("dbo.Productos", "VendedorID", c => c.Int());
            AlterColumn("dbo.Productos", "CategoriaID", c => c.Int());
            RenameColumn(table: "dbo.Productos", name: "VendedorID", newName: "VendedoresID_VendedorID");
            RenameColumn(table: "dbo.Productos", name: "CategoriaID", newName: "categoria_CategoriaId");
            CreateIndex("dbo.Productos", "VendedoresID_VendedorID");
            CreateIndex("dbo.Productos", "categoria_CategoriaId");
            AddForeignKey("dbo.Productos", "VendedoresID_VendedorID", "dbo.Vendedores", "VendedorID");
            AddForeignKey("dbo.Productos", "categoria_CategoriaId", "dbo.Categorias", "CategoriaId");
        }
    }
}
