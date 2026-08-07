using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        try
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

            // Load the EMF image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare rasterization options for vector to bitmap conversion
                var rasterizationOptions = new EmfRasterizationOptions
                {
                    PageSize = image.Size // Use the original image size
                };

                // Prepare PNG save options and attach rasterization settings
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save the rendered bitmap as PNG
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
 * 1. When a developer needs to convert legacy Windows Metafile (EMF) graphics into web‑friendly PNG images for display in browsers.
 * 2. When an automated reporting tool must embed vector charts stored as EMF into PDF or HTML reports that only accept raster PNG files.
 * 3. When a desktop application generates printable diagrams as EMF and then creates thumbnail previews in PNG for file explorers or UI galleries.
 * 4. When a batch processing script has to migrate a folder of EMF assets to PNG to reduce file size and improve compatibility with mobile devices.
 * 5. When a cloud service receives user‑uploaded EMF logos and must rasterize them to PNG before storing them in an image CDN.
 */