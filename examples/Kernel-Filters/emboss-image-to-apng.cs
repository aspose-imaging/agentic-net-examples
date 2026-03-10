using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Input raster image path
        string inputPath = "input.png";
        // Output APNG file path
        string outputPath = "output.apng";

        // Load the image as a RasterImage
        using (RasterImage source = (RasterImage)Image.Load(inputPath))
        {
            // Apply Emboss filter using ConvolutionFilterOptions
            source.Filter(
                source.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                    Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3));

            // Configure APNG creation options
            ApngOptions apngOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = 1000, // 1 second per frame
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create APNG image canvas
            using (ApngImage apng = (ApngImage)Image.Create(apngOptions, source.Width, source.Height))
            {
                // Ensure no default frame remains
                apng.RemoveAllFrames();
                // Add the filtered image as the sole frame
                apng.AddFrame(source);
                // Save the APNG file
                apng.Save();
            }
        }
    }
}