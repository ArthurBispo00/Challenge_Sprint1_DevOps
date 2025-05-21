using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System; // Necess�rio para Console e Environment
using System.IO;

namespace ChallengeMuttuApi.Data // Namespace confirmado como correto
{
	public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
	{
		public AppDbContext CreateDbContext(string[] args)
		{
			// Adicionando todos os Console.WriteLine para depura��o
			Console.WriteLine("--- DesignTimeDbContextFactory: CreateDbContext INICIADO ---");

			string basePath = Directory.GetCurrentDirectory();
			Console.WriteLine($"DesignTimeDbContextFactory: BasePath atual (Directory.GetCurrentDirectory()): {basePath}");

			string appSettingsPath = Path.Combine(basePath, "appsettings.json");
			Console.WriteLine($"DesignTimeDbContextFactory: Caminho completo esperado para appsettings.json: {appSettingsPath}");

			if (!File.Exists(appSettingsPath))
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
				Console.WriteLine($"DesignTimeDbContextFactory: ERRO CR�TICO - appsettings.json N�O FOI ENCONTRADO em: {appSettingsPath}");
				Console.WriteLine("Verifique se o arquivo 'appsettings.json' existe neste local e se o comando 'dotnet ef' est� sendo executado no diret�rio raiz do projeto API.");
				Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
				Console.ResetColor();
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine($"DesignTimeDbContextFactory: OK - appsettings.json FOI ENCONTRADO em: {appSettingsPath}");
				Console.ResetColor();
			}

			IConfigurationRoot configuration = new ConfigurationBuilder()
				.SetBasePath(basePath)
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) // 'optional: false' garante que ele falhe se n�o encontrar
																						// .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development"}.json", optional: true) // Considerar Development por padr�o no design-time
				.AddEnvironmentVariables()
				.Build();

			var connectionString = configuration.GetConnectionString("OracleDb");

			if (string.IsNullOrEmpty(connectionString))
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
				Console.WriteLine("DesignTimeDbContextFactory: ERRO CR�TICO - String de conex�o 'OracleDb' N�O ENCONTRADA ou est� VAZIA no appsettings.json.");
				Console.WriteLine("Verifique o conte�do do seu appsettings.json e se a chave 'ConnectionStrings:OracleDb' existe e tem um valor.");
				Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
				Console.ResetColor();
				// Lan�ar a exce��o � importante para que o processo EF Core pare se a string n�o for encontrada.
				throw new InvalidOperationException($"A string de conex�o 'OracleDb' n�o foi encontrada ou est� vazia. Verifique o appsettings.json em '{appSettingsPath}'.");
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Green;
				// Cuidado ao logar strings de conex�o inteiras, especialmente se contiverem senhas. Mostrando apenas uma parte.
				Console.WriteLine($"DesignTimeDbContextFactory: OK - String de conex�o 'OracleDb' ENCONTRADA. In�cio: {connectionString.Substring(0, Math.Min(connectionString.Length, 70))}...");
				Console.ResetColor();
			}

			var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
			optionsBuilder.UseOracle(connectionString);

			Console.WriteLine("DesignTimeDbContextFactory: Op��es do DbContext configuradas com UseOracle.");
			Console.WriteLine("--- DesignTimeDbContextFactory: Inst�ncia de AppDbContext ser� retornada. FIM ---");
			return new AppDbContext(optionsBuilder.Options);
		}
	}
}