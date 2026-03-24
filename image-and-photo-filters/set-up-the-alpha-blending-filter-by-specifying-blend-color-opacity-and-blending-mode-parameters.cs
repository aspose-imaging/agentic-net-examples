using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string baseImagePath = "base.png";
        string overlayImagePath = "overlay.png";
        string outputPath = "output.png";

        // Validate input files
        if (!File.Exists(baseImagePath))
        {
            Console.Error.WriteLine($"File not found: {baseImagePath}");
            return;
        }
        if (!File.Exists(overlayImagePath))
        {
            Console.Error.WriteLine($"File not found: {overlayImagePath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load images
        using (Image baseImage = Image.Load(baseImagePath))
        using (Image overlayImage = Image.Load(overlayImagePath))
        {
            RasterImage baseRaster = (RasterImage)baseImage;
            RasterImage overlayRaster = (RasterImage)overlayImage;

            // Configure alpha blending filter options
            var blendOptions = new ImageBlendingFilterOptions
            {
                Image = overlayRaster,
                Opacity = 0.5f,
                Position = new Point(0, 0),
                BlendingMode = BlendingMode.Normal
            };

            // Apply the blending filter
            baseRaster.Filter(baseRaster.Bounds, blendOptions);

            // Save the result
            baseRaster.Save(outputPath, new PngOptions());
        }
    }
}