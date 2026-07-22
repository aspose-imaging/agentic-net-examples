using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;
using Aspose.Imaging.Watermark;
using Aspose.Imaging.Watermark.Options;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (null‑safe)
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
                Directory.CreateDirectory(outputDir);

            // Load the PNG image
            using (var image = Image.Load(inputPath))
            {
                var pngImage = (PngImage)image;

                // Define the mask region using a graphics path
                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new EllipseShape(new RectangleF(350, 170, 570 - 350, 400 - 170)));
                mask.AddFigure(figure);

                // Configure Telea options and enable smoother result via larger half‑patch size
                var options = new TeleaWatermarkOptions(mask)
                {
                    HalfPatchSize = 5 // larger patch size improves anti‑aliasing effect
                };

                // Perform watermark removal
                using (var result = WatermarkRemover.PaintOver(pngImage, options))
                {
                    // Save the processed image as PNG
                    result.Save(outputPath, new PngOptions());
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
 * 1. When a web application needs to automatically clean up user‑uploaded PNG logos that contain semi‑transparent watermarks, preserving smooth edges with anti‑aliasing.
 * 2. When a desktop utility processes scanned PNG documents to erase embedded stamps while keeping the original resolution and color fidelity.
 * 3. When an e‑commerce platform batch‑converts product images in PNG format, removing promotional watermarks without jagged artifacts for better display on high‑DPI screens.
 * 4. When a mobile app prepares PNG assets for AR overlays by stripping out placeholder watermarks and ensuring the resulting transparent regions blend seamlessly.
 * 5. When a digital archiving system restores archived PNG graphics by programmatically removing watermarks and applying a larger half‑patch size to achieve smoother visual results.
 */