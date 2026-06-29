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
            string backgroundPath = "background.jpg";
            string overlayPath = "overlay.png";
            string outputPath = "output.jpg";

            // Verify input files exist
            if (!File.Exists(backgroundPath))
            {
                Console.Error.WriteLine($"File not found: {backgroundPath}");
                return;
            }
            if (!File.Exists(overlayPath))
            {
                Console.Error.WriteLine($"File not found: {overlayPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load background and overlay images
            using (RasterImage background = (RasterImage)Image.Load(backgroundPath))
            using (RasterImage overlay = (RasterImage)Image.Load(overlayPath))
            {
                // Blend overlay onto background with 0 opacity (no change to background)
                background.Blend(new Point(0, 0), overlay, 0);

                // Prepare JPEG save options
                Source outputSource = new FileCreateSource(outputPath, false);
                JpegOptions jpegOptions = new JpegOptions() { Source = outputSource, Quality = 90 };

                // Save the result
                background.Save(outputPath, jpegOptions);
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
 * 1. When a developer wants to verify that applying an overlay image with zero opacity does not alter the original JPEG background during automated image processing pipelines.
 * 2. When testing a C# image compositing routine to ensure that the Blend method respects the opacity parameter and leaves the source raster unchanged for quality assurance.
 * 3. When building a web service that conditionally adds watermarks only if opacity is greater than zero, and needs a baseline case where the background image remains intact.
 * 4. When creating unit tests for Aspose.Imaging's Blend function to confirm that a PNG overlay with 0% opacity does not affect the pixel data of a loaded background JPEG.
 * 5. When troubleshooting image export settings and needing to demonstrate that saving a blended image as JPEG with specific quality settings preserves the original background when no visible overlay is applied.
 */