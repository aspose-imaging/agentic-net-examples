using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.emf";
        string outputPath = @"C:\Images\output.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the EMF image
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options.
                // The BackgroundColor is set with an alpha of 204 (80% opacity) to affect overall rendering.
                var rasterOptions = new EmfRasterizationOptions
                {
                    PageSize = image.Size,
                    BackgroundColor = Aspose.Imaging.Color.FromArgb(204, 255, 255, 255) // 80% opacity white
                };

                // Set PNG save options with the rasterization settings
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the rasterized image as PNG
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
 * 1. When a developer needs to convert legacy Windows Metafile (EMF) graphics into web‑friendly PNG images while applying a semi‑transparent background for overlay effects.
 * 2. When an application must generate printable reports that embed vector EMF logos but require the final output as PNG with 80 % line opacity to blend with document backgrounds.
 * 3. When a desktop tool automates batch processing of EMF icons, adjusting their opacity to 80 % before saving them as PNG files for use in UI themes.
 * 4. When a GIS system exports map symbols stored as EMF and needs to rasterize them with a partially transparent background for overlay on satellite imagery in PNG format.
 * 5. When a document management workflow imports EMF diagrams and needs to create PNG previews with reduced line opacity to indicate draft status.
 */