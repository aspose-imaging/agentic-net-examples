using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.png";
        string outputPath = "output.apng";

        // Load the source image as a raster image
        using (RasterImage raster = (RasterImage)Image.Load(inputPath))
        {
            // Apply a motion Wiener filter (used here as a motion blur effect)
            raster.Filter(
                raster.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(10, 1.0, 90.0));

            // Set up APNG creation options
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = 500, // frame duration in milliseconds
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create the APNG image and add the filtered frame
            using (ApngImage apng = (ApngImage)Image.Create(createOptions, raster.Width, raster.Height))
            {
                apng.RemoveAllFrames();          // Remove default frame
                apng.AddFrame(raster);           // Add the filtered image as a frame
                apng.Save();                     // Save the APNG file
            }
        }
    }
}