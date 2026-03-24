using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string backgroundPath = "background.png";
        string overlayPath = "overlay.png";
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

        // Load background and overlay images
        using (RasterImage background = (RasterImage)Image.Load(backgroundPath))
        using (RasterImage overlay = (RasterImage)Image.Load(overlayPath))
        {
            // Configure blending filter options
            var blendOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ImageBlendingFilterOptions
            {
                Image = overlay,
                Opacity = 0.5f, // 50% opacity
                BlendingMode = Aspose.Imaging.ImageFilters.FilterOptions.BlendingMode.Normal
            };

            // Apply blending filter to the background image
            background.Filter(background.Bounds, blendOptions);

            // Save the result as PNG
            PngOptions pngOptions = new PngOptions();
            background.Save(outputPath, pngOptions);
        }
    }
}