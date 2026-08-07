using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.emf";
            string outputPath = @"C:\Images\output.png";

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
                EmfImage emfImage = image as EmfImage;
                if (emfImage == null)
                {
                    Console.Error.WriteLine("The loaded file is not a valid EMF image.");
                    return;
                }

                // Configure rasterization with a semi‑transparent background (80% opacity)
                var rasterOptions = new EmfRasterizationOptions
                {
                    PageSize = emfImage.Size,
                    BackgroundColor = Aspose.Imaging.Color.FromArgb(204, 255, 255, 255) // 80% opacity
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save as PNG
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
 * 1. When converting legacy EMF diagrams to web‑friendly PNGs with 80% line opacity so they can be overlaid on modern UI components.
 * 2. When generating printable reports that embed EMF charts but require the lines to appear lighter in the final PNG export.
 * 3. When creating thumbnail previews of EMF icons where reduced opacity improves visibility against varied background colors.
 * 4. When migrating Windows Metafile assets to a cross‑platform .NET application that needs PNG images with partially transparent strokes.
 * 5. When automating a batch process that reads EMF logos, applies 80% line opacity to match brand guidelines, and saves them as PNG for marketing materials.
 */