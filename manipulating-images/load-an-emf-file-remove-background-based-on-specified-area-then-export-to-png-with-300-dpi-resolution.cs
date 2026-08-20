// HOW-TO: Remove Background from EMF and Export to 300 DPI PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.emf";
            string outputPath = "output/output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to VectorImage and remove background if possible
                if (image is VectorImage vectorImage)
                {
                    vectorImage.RemoveBackground(new RemoveBackgroundSettings());
                }

                // Configure PNG export options with 300 DPI resolution
                var pngOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    ResolutionSettings = new ResolutionSetting(300, 300),
                    Source = new FileCreateSource(outputPath, false)
                };

                // Save the result as PNG
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
 * 1. When you need to convert vector EMF drawings to high‑resolution PNGs for web publishing while stripping unwanted background layers.
 * 2. When generating printable assets from legacy EMF logos and require a 300 DPI PNG with transparent background for design tools.
 * 3. When automating batch processing of EMF diagrams to produce DPI‑specific PNG thumbnails without background artifacts.
 * 4. When integrating a C# service that receives EMF files from users and must deliver clean PNG images for mobile apps.
 * 5. When preparing EMF‑based technical schematics for inclusion in PDF reports and need lossless PNG output at print‑ready resolution.
 */
