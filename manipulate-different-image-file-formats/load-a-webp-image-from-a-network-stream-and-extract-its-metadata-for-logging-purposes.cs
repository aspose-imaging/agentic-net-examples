// HOW-TO: Download WebP Image From URL and Log Metadata In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Net.Http;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input URL and temporary file paths
            string url = "https://example.com/sample.webp";
            string tempFilePath = "temp\\downloaded.webp";
            string logFilePath = "output\\metadata.txt";

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(tempFilePath));
            Directory.CreateDirectory(Path.GetDirectoryName(logFilePath));

            // Download the WebP image to a temporary file
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = client.GetAsync(url).Result)
            using (Stream downloadStream = response.Content.ReadAsStreamAsync().Result)
            using (FileStream fileStream = new FileStream(tempFilePath, FileMode.Create, FileAccess.Write))
            {
                downloadStream.CopyTo(fileStream);
            }

            // Verify the temporary file exists
            if (!File.Exists(tempFilePath))
            {
                Console.Error.WriteLine($"File not found: {tempFilePath}");
                return;
            }

            // Load the WebP image from the temporary file stream
            using (FileStream stream = File.OpenRead(tempFilePath))
            using (WebPImage webPImage = new WebPImage(stream))
            {
                // Extract metadata
                string fileFormat = webPImage.FileFormat.ToString();
                int width = webPImage.Width;
                int height = webPImage.Height;

                // Log metadata to console
                Console.WriteLine($"File Format: {fileFormat}");
                Console.WriteLine($"Dimensions: {width}x{height}");

                // Write metadata to a log file
                using (StreamWriter writer = new StreamWriter(logFilePath, false))
                {
                    writer.WriteLine($"File Format: {fileFormat}");
                    writer.WriteLine($"Dimensions: {width}x{height}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to record the format and dimensions of WebP images downloaded from external APIs for audit logs.
 * 2. When a media management system must verify that incoming WebP files meet size requirements before further processing.
 * 3. When you want to capture image metadata to populate a database of assets retrieved over HTTP.
 * 4. When debugging a web scraper that pulls WebP pictures and you need to confirm the files were downloaded correctly.
 * 5. When generating a summary report of image characteristics for a batch of WebP files fetched from remote servers.
 */
