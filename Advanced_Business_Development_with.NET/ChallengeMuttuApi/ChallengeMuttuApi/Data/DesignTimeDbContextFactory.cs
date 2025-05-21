using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System; // Necessário para Console e Environment
using System.IO;

namespace ChallengeMuttuApi.Data // Namespace confirmado como correto
{
	public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
	{
		public AppDbContext CreateDbContext(string[] args)
		{
			// Adicionando todos os Console.WriteLine para depuração
			Console.WriteLine("--- DesignTimeDbContextFactory: CreateDbContext INICIADO ---");

			string basePath = Directory.GetCurrentDirectory();
			Console.WriteLine($"DesignTimeDbContextFactory: BasePath atual (Directory.GetCurrentDirectory()): {basePath}");

			string appSettingsPath = Path.Combine(basePath, "appsettings.json");
			Console.WriteLine($"DesignTimeDbContextFactory: Caminho completo esperado para appsettings.json: {appSettingsPath}");

			if (!File.Exists(appSettingsPath))
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
				Console.WriteLine($"DesignTimeDbContextFactory: ERRO CRÍTICO - appsettings.json NÃO FOI ENCONTRADO em: {appSettingsPath}");
				Console.WriteLine("Verifique se o arquivo 'appsettings.json' existe neste local e se o comando 'dotnet ef' está sendo executado no diretório raiz do projeto API.");
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
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) // 'optional: false' garante que ele falhe se não encontrar
																						// .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development"}.json", optional: true) // Considerar Development por padrão no design-time
				.AddEnvironmentVariables()
				.Build();

			var connectionString = configuration.GetConnectionString("OracleDb");

			if (string.IsNullOrEmpty(connectionString))
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
				Console.WriteLine("DesignTimeDbContextFactory: ERRO CRÍTICO - String de conexão 'OracleDb' NÃO ENCONTRADA ou está VAZIA no appsettings.json.");
				Console.WriteLine("Verifique o conteúdo do seu appsettings.json e se a chave 'ConnectionStrings:OracleDb' existe e tem um valor.");
				Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
				Console.ResetColor();
				// Lançar a exceção é importante para que o processo EF Core pare se a string não for encontrada.
				throw new InvalidOperationException($"A string de conexão 'OracleDb' não foi encontrada ou está vazia. Verifique o appsettings.json em '{appSettingsPath}'.");
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Green;
				// Cuidado ao logar strings de conexão inteiras, especialmente se contiverem senhas. Mostrando apenas uma parte.
				Console.WriteLine($"DesignTimeDbContextFactory: OK - String de conexão 'OracleDb' ENCONTRADA. Início: {connectionString.Substring(0, Math.Min(connectionString.Length, 70))}...");
				Console.ResetColor();
			}

			var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
			optionsBuilder.UseOracle(connectionString);

			Console.WriteLine("DesignTimeDbContextFactory: Opções do DbContext configuradas com UseOracle.");
			Console.WriteLine("--- DesignTimeDbContextFactory: Instância de AppDbContext será retornada. FIM ---");
			return new AppDbContext(optionsBuilder.Options);
		}
	}
}