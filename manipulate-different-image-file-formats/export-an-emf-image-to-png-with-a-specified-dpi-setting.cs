using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.emf";
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
                var pngOptions = new PngOptions
                {
                    ResolutionSettings = new ResolutionSetting(300, 300)
                };

                var rasterOptions = new EmfRasterizationOptions
                {
                    PageSize = image.Size
                };

                pngOptions.VectorRasterizationOptions = rasterOptions;

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
 * 1. When a developer needs to convert a vector‑based EMF logo into a high‑resolution PNG for web display, preserving sharpness at 300 DPI.
 * 2. When an application must generate printable PNG thumbnails from EMF diagrams for inclusion in PDF reports that require a specific DPI setting.
 * 3. When a Windows desktop tool automates batch processing of EMF icons into PNG assets for mobile apps, ensuring consistent resolution across devices.
 * 4. When a document management system extracts embedded EMF charts and saves them as PNG images with 300 DPI to meet corporate printing standards.
 * 5. When a C# service receives user‑uploaded EMF files and needs to rasterize them to PNG with a defined DPI for storage in a cloud image repository.
 */