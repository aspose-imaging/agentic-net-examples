using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = @"C:\temp\input.odg";
        string outputPath = @"C:\temp\output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                var pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to convert OpenDocument Graphics (ODG) diagrams into web‑friendly PNG images while programmatically adding a copyright watermark using Aspose.Imaging in a C# application.
 * 2. When an enterprise document‑management system must automatically generate preview thumbnails of ODG files with a confidential “Draft” text overlay before storing them as PNGs on a server.
 * 3. When a reporting tool has to export chart drawings created in ODG format to high‑resolution PNGs and embed a brand logo or watermark text for compliance purposes.
 * 4. When a batch‑processing service processes a folder of ODG assets, converts each to PNG, and applies a “Confidential” watermark to protect intellectual property before publishing to an intranet.
 * 5. When a Windows desktop utility needs to load an ODG file, convert it to PNG, and overlay dynamic watermark text (e.g., user name or timestamp) for audit‑trail documentation.
 */