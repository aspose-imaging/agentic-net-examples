// HOW-TO: Convert JPEG to PNG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Image image = Image.Load(inputPath))
            {
                Source source = new FileCreateSource(outputPath, false);
                PngOptions options = new PngOptions { Source = source };
                image.Save(outputPath, options);
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
 * 1. When a web application must serve transparent images, a developer can convert uploaded JPEG photos to PNG format with Aspose.Imaging in C#.
 * 2. When generating thumbnails for a mobile app, converting high‑resolution JPEGs to lossless PNGs ensures consistent quality across devices.
 * 3. When archiving product photos in a catalog, a developer may need to change JPEG files to PNG to preserve exact colors and support alpha channels.
 * 4. When integrating with a third‑party API that only accepts PNG, converting incoming JPEG images using Aspose.Imaging simplifies the workflow.
 * 5. When preparing images for PDF generation, converting JPEGs to PNG in C# avoids compression artifacts and maintains crisp vector‑compatible output.
 */
