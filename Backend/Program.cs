namespace Backend;

public static class Program
{
	#if DEBUG
	public static readonly string ProjectRoot = Environment.CurrentDirectory;
	#elif RELEASE
	public const string ProjectRoot = "/app";
	#endif

	public static Config Config { get; private set; } = Config.FromJson();

	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		builder.Services.AddCors(options =>
		{
			options.AddPolicy("AllowAll",
			policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
		});

		builder.WebHost.ConfigureKestrel(options =>
		{
			options.Listen(IPAddress.Any, 5000);
		});

		builder.Services.AddControllers();
		var app = builder.Build();

		app.UseCors("AllowAll");
		app.UseAuthorization();
		app.MapControllers();
		app.Run();
	}
}