using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input\\sample.svg";
        string outputPath = "Output\\sample.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the SVG image and convert to BMP
        using (Image image = Image.Load(inputPath))
        {
            BmpOptions bmpOptions = new BmpOptions();
            image.Save(outputPath, bmpOptions);
        }

        // Placeholder: upload the BMP file to Azure Blob storage.
        // Azure Blob SDK is not part of the allowed namespaces, so implementation is omitted.
        // Example (requires Azure.Storage.Blobs):
        // var blobServiceClient = new BlobServiceClient(connectionString);
        // var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
        // var blobClient = containerClient.GetBlobClient(Path.GetFileName(outputPath));
        // using var stream = File.OpenRead(outputPath);
        // blobClient.Upload(stream, overwrite: true);
    }
}