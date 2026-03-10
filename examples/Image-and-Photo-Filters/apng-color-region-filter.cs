using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.apng";
        string outputPath = "output.apng";

        // Load the APNG image as a RasterImage
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Select region based on color similarity using Magic Wand
            // Reference point (120, 100) with a custom threshold
            MagicWandTool
                .Select(image, new MagicWandSettings(120, 100) { Threshold = 150 })
                .Apply();

            // Cast to ApngImage to use the Filter method
            var apngImage = (Aspose.Imaging.FileFormats.Apng.ApngImage)image;

            // Create a Gaussian blur filter option (fully qualified to avoid extra using)
            var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions
            {
                Radius = 5
            };

            // Apply the filter to the whole image (or you could define a specific rectangle)
            apngImage.Filter(apngImage.Bounds, blurOptions);

            // Save the modified APNG with appropriate options
            var saveOptions = new ApngOptions
            {
                ColorType = Aspose.Imaging.FileFormats.Png.PngColorType.TruecolorWithAlpha,
                Source = new FileCreateSource(outputPath, false)
            };
            // Since the output file is bound via FileCreateSource, call Save() on the canvas
            apngImage.Save();
        }
    }
}