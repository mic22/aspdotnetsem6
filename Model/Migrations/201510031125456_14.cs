namespace Model.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class _14 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Items", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Items", "Name", c => c.String(nullable: false));
        }
    }
}
