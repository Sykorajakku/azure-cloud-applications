using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyWebApplication.Pages
{
	public class IndexModel : PageModel
	{
		private readonly string AzureStorageConnectionString;
		private readonly string AzureStorageContainerName;

		public List<BlobItem>? Blobs { get; set; } = new();

		public IndexModel(IConfiguration configuration)
		{
			AzureStorageConnectionString = configuration.GetConnectionString("AzureStorageConnectionString");
			AzureStorageContainerName = configuration.GetValue<string>("AzureStorageContainerName");
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
			return new Azure.Storage.Blobs.BlobContainerClient(AzureStorageConnectionString, AzureStorageContainerName);
		}
	}
}