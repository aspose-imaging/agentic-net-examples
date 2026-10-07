// HOW-TO: Overlay PNG on SVG Converted to PNG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string svgPath = "input.svg";
        string overlayPath = "overlay.png";
        string outputPath = "output.png";

        try
        {
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

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            string tempPngPath = Path.Combine(Path.GetTempPath(), "temp_svg.png");

            // Convert SVG to PNG
            var pngOptions = new PngOptions
            {
                Source = new FileCreateSource(tempPngPath, false)
            };
            using (Image svgImage = Image.Load(svgPath))
            {
                svgImage.Save(tempPngPath, pngOptions);
            }

            // Load base PNG and overlay image, then merge
            using (RasterImage baseImg = (RasterImage)Image.Load(tempPngPath))
            {
                using (RasterImage overlayImg = (RasterImage)Image.Load(overlayPath))
                {
                    Rectangle bounds = new Rectangle(0, 0, overlayImg.Width, overlayImg.Height);
                    baseImg.SaveArgb32Pixels(bounds, overlayImg.LoadArgb32Pixels(overlayImg.Bounds));
                }

                var outOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                baseImg.Save(outputPath, outOptions);
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
 * 1. When you need to add a watermark logo PNG onto an SVG‑based graphic before exporting it as a final PNG file.
 * 2. When generating product thumbnails that combine a vector SVG background with a promotional badge PNG overlay in a .NET application.
 * 3. When creating composite icons by merging a scalable SVG illustration with a foreground PNG overlay for consistent UI assets.
 * 4. When automating marketing asset preparation that requires converting SVG diagrams to PNG and then stamping a transparent PNG overlay for branding.
 * 5. When building a server‑side image pipeline that converts SVG to PNG and subsequently applies a PNG overlay such as a logo or label before delivery.
 */
