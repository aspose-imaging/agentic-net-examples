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
            // Hardcoded input and output paths
            string inputPath = "Input\\sample.emf";
            string outputPath = "Output\\sample.png";

            // Validate input file existence
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
                // Configure vector rasterization options for EMF to PNG conversion
                EmfRasterizationOptions vectorOptions = new EmfRasterizationOptions
                {
                    PageSize = image.Size // Preserve original size
                };

                // Set PNG export options, including DPI (ResolutionSettings)
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = vectorOptions,
                    ResolutionSettings = new ResolutionSetting(300, 300) // DPI X and Y
                };

                // Save the image as PNG with the specified options
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
 * 1. When a Windows desktop application needs to generate high‑resolution PNG thumbnails from vector‑based EMF icons for display on retina screens, a developer can use this code to rasterize the EMF at 300 DPI and save it as PNG.
 * 2. When a reporting service must embed vector graphics from legacy EMF files into PDF or web reports that only accept raster PNG images with a specific DPI, this snippet converts and resamples the EMF accordingly.
 * 3. When an automated build pipeline processes a batch of EMF logos and must output PNG assets with consistent 300 DPI resolution for print‑ready marketing materials, the code provides the necessary conversion.
 * 4. When a GIS mapping tool stores map symbols as EMF and needs to export them to PNG tiles at a defined DPI for use in web mapping services, this example shows how to perform the rasterization in C#.
 * 5. When a document conversion utility has to replace embedded EMF drawings with PNG images that preserve the original size and meet a required DPI for accessibility compliance, the developer can apply this code.
 */