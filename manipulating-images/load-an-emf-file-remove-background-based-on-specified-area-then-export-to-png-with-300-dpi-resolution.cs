using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.emf";
            string outputPath = "output.png";

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
                // Cast to EmfImage to access vector-specific methods
                EmfImage emf = image as EmfImage;
                if (emf != null)
                {
                    // Remove background (global operation)
                    emf.RemoveBackground();
                }

                // Configure PNG export options with 300 DPI resolution
                PngOptions pngOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new FileCreateSource(outputPath, false),
                    ResolutionSettings = new ResolutionSetting(300, 300)
                };

                // Save the processed image as PNG
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
 * 1. When a developer needs to convert legacy EMF vector graphics into high‑resolution PNGs for web publishing while stripping any unwanted background.
 * 2. When an application must generate print‑ready PNG assets at 300 DPI from EMF diagrams supplied by third‑party vendors.
 * 3. When a reporting tool has to embed clean, transparent PNG images derived from EMF charts into PDF or Word documents.
 * 4. When a batch‑processing service automates the removal of background layers from EMF icons before saving them as PNG thumbnails for a UI library.
 * 5. When a migration script updates an old Windows‑based graphics repository by converting EMF files to PNG with true‑color and alpha support for modern platforms.
 */