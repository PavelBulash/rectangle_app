using Bogus;
using Microsoft.EntityFrameworkCore;

public class RectangleContext : DbContext
{
	public RectangleContext(DbContextOptions<RectangleContext> options) : base(options)
	{
	}

	public DbSet<Rectangle> Rectangles { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		var rectangleFaker = new Faker<Rectangle>()
			.RuleFor(r => r.Id, f => f.IndexGlobal + 1)
			.RuleFor(r => r.X, f => f.Random.Number(0, 20))
			.RuleFor(r => r.Y, f => f.Random.Number(0, 20))
			.RuleFor(r => r.Width, f => f.Random.Number(1, 100))
			.RuleFor(r => r.Height, f => f.Random.Number(1, 100));

		modelBuilder.Entity<Rectangle>().HasData(rectangleFaker.Generate(200));
	}
}