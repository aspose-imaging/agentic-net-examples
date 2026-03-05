using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string baseImagePath = args.Length > 0 ? args[0] : "base.png";
        string overlayImagePath = args.Length > 1 ? args[1] : "overlay.png";
        string outputImagePath = args.Length > 2 ? args[2] : "result.png";

        // Load the base image
        using (RasterImage baseImage = (RasterImage)Image.Load(baseImagePath))
        {
            // Load the overlay image
            using (RasterImage overlayImage = (RasterImage)Image.Load(overlayImagePath))
            {
                // Configure alpha blending filter options
                ImageBlendingFilterOptions blendOptions = new ImageBlendingFilterOptions
                {
                    Image = overlayImage,
                    Opacity = 128, // 0-255 (50% opacity)
                    Position = new Point(0, 0),
                    BlendingMode = BlendingMode.Normal
                };

                // Apply the blending filter to the entire base image
                baseImage.Filter(baseImage.Bounds, blendOptions);
            }

            // Save the result as PNG
            Source outSource = new FileCreateSource(outputImagePath, false);
            PngOptions pngOptions = new PngOptions { Source = outSource };
            baseImage.Save(outputImagePath, pngOptions);
        }
    }
}