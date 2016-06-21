namespace SharpitterVS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AvatarUsuario : DbMigration
    {
        public override void Up()
        {
            AddColumn("wgbnc837_sharpitter.Sharpp", "UsuarioId", c => c.Int(nullable: false));
            AddColumn("wgbnc837_sharpitter.Usuario", "Avatar", c => c.String(nullable: false, maxLength: 512));
        }
        
        public override void Down()
        {
            DropColumn("wgbnc837_sharpitter.Usuario", "Avatar");
            DropColumn("wgbnc837_sharpitter.Sharpp", "UsuarioId");
        }
    }
}
