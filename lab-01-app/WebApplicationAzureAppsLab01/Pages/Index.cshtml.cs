using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyWebApplication.Pages
{
	public class IndexModel : PageModel
	{
		private readonly string ContainerEndpoint;

		public List<BlobItem>? Blobs { get; set; } = new();

		public string AzureKeyVaultSecret { get; set; }

		public IndexModel(IConfiguration configuration)
		{
			var storageName = configuration.GetValue<string>("AzureStorageName");
			var storageContainerName = configuration.GetValue<string>("AzureStorageContainerName");
			ContainerEndpoint = $"https://{storageName}.blob.core.windows.net/{storageContainerName}";
			AzureKeyVaultSecret = configuration["secretname"];
		}

		public void OnGet()
		{
			Blobs = CreateClient().GetBlobs().ToList();
		}

		public FileStreamResult OnGetDownloadBlob(string blobName)
		{
			var blobClient = CreateClient().GetBlobClient(blobName);
			var contentType = blobClient.GetProperties().Value.ContentType;
			var stream = blobClient.OpenRead();
			return new FileStreamResult(stream, contentType);
		}

		private BlobContainerClient CreateClient()
		{
			return new BlobContainerClient(new Uri(ContainerEndpoint), new Azure.Identity.DefaultAzureCredential());
		}
	}
}