using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static async Task Main(string[] args)
    {
        // Hardcoded input (network URL) and output (metadata file) paths
        string url = "https://example.com/sample.webp";
        string outputPath = @"C:\temp\metadata.txt";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Download the WebP image as a stream
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            using var stream = await response.Content.ReadAsStreamAsync();

            // Load the WebP image from the stream
            using var webPImage = new WebPImage(stream);

            // Gather metadata
            var sb = new StringBuilder();
            sb.AppendLine($"File Format: {webPImage.FileFormat}");
            sb.AppendLine($"Dimensions: {webPImage.Width}x{webPImage.Height}");

            // Retrieve original options which may contain Exif and XMP data
            var originalOptions = webPImage.GetOriginalOptions() as WebPOptions;
            if (originalOptions != null)
            {
                if (originalOptions.ExifData != null)
                {
                    sb.AppendLine("Exif Data:");
                    sb.AppendLine(originalOptions.ExifData.ToString());
                }

                if (originalOptions.XmpData != null)
                {
                    sb.AppendLine("XMP Data:");
                    sb.AppendLine(originalOptions.XmpData.ToString());
                }
            }

            // Log metadata to console
            Console.WriteLine(sb.ToString());

            // Save metadata to a text file
            File.WriteAllText(outputPath, sb.ToString());
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}