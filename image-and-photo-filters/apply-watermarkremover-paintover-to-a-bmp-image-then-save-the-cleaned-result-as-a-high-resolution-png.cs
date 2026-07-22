using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.bmp";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        string outputDir = Path.GetDirectoryName(outputPath);
        if (!string.IsNullOrEmpty(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        try
        {
            using (var image = Image.Load(inputPath))
            {
                // Cast loaded image to RasterImage for watermark removal
                var raster = (RasterImage)image;

                // Define mask area using an ellipse shape
                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new EllipseShape(new RectangleF(50, 50, 200, 200)));
                mask.AddFigure(figure);

                // Use Telea algorithm for watermark removal
                var options = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);

                // Perform watermark removal
                using (var result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(raster, options))
                {
                    // Configure high‑resolution PNG output (e.g., 300 DPI)
                    var pngOptions = new PngOptions
                    {
                        ResolutionSettings = new ResolutionSetting(300, 300)
                    };

                    // Save the cleaned image as PNG
                    result.Save(outputPath, pngOptions);
                }
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
 * 1. When a developer needs to clean scanned documents that contain a semi‑transparent logo watermark in a BMP file before archiving them as high‑resolution PNGs for print‑ready PDFs.
 * 2. When an e‑commerce platform must remove promotional watermarks from product photos stored as BMPs and output crisp 300 DPI PNG images for catalog listings.
 * 3. When a medical imaging system receives BMP scans with embedded patient‑ID watermarks that must be erased and saved as high‑resolution PNGs for diagnostic analysis.
 * 4. When a GIS application processes BMP satellite tiles with copyright watermarks, using PaintOver to restore the terrain data and exporting the result as a 300 DPI PNG for mapping overlays.
 * 5. When a digital archivist wants to batch‑process historical BMP scans containing watermarks, applying the Telea algorithm to clean them and storing the final images as high‑resolution PNGs for preservation.
 */