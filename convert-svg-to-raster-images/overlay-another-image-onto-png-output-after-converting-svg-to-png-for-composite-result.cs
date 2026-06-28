using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string svgPath = "input.svg";
        string overlayPath = "overlay.png";
        string tempPngPath = "temp_converted.png";
        string outputPath = "output.png";

        try
        {
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

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Convert SVG to PNG and save to a temporary file
            using (RasterImage svgImage = (RasterImage)Image.Load(svgPath))
            {
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions { PageSize = svgImage.Size }
                };
                svgImage.Save(tempPngPath, pngOptions);
            }

            // Load the rasterized PNG and the overlay image
            using (RasterImage baseImage = (RasterImage)Image.Load(tempPngPath))
            using (RasterImage overlayImage = (RasterImage)Image.Load(overlayPath))
            {
                // Overlay the second image onto the base image at (0,0)
                Rectangle overlayBounds = new Rectangle(0, 0, overlayImage.Width, overlayImage.Height);
                baseImage.SaveArgb32Pixels(overlayBounds, overlayImage.LoadArgb32Pixels(overlayImage.Bounds));

                // Save the composited image to the final output path
                PngOptions outputOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                baseImage.Save(outputPath, outputOptions);
            }

            // Optionally delete the temporary file
            if (File.Exists(tempPngPath))
            {
                File.Delete(tempPngPath);
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
 * 1. When a developer needs to generate a PNG thumbnail of an SVG logo and add a watermark PNG on top for branding.
 * 2. When an e‑commerce site must convert product SVG icons to raster PNGs and overlay a promotional badge image before serving to browsers.
 * 3. When a reporting tool creates SVG charts and then composites a company logo PNG onto the chart image for PDF export.
 * 4. When a mobile app backend rasterizes user‑uploaded SVG avatars and merges a frame PNG overlay to enforce a visual style.
 * 5. When a document generation pipeline converts SVG diagrams to PNG and adds a transparent overlay for copyright notice.
 */