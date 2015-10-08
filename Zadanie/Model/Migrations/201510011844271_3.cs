namespace Model.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "Name", c => c.String());
            AlterColumn("dbo.Items", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Items", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false));
        }
    }
}
