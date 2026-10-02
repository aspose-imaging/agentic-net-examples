// HOW-TO: Export EMF to PNG with Custom DPI Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/input.emf";
        string outputPath = "Output/output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                PngOptions options = new PngOptions
                {
                    ResolutionSettings = new ResolutionSetting(300, 300) // DPI X, DPI Y
                };
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
 * 1. When you need to convert vector EMF diagrams into high‑resolution PNG files for web publishing while preserving a specific DPI.
 * 2. When generating printable assets from EMF logos and require the PNG output to match the printer’s 300 DPI setting.
 * 3. When automating a batch process that extracts EMF icons from legacy documents and saves them as PNG thumbnails with consistent resolution.
 * 4. When integrating Aspose.Imaging into a C# application to resize EMF charts for inclusion in PDF reports that demand a defined DPI.
 * 5. When creating a CI/CD pipeline that validates that all exported PNG images from EMF sources meet the required DPI standards for quality control.
 */
