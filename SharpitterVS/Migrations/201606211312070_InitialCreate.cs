namespace SharpitterVS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "wgbnc837_sharpitter.Sharpp",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Autor = c.String(nullable: false, maxLength: 100, unicode: false),
                        Texto = c.String(nullable: false, maxLength: 160, unicode: false),
                        Registro = c.DateTime(nullable: false),
                        Like = c.Int(nullable: false),
                        Resposta = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "wgbnc837_sharpitter.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 200, unicode: false),
                        Email = c.String(nullable: false, maxLength: 200, unicode: false),
                        Username = c.String(nullable: false, maxLength: 100, unicode: false),
                        Senha = c.String(nullable: false, maxLength: 512, unicode: false),
                        Registro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("wgbnc837_sharpitter.Usuario");
            DropTable("wgbnc837_sharpitter.Sharpp");
        }
    }
}
