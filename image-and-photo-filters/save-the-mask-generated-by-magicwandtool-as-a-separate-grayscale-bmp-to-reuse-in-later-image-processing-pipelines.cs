// HOW-TO: Convert JPEG to PNG with Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.jpg";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
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
 * 1. When you need to preserve transparency while converting a photographic JPEG to a loss‑less PNG for web display.
 * 2. When an automated batch process must change image format from JPEG to PNG before uploading to a content management system.
 * 3. When you want to reduce file size by re‑encoding a JPEG as PNG with Aspose.Imaging’s built‑in options.
 * 4. When a desktop application requires PNG output for further editing or annotation after loading a JPEG source.
 * 5. When integrating image conversion into a C# service that validates the source file exists and creates the target folder automatically.
 */
