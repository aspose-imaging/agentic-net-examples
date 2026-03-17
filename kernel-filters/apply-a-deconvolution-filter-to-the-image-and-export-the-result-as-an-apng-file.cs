using System;
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

        // Load the raster image
        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            // Apply a motion deconvolution filter (MotionWienerFilterOptions)
            var deconvOptions = new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(10, 1.0, 90.0);
            sourceImage.Filter(sourceImage.Bounds, deconvOptions);

            // Set up APNG creation options
            using (ApngOptions apngCreateOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = 100, // frame duration in milliseconds
                ColorType = PngColorType.TruecolorWithAlpha
            })
            {
                // Create the APNG image canvas
                using (ApngImage apngImage = (ApngImage)Image.Create(apngCreateOptions, sourceImage.Width, sourceImage.Height))
                {
                    // Ensure no default frame remains
                    apngImage.RemoveAllFrames();

                    // Add the filtered image as a single frame
                    apngImage.AddFrame(sourceImage);

                    // Save the APNG (output is already bound to the source)
                    apngImage.Save();
                }
            }
        }
    }
}