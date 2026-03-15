using System;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        // Expect three arguments: base image path, overlay image path, output image path
        if (args.Length < 3)
        {
            Console.WriteLine("Usage: <baseImage> <overlayImage> <outputImage>");
            return;
        }

        string basePath = args[0];
        string overlayPath = args[1];
        string outputPath = args[2];

        // Load the base image
        using (RasterImage baseImage = (RasterImage)Image.Load(basePath))
        {
            // Load the overlay image
            using (RasterImage overlayImage = (RasterImage)Image.Load(overlayPath))
            {
                // Configure blending options
                var blendOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ImageBlendingFilterOptions
                {
                    Image = overlayImage,          // Overlay image
                    Opacity = 128,                // 0-255 (50% opacity)
                    Position = new Point(0, 0)    // Top-left corner
                };

                // Apply the blending filter to the entire base image
                baseImage.Filter(baseImage.Bounds, blendOptions);

                // Save the blended result
                baseImage.Save(outputPath);
            }
        }
    }
}