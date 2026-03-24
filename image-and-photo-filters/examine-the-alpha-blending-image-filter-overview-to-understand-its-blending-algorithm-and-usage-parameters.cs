using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string backgroundPath = @"C:\Images\background.png";
        string overlayPath = @"C:\Images\overlay.png";
        string outputPath = @"C:\Images\blended.png";

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

        // Load background image
        using (RasterImage background = (RasterImage)Image.Load(backgroundPath))
        {
            // Load overlay image
            using (RasterImage overlay = (RasterImage)Image.Load(overlayPath))
            {
                // Alpha‑blend overlay onto background at (50,50) with 50 % opacity
                background.Blend(new Point(50, 50), overlay, 128);
            }

            // Save the blended result as PNG
            Source outSource = new FileCreateSource(outputPath, false);
            PngOptions pngOpts = new PngOptions { Source = outSource };
            background.Save(outputPath, pngOpts);
        }
    }
}