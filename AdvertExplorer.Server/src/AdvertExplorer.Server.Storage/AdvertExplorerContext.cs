using AdvertExplorer.Server.Storage.DTO;
using Microsoft.EntityFrameworkCore;

namespace AdvertExplorer.Server.Storage
{
	internal sealed class AdvertExplorerContext : DbContext
	{
		public DbSet<ResumeDTO> Resumes { get; set; }
		public DbSet<QueryDTO> Queries { get; set; }
		
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite("Filename=AdvertExplorer.sqlite");
		}
	}
}