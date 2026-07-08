using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Watermark;
using Aspose.Imaging.Watermark.Options;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hard‑coded input and output locations
            string inputPath = "input.png";
            string outputBasePath = "output";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the base output directory exists
            Directory.CreateDirectory(outputBasePath);

            // Load the source image
            using (var image = Image.Load(inputPath))
            {
                var raster = (RasterImage)image;

                // Define a simple elliptical mask
                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new EllipseShape(new RectangleF(100, 100, 200, 200)));
                mask.AddFigure(figure);

                // Demonstrate the effect of increasing MaxPaintingAttempts
                // Higher values let the algorithm try more painting variants,
                // which usually yields a smoother and more natural fill.
                for (int attempts = 1; attempts <= 5; attempts++)
                {
                    var options = new ContentAwareFillWatermarkOptions(mask)
                    {
                        MaxPaintingAttempts = attempts
                    };

                    // Perform watermark removal / content‑aware fill
                    using (var result = WatermarkRemover.PaintOver(raster, options))
                    {
                        string outputPath = Path.Combine(outputBasePath, $"result_{attempts}.png");

                        // Ensure the directory for this output exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the processed image
                        result.Save(outputPath);
                    }
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
 * 1. When a developer needs to remove a watermark from a PNG image and wants to see how raising MaxPaintingAttempts from 1 to 5 produces a smoother, more natural‑looking fill in the erased region.
 * 2. When a C# application must generate multiple versions of a JPEG thumbnail with varying MaxPaintingAttempts to evaluate the trade‑off between processing time and the visual continuity of the content‑aware fill.
 * 3. When an automated batch‑processing script uses Aspose.Imaging to clean scanned PDFs saved as PNGs and requires the highest MaxPaintingAttempts to avoid visible seams after the watermark is painted over.
 * 4. When a UI tool lets users adjust a slider that maps to MaxPaintingAttempts, enabling real‑time comparison of how higher attempts reduce pixelation in the filled ellipse mask on a BMP background.
 * 5. When performance testing a .NET service that removes watermarks from large TIFF files and needs to demonstrate that increasing MaxPaintingAttempts improves the smoothness of the reconstructed area without introducing artifacts.
 */