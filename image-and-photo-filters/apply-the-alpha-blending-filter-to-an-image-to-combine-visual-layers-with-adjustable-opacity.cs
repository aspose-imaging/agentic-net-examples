using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string baseImagePath = "input_base.jpg";
        string overlayImagePath = "input_overlay.png";
        string outputPath = "output/result.png";

        // Verify input files exist
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

        // Load base image
        using (Aspose.Imaging.Image baseImage = Aspose.Imaging.Image.Load(baseImagePath))
        {
            Aspose.Imaging.RasterImage baseRaster = (Aspose.Imaging.RasterImage)baseImage;

            // Load overlay image
            using (Aspose.Imaging.Image overlayImage = Aspose.Imaging.Image.Load(overlayImagePath))
            {
                Aspose.Imaging.RasterImage overlayRaster = (Aspose.Imaging.RasterImage)overlayImage;

                // Configure blending filter
                var blendOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ImageBlendingFilterOptions
                {
                    Image = overlayRaster,
                    Opacity = 0.5f // 50% opacity
                };

                // Apply blending filter to the base raster image
                baseRaster.Filter(baseRaster.Bounds, blendOptions);
            }

            // Save the blended result
            baseRaster.Save(outputPath);
        }
    }
}