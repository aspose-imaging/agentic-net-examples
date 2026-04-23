using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/input.svg";
        string outputPath = "Output/output.bmp";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load SVG image and convert to BMP
        using (Image image = Image.Load(inputPath))
        {
            var bmpOptions = new BmpOptions();
            image.Save(outputPath, bmpOptions);
        }

        // Read the generated BMP file into a byte array
        byte[] bmpBytes = File.ReadAllBytes(outputPath);

        // Azure Blob Storage URL with SAS token (replace with actual URL)
        string blobUrl = "https://myaccount.blob.core.windows.net/container/output.bmp?sv=YOUR_SAS_TOKEN";

        // Upload BMP to Azure Blob using HttpClient
        using (var httpClient = new System.Net.Http.HttpClient())
        {
            var content = new System.Net.Http.ByteArrayContent(bmpBytes);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/bmp");

            var response = httpClient.PutAsync(blobUrl, content).Result;

            if (!response.IsSuccessStatusCode)
            {
                Console.Error.WriteLine($"Failed to upload to Azure Blob. Status: {response.StatusCode}");
                return;
            }

            Console.WriteLine("Upload successful.");
        }
    }
}