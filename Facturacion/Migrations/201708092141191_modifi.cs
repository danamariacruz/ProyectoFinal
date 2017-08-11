namespace Facturacion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifi : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        CategoriaId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CategoriaId);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Apellido = c.String(nullable: false),
                        Correo = c.String(nullable: false),
                        Direccion = c.String(maxLength: 100),
                        Telefono = c.String(),
                    })
                .PrimaryKey(t => t.ClienteId);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        UsuarioID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Apellido = c.String(nullable: false),
                        Correo = c.String(nullable: false),
                        UserName = c.String(nullable: false),
                        Contraseña = c.String(),
                        ConfirmarContraseña = c.String(),
                    })
                .PrimaryKey(t => t.UsuarioID);
            
            CreateTable(
                "dbo.Vendedores",
                c => new
                    {
                        VendedorID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Correo = c.String(nullable: false),
                        Direccion = c.String(maxLength: 100),
                        Telefono = c.String(),
                    })
                .PrimaryKey(t => t.VendedorID);
            
            CreateTable(
                "dbo.Ventas",
                c => new
                    {
                        VentaID = c.Int(nullable: false, identity: true),
                        DiaVenta = c.DateTime(nullable: false),
                        SubTotal = c.Single(nullable: false),
                        ITBIS = c.Single(nullable: false),
                        Total = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.VentaID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Ventas");
            DropTable("dbo.Vendedores");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Clientes");
            DropTable("dbo.Categorias");
        }
    }
}
