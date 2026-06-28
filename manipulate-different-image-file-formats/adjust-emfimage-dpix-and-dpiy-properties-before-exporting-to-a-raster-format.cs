using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Png;

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
                EmfImage emfImage = (EmfImage)image;
                var pngOptions = new PngOptions();
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
 * 1. When a developer needs to convert a vector EMF logo to a PNG thumbnail for a web page and must set DpiX/DpiY to 72 to match typical screen resolution.
 * 2. When generating printable PDFs from EMF diagrams and the PNG raster must be exported at 300 DPI to preserve detail for high‑quality print.
 * 3. When creating image assets for a mobile app where the EMF icons are rasterized at 160 DPI to ensure consistent sizing across devices.
 * 4. When processing scanned engineering drawings stored as EMF and the raster PNG must be saved at 600 DPI to meet regulatory archival standards.
 * 5. When integrating with a third‑party imaging service that expects PNG files at a specific DPI (e.g., 96) and the developer must adjust EmfImage.DpiX and DpiY before saving.
 */