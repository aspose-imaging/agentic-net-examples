using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string baseImagePath = "base.png";
        string overlayImagePath = "overlay.png";
        string outputImagePath = "output.png";

        // Load the base image
        using (RasterImage baseImage = (RasterImage)Image.Load(baseImagePath))
        {
            // Load the overlay image
            using (RasterImage overlayImage = (RasterImage)Image.Load(overlayImagePath))
            {
                // Configure the alpha blending filter
                var blendOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ImageBlendingFilterOptions
                {
                    Image = overlayImage,          // Image to blend onto the base
                    Opacity = 128,                // 0-255 opacity (128 ≈ 50%)
                    Position = new Point(50, 50) // Position where overlay is placed
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