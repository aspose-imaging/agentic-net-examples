using System;
using System.IO;
using System.Net.Http;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        // Hardcoded input URL and output file path
        string url = "https://example.com/sample.webp";
        string outputPath = @"C:\temp\metadata.txt";

        try
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Download the WebP image as a stream
            using (HttpClient client = new HttpClient())
            using (Stream networkStream = client.GetStreamAsync(url).Result)
            // Load the WebP image from the network stream
            using (WebPImage webPImage = new WebPImage(networkStream))
            {
                // Extract basic metadata
                string fileFormat = webPImage.FileFormat.ToString();
                int width = webPImage.Width;
                int height = webPImage.Height;

                // Write metadata to the output file
                using (StreamWriter writer = new StreamWriter(outputPath))
                {
                    writer.WriteLine($"URL: {url}");
                    writer.WriteLine($"File Format: {fileFormat}");
                    writer.WriteLine($"Width: {width}");
                    writer.WriteLine($"Height: {height}");
                }

                Console.WriteLine("Metadata extracted and saved to: " + outputPath);
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
 * 1. When a web service must audit incoming WebP assets, a developer can download the image via HttpClient, load it with Aspose.Imaging’s WebPImage, and log its format, width, and height for compliance reporting.
 * 2. When building a CDN health‑check tool that validates image dimensions without fully decoding the file, the code can stream a remote WebP image and extract its metadata for quick verification.
 * 3. When integrating a digital asset management system that records source image properties, a developer can fetch a WebP file from a URL, read its metadata, and store the information in a database or log file.
 * 4. When creating a monitoring script that tracks changes in image size for SEO purposes, the code enables retrieval of a WebP image over the network and logging of its dimensions to detect unexpected alterations.
 * 5. When implementing a security audit that records file format details of externally hosted images, the developer can stream the WebP image, read its format and dimensions with Aspose.Imaging, and write the data to a secure log for later analysis.
 */