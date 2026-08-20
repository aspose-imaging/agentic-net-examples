// HOW-TO: Overlay PNG on SVG Converted to PNG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string svgPath = @"C:\Images\input.svg";
            string overlayPath = @"C:\Images\overlay.png";
            string outputPath = @"C:\Images\output.png";
            string tempPngPath = Path.Combine(Path.GetTempPath(), "temp_svg.png");

            // Validate input files
            if (!File.Exists(svgPath))
            {
                Console.Error.WriteLine($"File not found: {svgPath}");
                return;
            }
            if (!File.Exists(overlayPath))
            {
                Console.Error.WriteLine($"File not found: {overlayPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Rasterize SVG to a temporary PNG file
            using (Image svgImage = Image.Load(svgPath))
            {
                var rasterOptions = new SvgRasterizationOptions { PageSize = svgImage.Size };
                var pngOptions = new PngOptions { VectorRasterizationOptions = rasterOptions };
                svgImage.Save(tempPngPath, pngOptions);
            }

            // Load the rasterized SVG and the overlay image
            using (RasterImage baseImage = (RasterImage)Image.Load(tempPngPath))
            using (RasterImage overlayImage = (RasterImage)Image.Load(overlayPath))
            {
                // Create output canvas bound to the output file
                Source outSource = new FileCreateSource(outputPath, false);
                var canvasOptions = new PngOptions { Source = outSource };
                using (RasterImage canvas = (RasterImage)Image.Create(canvasOptions, baseImage.Width, baseImage.Height))
                {
                    // Draw base image onto canvas
                    canvas.SaveArgb32Pixels(
                        new Rectangle(0, 0, baseImage.Width, baseImage.Height),
                        baseImage.LoadArgb32Pixels(baseImage.Bounds));

                    // Overlay the second image at position (0,0) – adjust as needed
                    canvas.SaveArgb32Pixels(
                        new Rectangle(0, 0, overlayImage.Width, overlayImage.Height),
                        overlayImage.LoadArgb32Pixels(overlayImage.Bounds));

                    // Save the bound canvas
                    canvas.Save();
                }
            }

            // Clean up temporary file
            if (File.Exists(tempPngPath))
            {
                try { File.Delete(tempPngPath); } catch { /* ignore cleanup errors */ }
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
 * 1. When you need to combine a vector logo (SVG) with a watermark PNG to produce a single PNG for web publishing.
 * 2. When generating product thumbnails by rendering an SVG diagram and adding a promotional badge PNG on top.
 * 3. When creating printable flyers where the base artwork is an SVG and a logo PNG must be overlaid before saving as PNG.
 * 4. When automating batch processing that converts multiple SVG icons to PNG and applies a company‑branded overlay image.
 * 5. When building a C# service that merges a dynamically generated SVG chart with a static PNG background for dashboard images.
 */
