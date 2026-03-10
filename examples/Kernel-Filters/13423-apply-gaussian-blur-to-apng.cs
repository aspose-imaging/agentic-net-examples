using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Input raster image path
        string inputPath = "input.png";

        // Output APNG file path
        string outputPath = "output.apng";

        // Load the raster image
        using (RasterImage raster = (RasterImage)Image.Load(inputPath))
        {
            // Apply Gaussian blur filter to the whole image
            // Radius = 5, Sigma = 4.0
            raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Prepare APNG creation options
            ApngOptions apngOptions = new ApngOptions
            {
                // Define where the APNG file will be created
                Source = new FileCreateSource(outputPath, false),

                // Default frame duration (in milliseconds)
                DefaultFrameTime = 100,

                // Preserve alpha channel
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create an empty APNG image with the same dimensions as the raster image
            using (ApngImage apng = (ApngImage)Image.Create(apngOptions, raster.Width, raster.Height))
            {
                // The newly created APNG contains one default frame; remove it
                apng.RemoveAllFrames();

                // Add the filtered raster image as a single frame
                apng.AddFrame(raster);

                // Save the APNG to the specified file
                apng.Save();
            }
        }
    }
}