// HOW-TO: Remove Watermark From BMP And Save As High Resolution PNG In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "output.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load BMP image
            using (BmpImage bmp = (BmpImage)Image.Load(inputPath))
            {
                // Create mask for watermark removal
                var mask = new GraphicsPath();
                var figure = new Figure();
                // Example ellipse mask; adjust coordinates as needed
                figure.AddShape(new EllipseShape(new RectangleF(50, 50, 200, 150)));
                mask.AddFigure(figure);

                // Configure Telea algorithm options
                var options = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);

                // Remove watermark
                var result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(bmp, options);
                using (result)
                {
                    // Set high‑resolution PNG options (e.g., 300 DPI)
                    var pngOptions = new PngOptions
                    {
                        ResolutionSettings = new Aspose.Imaging.ResolutionSetting(300, 300)
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
 * 1. When you need to clean a scanned document that has a logo watermark and deliver it as a printable PNG.
 * 2. When an application must automatically strip watermarks from user‑uploaded BMP photos before storing them in a high‑resolution PNG archive.
 * 3. When a batch process converts legacy BMP assets with embedded watermarks into DPI‑aware PNGs for publishing.
 * 4. When a web service removes branding from product images and returns a 300 DPI PNG for e‑commerce platforms.
 * 5. When a desktop tool prepares watermark‑free PNGs for OCR engines that require high‑resolution input.
 */
