using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Paths for the base image, overlay image, and output image
        string baseImagePath = "base.png";
        string overlayImagePath = "overlay.png";
        string outputImagePath = "output.png";

        // Load the base image
        using (RasterImage baseImage = (RasterImage)Image.Load(baseImagePath))
        {
            // Load the overlay image
            using (RasterImage overlayImage = (RasterImage)Image.Load(overlayImagePath))
            {
                // Configure the image blending filter options
                var blendOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ImageBlendingFilterOptions
                {
                    Image = overlayImage,                     // Set the overlay image
                    Opacity = 0.5f,                           // 50% opacity
                    Position = new Point(50, 50)              // Position of the overlay on the base image
                    // BlendingMode can be set if needed; default is used here
                };

                // Apply the blending filter to the entire base image
                baseImage.Filter(baseImage.Bounds, blendOptions);

                // Save the resulting image
                baseImage.Save(outputImagePath);
            }
        }
    }
}