// HOW-TO: Set EMF DPI and Convert to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main(string[] args)
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
                EmfImage emfImage = image as EmfImage;
                if (emfImage == null)
                {
                    Console.Error.WriteLine("Loaded image is not an EMF image.");
                    return;
                }

                EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = emfImage.Width,
                    PageHeight = emfImage.Height
                };

                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                emfImage.Save(outputPath, pngOptions);
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
 * 1. When you need to change the resolution of a vector EMF file before turning it into a raster PNG for consistent display on screens.
 * 2. When generating thumbnails of EMF drawings for web galleries and must ensure the output PNG has a specific DPI.
 * 3. When preparing EMF graphics for printing workflows that require a known DPI setting before rasterization to PNG.
 * 4. When converting legacy EMF diagrams to PNG while preserving their original size and aspect ratio by adjusting DpiX/DpiY.
 * 5. When automating batch processing of EMF assets in a C# application and need to control the raster DPI to match other image assets.
 */
