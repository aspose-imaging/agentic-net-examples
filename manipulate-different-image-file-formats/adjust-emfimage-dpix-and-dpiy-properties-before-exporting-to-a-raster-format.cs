using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.emf";
            string outputPath = "Output\\sample.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                EmfImage emfImage = (EmfImage)image;

                using (PngOptions pngOptions = new PngOptions())
                {
                    var rasterOptions = new EmfRasterizationOptions
                    {
                        BackgroundColor = Aspose.Imaging.Color.White,
                        PageSize = emfImage.Size
                    };
                    pngOptions.VectorRasterizationOptions = rasterOptions;

                    emfImage.Save(outputPath, pngOptions);
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
 * 1. When a developer must convert a high‑resolution EMF logo to a PNG thumbnail that matches a specific print DPI, they adjust EmfImage.DpiX/DpiY before rasterization.
 * 2. When an application generates PDF reports containing EMF charts that need to be exported as PNG images for web preview at a consistent screen DPI, the DPI properties are set prior to saving.
 * 3. When a CAD system exports vector drawings in EMF format and the downstream system requires raster images at 300 DPI for quality control, the code modifies DpiX/DpiY before conversion.
 * 4. When a mobile app downloads EMF icons and needs to downscale them to 72 DPI PNG assets to reduce memory usage, the developer changes the DPI settings before rasterizing.
 * 5. When a batch processing script standardizes the DPI of multiple EMF files to 96 DPI so that all resulting PNG files align with the UI design grid, the DpiX/DpiY properties are adjusted before export.
 */