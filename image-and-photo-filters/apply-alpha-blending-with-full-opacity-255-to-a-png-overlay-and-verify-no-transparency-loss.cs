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
        string backgroundPath = "input_background.png";
        string overlayPath = "input_overlay.png";
        string outputPath = "output.png";

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
                // Blend overlay onto background at (0,0) with full opacity (255)
                background.Blend(new Point(0, 0), overlay, 255);
            }

            // Prepare PNG save options with file source
            PngOptions options = new PngOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };

            // Save the blended image
            background.Save(outputPath, options);
        }
    }
}