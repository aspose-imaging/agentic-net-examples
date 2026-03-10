using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Load the background image
        using (RasterImage background = (RasterImage)Image.Load(inputPath))
        {
            // Load the overlay image (using the same image for demonstration)
            using (RasterImage overlay = (RasterImage)Image.Load(inputPath))
            {
                // Apply the image blending filter
                background.Filter(
                    background.Bounds,
                    new ImageBlendingFilterOptions
                    {
                        Image = overlay,
                        Opacity = 0.5f // 50% opacity
                    });
            }

            // Prepare PNG save options with a file source
            Source source = new FileCreateSource(outputPath, false);
            PngOptions options = new PngOptions { Source = source };

            // Save the processed image
            background.Save(outputPath, options);
        }
    }
}