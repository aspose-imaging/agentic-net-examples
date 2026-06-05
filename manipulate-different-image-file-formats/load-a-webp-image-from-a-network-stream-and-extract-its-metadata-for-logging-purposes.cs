using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static async Task Main()
    {
        try
        {
            // Hardcoded input URL and output file path
            string url = "https://example.com/sample.webp";
            string outputPath = @"C:\temp\output.png";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Download the WebP image as a stream
            using HttpClient client = new HttpClient();
            using Stream networkStream = await client.GetStreamAsync(url);

            // Load the WebP image from the network stream
            using WebPImage webPImage = new WebPImage(networkStream);

            // Extract and log metadata
            Console.WriteLine($"Width: {webPImage.Width}");
            Console.WriteLine($"Height: {webPImage.Height}");
            Console.WriteLine($"File format: {webPImage.FileFormat}");

            // Retrieve original options (contains metadata information)
            ImageOptionsBase originalOptions = webPImage.GetOriginalOptions();
            Console.WriteLine($"Original options type: {originalOptions.GetType().Name}");

            // Save a copy as PNG (optional demonstration)
            webPImage.Save(outputPath, new PngOptions());
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When building a web service that validates user‑uploaded WebP avatars, a developer can download the image via HttpClient, load it with Aspose.Imaging.WebPImage, and log its width, height, and format before accepting it.
 * 2. When generating an audit trail for a digital asset management system, the code can fetch remote WebP files, extract metadata such as dimensions and file format, and store the information in a database for compliance reporting.
 * 3. When monitoring a CDN’s image pipeline, a developer can periodically pull WebP images, read their original options via GetOriginalOptions, and log the metadata to detect unexpected changes in image quality or size.
 * 4. When creating a batch conversion tool that converts online WebP graphics to PNG for legacy applications, the snippet can retrieve the image stream, log its properties for troubleshooting, and then save a PNG copy using PngOptions.
 * 5. When implementing a health‑check endpoint that verifies external image URLs, the code can download each WebP image, extract and log its dimensions and format to ensure the resources are still accessible and correctly formatted.
 */