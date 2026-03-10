using System;
using Aspose.Imaging.MagicWand;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Load the image as a RasterImage
        using (Aspose.Imaging.RasterImage image = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
        {
            // Select a region using Magic Wand at point (100, 100) with a custom threshold
            MagicWandTool.Select(image, new MagicWandSettings(100, 100) { Threshold = 120 })
                .Apply();

            // Apply a Gaussian blur filter to the entire image
            image.Filter(
                image.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0)
            );

            // Save the processed image
            image.Save(outputPath);
        }
    }
}