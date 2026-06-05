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

            // Load EMF image
            using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
            {
                // Configure rasterization options for PNG export
                var rasterOptions = new EmfRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.White,
                    PageSize = emfImage.Size
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
 * 1. When generating printable PDFs from EMF logos, a developer may set DpiX and DpiY to 300 to ensure the PNG export has sufficient resolution for high‑quality print.
 * 2. When converting EMF schematics to thumbnails for a web gallery, a developer can lower DpiX and DpiY to 72 to reduce file size while maintaining aspect ratio.
 * 3. When integrating EMF‑based charts into a Windows Forms dashboard that displays on high‑DPI monitors, a developer adjusts DpiX and DpiY to match the screen scaling (e.g., 144 DPI) before saving as PNG.
 * 4. When preparing EMF drawings for OCR processing, a developer increases DpiX and DpiY to 600 so the rasterized PNG contains enough detail for accurate text recognition.
 * 5. When exporting EMF maps to PNG for GIS applications that require a specific ground resolution, a developer sets DpiX and DpiY to the map’s scale factor to align pixel dimensions with real‑world distances.
 */