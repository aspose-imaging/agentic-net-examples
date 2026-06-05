using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.emf";
        string outputPath = @"C:\Images\output.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (unconditional as per requirements)
            string outputDir = Path.GetDirectoryName(outputPath) ?? ".";
            Directory.CreateDirectory(outputDir);

            // Load the EMF image
            using (Image emfImage = Image.Load(inputPath))
            {
                // Prepare rasterization options for EMF to bitmap conversion
                var rasterizationOptions = new EmfRasterizationOptions
                {
                    // Use the original image size for the bitmap
                    PageSize = emfImage.Size,
                    // Optional: set background color if needed
                    BackgroundColor = Color.White
                };

                // Configure PNG save options with the rasterization settings
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save the rendered bitmap as PNG
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
 * 1. When a Windows desktop application needs to display legacy EMF vector graphics on a web page, a developer can render the EMF to a bitmap and save it as a PNG for browser compatibility.
 * 2. When generating automated reports that embed EMF charts, a developer can convert the EMF to a PNG image to ensure consistent rendering across PDF and email clients.
 * 3. When migrating a legacy document management system that stores drawings as EMF files, a developer can batch‑process the files into PNG thumbnails for quick preview in a web UI.
 * 4. When a C# service receives user‑uploaded EMF logos and must store them in a size‑optimized raster format, the code can rasterize the EMF and save it as a PNG with a white background.
 * 5. When creating a cross‑platform mobile app that cannot render EMF natively, a developer can pre‑convert the EMF assets to PNG using Aspose.Imaging so the images display correctly on iOS and Android devices.
 */