using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebJobExample
{
	class Program
	{
		static async Task Main(string[] args)
		{
			// Setup Host
			var host = Host.CreateDefaultBuilder()
				.ConfigureAppConfiguration(app =>
				{
					app.AddEnvironmentVariables();
				})
				.ConfigureServices(services =>
				{
					services.AddHostedService<Worker>();
				})
				.Build();

			await host.RunAsync();
		}
	}


	public class Worker : IHostedService, IDisposable
	{
		private PeriodicTimer? timer;
		private readonly IConfiguration configuration;

		public Worker(IConfiguration configuration)
		{
			this.configuration = configuration;
		}

		public async Task StartAsync(CancellationToken stoppingToken)
		{
			Console.WriteLine("Worker started...");

			timer = new PeriodicTimer(TimeSpan.FromSeconds(10));

			do
			{
				await WriteLineNewTableEntries(stoppingToken);

				Console.WriteLine("Waiting for next tick...");
			}
			while (await timer.WaitForNextTickAsync(stoppingToken));
		}

		private async Task WriteLineNewTableEntries(CancellationToken stoppingToken)
		{
			Console.WriteLine("Checking for new records to be written...");

			using var conn = new SqlConnection(configuration.GetConnectionString("MyDatabase"));
			await conn.OpenAsync(stoppingToken);

			var cmd = new SqlCommand("SELECT * FROM Queue WHERE Sent IS NULL", conn);

			using var reader = await cmd.ExecuteReaderAsync(stoppingToken);

			while (await reader.ReadAsync(stoppingToken))
			{
				Console.WriteLine($"Message ID:{reader["ID"]} found...");
				string id = reader["ID"].ToString() ?? string.Empty;
				string message = reader["Message"].ToString() ?? string.Empty;
				await WriteMessageAsync("", message, stoppingToken);
			}
		}

		private async Task WriteMessageAsync(string id, string message, CancellationToken stoppingToken)
		{
			Console.WriteLine($"{configuration.GetValue<string>("Writer:Prefix")} {id}: {message}");

			using var conn = new SqlConnection(configuration.GetConnectionString("MyDatabase"));
			await conn.OpenAsync(stoppingToken);
			var cmd = new SqlCommand("UPDATE Queue SET Sent = GETDATE()  WHERE Id = @ID", conn);
			cmd.Parameters.AddWithValue("@Id", id);
			await cmd.ExecuteNonQueryAsync();
		}

		public Task StopAsync(CancellationToken stoppingToken)
		{
			return Task.CompletedTask;
		}

		public void Dispose()
		{
			timer?.Dispose();
		}
	}
}

