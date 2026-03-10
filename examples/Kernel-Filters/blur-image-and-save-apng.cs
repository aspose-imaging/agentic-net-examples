using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input raster image path
        string inputPath = "input.png";
        // Output APNG file path
        string outputPath = "output.apng";

        // Load the source image as RasterImage
        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            // Apply Gaussian blur filter to the entire image
            // Radius = 5, Sigma = 4.0 (adjust as needed)
            sourceImage.Filter(sourceImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Prepare APNG creation options
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = 100, // frame duration in milliseconds
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create APNG image with the same dimensions as the source
            using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, sourceImage.Width, sourceImage.Height))
            {
                // Remove the default empty frame
                apngImage.RemoveAllFrames();

                // Add the blurred image as the sole frame
                apngImage.AddFrame(sourceImage);

                // Save the APNG (output file is already bound via FileCreateSource)
                apngImage.Save();
            }
        }
    }
}