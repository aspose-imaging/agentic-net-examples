using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input raster image path
        string inputPath = "input.png";
        // Output APNG file path
        string outputPath = "output.apng";

        // Load the image as RasterImage
        using (RasterImage raster = (RasterImage)Image.Load(inputPath))
        {
            // Apply Sharpen filter (kernel size 5, sigma 4.0) to the whole image
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

            // Prepare APNG creation options
            ApngOptions apngOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = 100, // frame duration in milliseconds
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create APNG image with the same dimensions as the filtered raster
            using (ApngImage apng = (ApngImage)Image.Create(apngOptions, raster.Width, raster.Height))
            {
                // Ensure no default frame remains
                apng.RemoveAllFrames();

                // Add the filtered raster as the sole frame
                apng.AddFrame(raster);

                // Save the APNG file (output path is already bound via FileCreateSource)
                apng.Save();
            }
        }
    }
}