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
        // Hardcoded input and output paths
        string backgroundPath = "background.png";
        string overlayPath = "overlay.png";
        string outputPath = "output.png";

        // Validate input files
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
            // Apply full opacity blending (255) at origin (0,0)
            background.Blend(new Point(0, 0), overlay, 255);

            // Save blended result as PNG
            PngOptions pngOptions = new PngOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };
            background.Save(outputPath, pngOptions);
        }

        // Verify that the saved image retains full opacity (no transparency loss)
        using (RasterImage result = (RasterImage)Image.Load(outputPath))
        {
            int[] pixels = result.LoadArgb32Pixels(result.Bounds);
            bool transparencyLost = false;
            foreach (int argb in pixels)
            {
                byte alpha = (byte)(argb >> 24);
                if (alpha != 255)
                {
                    transparencyLost = true;
                    break;
                }
            }

            if (transparencyLost)
            {
                Console.Error.WriteLine("Transparency loss detected in the blended image.");
            }
            else
            {
                Console.WriteLine("Blending completed successfully with full opacity; no transparency loss.");
            }
        }
    }
}