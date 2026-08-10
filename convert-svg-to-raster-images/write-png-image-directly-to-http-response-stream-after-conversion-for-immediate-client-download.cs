// HOW-TO: Convert JPEG to PNG and Stream to HTTP Response in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.jpg";
            string outputPath = "output.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir);

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PNG save options
                PngOptions pngOptions = new PngOptions();

                // Simulated HTTP response stream (replace with actual response stream in real scenario)
                using (Stream responseStream = new MemoryStream())
                {
                    // Save the image as PNG directly to the stream
                    image.Save(responseStream, pngOptions);

                    // Example: write the stream to a file for verification (optional)
                    responseStream.Position = 0;
                    using (FileStream file = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                    {
                        responseStream.CopyTo(file);
                    }
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
 * 1. When a web application needs to let users download a resized JPEG as a PNG file without storing the converted image on the server.
 * 2. When an ASP.NET API must return dynamically generated PNG thumbnails from uploaded JPEG photos directly to the client’s browser.
 * 3. When a cloud service streams converted PNG images over HTTP to mobile apps to reduce bandwidth and improve load times.
 * 4. When a server‑side script creates on‑the‑fly PNG versions of user‑submitted JPEGs for instant preview in a single HTTP response.
 * 5. When an e‑commerce platform delivers product images in PNG format for transparent backgrounds by converting JPEGs and streaming them to the shopper’s request.
 */
