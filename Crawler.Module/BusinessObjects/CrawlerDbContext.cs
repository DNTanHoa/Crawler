using System;
using DevExpress.ExpressApp.EFCore.Updating;
using Microsoft.EntityFrameworkCore;
using DevExpress.Persistent.BaseImpl.EF.PermissionPolicy;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.ExpressApp.Design;
using DevExpress.ExpressApp.EFCore.DesignTime;

namespace Crawler.Module.BusinessObjects {
    // This code allows our Model Editor to get relevant EF Core metadata at design time.
    // For details, please refer to https://supportcenter.devexpress.com/internal/ticket/details/t933891.
	public class CrawlerContextInitializer : DbContextTypesInfoInitializerBase {
		protected override DbContext CreateDbContext() {
			var builder = new DbContextOptionsBuilder<CrawlerEFCoreDbContext>()
                .UseSqlServer(@";");
            return new CrawlerEFCoreDbContext(builder.Options);
		}
	}
	[TypesInfoInitializer(typeof(CrawlerContextInitializer))]
	public class CrawlerEFCoreDbContext : DbContext {
		public CrawlerEFCoreDbContext(DbContextOptions<CrawlerEFCoreDbContext> options) : base(options) {
		}
		public DbSet<ModuleInfo> ModulesInfo { get; set; }
		public DbSet<ModelDifference> ModelDifferences { get; set; }
		public DbSet<ModelDifferenceAspect> ModelDifferenceAspects { get; set; }
	    public DbSet<PermissionPolicyRole> Roles { get; set; }
		public DbSet<PermissionPolicyUser> Users { get; set; }
		public DbSet<FileData> FileData { get; set; }
		public DbSet<ReportDataV2> ReportDataV2 { get; set; }
	}
}
