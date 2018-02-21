namespace Agenda.Pet.Dominio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TabelaServicos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Servicos",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        NomeServico = c.String(nullable: false, maxLength: 80),
                    })
                .PrimaryKey(t => t.Codigo);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Servicos");
        }
    }
}
