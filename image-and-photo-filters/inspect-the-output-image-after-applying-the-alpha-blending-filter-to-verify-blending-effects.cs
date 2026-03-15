using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Paths for the base image, overlay image, and output image
        string baseImagePath = "base.png";
        string overlayImagePath = "overlay.png";
        string outputPath = "blended.png";

        // Load the base image
        using (RasterImage baseImage = (RasterImage)Image.Load(baseImagePath))
        {
            // Load the overlay image
            using (RasterImage overlayImage = (RasterImage)Image.Load(overlayImagePath))
            {
                // Configure the alpha blending filter
                ImageBlendingFilterOptions blendOptions = new ImageBlendingFilterOptions
                {
                    Image = overlayImage,               // Overlay image
                    Opacity = 128,                      // 50% opacity (0-255)
                    Position = new Point(0, 0)          // Top-left corner
                    // BlendingMode can be set if needed; using default
                };

                // Apply the blending filter to the entire base image
                baseImage.Filter(baseImage.Bounds, blendOptions);
            }

            // Save the blended result as PNG
            PngOptions pngOptions = new PngOptions();
            baseImage.Save(outputPath, pngOptions);
        }

        // Load the saved output image to inspect pixel data
        using (RasterImage resultImage = (RasterImage)Image.Load(outputPath))
        {
            // Retrieve ARGB value of the pixel at (0,0)
            int argb = resultImage.GetArgb32Pixel(0, 0);
            // Extract individual components
            byte a = (byte)((argb >> 24) & 0xFF);
            byte r = (byte)((argb >> 16) & 0xFF);
            byte g = (byte)((argb >> 8) & 0xFF);
            byte b = (byte)(argb & 0xFF);

            // Output the pixel components to verify blending effect
            Console.WriteLine($"Pixel at (0,0) - A:{a} R:{r} G:{g} B:{b}");
        }
    }
}