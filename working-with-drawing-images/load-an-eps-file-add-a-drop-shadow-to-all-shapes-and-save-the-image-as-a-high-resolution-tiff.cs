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
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

            using (Image image = Image.Load(inputPath))
            {
                var options = new PngOptions();
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
 * 1. When a developer uses Aspose.Imaging for .NET to convert vector EPS artwork into a print‑ready high‑resolution TIFF while applying a consistent drop‑shadow effect to every shape for enhanced depth in marketing brochures.
 * 2. When an e‑commerce platform must generate catalog images from designer‑provided EPS logos, automatically adding drop shadows to all vector elements with Aspose.Imaging and exporting them as 300 dpi TIFF files for high‑quality product listings.
 * 3. When a publishing workflow requires batch processing of EPS illustrations, using Aspose.Imaging to add a uniform drop shadow to each shape and saving the result as a lossless high‑resolution TIFF to meet the printer’s color‑management specifications.
 * 4. When a desktop C# application needs to preview EPS diagrams with a subtle shadow effect and then export the view as a high‑resolution TIFF for archival or compliance documentation using Aspose.Imaging.
 * 5. When a GIS system imports EPS map symbols, applies a drop‑shadow via Aspose.Imaging to improve visual separation on layered maps, and stores the final map tiles as high‑resolution TIFF images for analysis.
 */