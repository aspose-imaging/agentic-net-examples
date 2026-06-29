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
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.eps";
            string outputPath = @"C:\Images\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image
            using (Image image = Image.Load(inputPath))
            {
                // Save the loaded image as PNG
                image.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to convert vector EPS artwork into a raster PNG for web display using C# and Aspose.Imaging.
 * 2. When an automated batch job must read EPS files from a folder, validate their existence, and generate PNG thumbnails for a digital asset management system.
 * 3. When a Windows desktop application has to load an EPS logo, apply image processing, and save it as a PNG to embed in a PDF report.
 * 4. When a server‑side service processes user‑uploaded EPS files, loads them with Image.Load, and stores the resulting PNG in a cloud storage bucket.
 * 5. When a migration script reads legacy EPS graphics from a legacy file system and converts them to PNG format for compatibility with modern applications.
 */