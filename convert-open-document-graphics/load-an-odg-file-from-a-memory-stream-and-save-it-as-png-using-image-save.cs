// HOW-TO: Convert ODG File to PNG from Memory Stream in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.odg";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (string.IsNullOrEmpty(outputDir))
            {
                outputDir = ".";
            }
            Directory.CreateDirectory(outputDir);

            byte[] fileBytes = File.ReadAllBytes(inputPath);
            using (var memoryStream = new MemoryStream(fileBytes))
            {
                using (var image = Image.Load(memoryStream))
                {
                    var pngOptions = new PngOptions();
                    image.Save(outputPath, pngOptions);
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
 * 1. When a desktop application needs to display OpenDocument graphics as PNG thumbnails without writing temporary files to disk.
 * 2. When a web service receives an ODG file as a byte array and must return a PNG image to the client.
 * 3. When a batch job processes a large collection of ODG drawings stored in a database and saves them as PNGs for reporting.
 * 4. When an automated testing framework validates the visual output of ODG files by converting them to PNG for pixel‑by‑pixel comparison.
 * 5. When a mobile backend converts user‑uploaded ODG diagrams into PNG format for faster loading in mobile apps.
 */
