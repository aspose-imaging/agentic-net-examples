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
        // Expect input and output file paths as arguments
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: <program> <inputImagePath> <outputApngPath>");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];

        // Load the source image as a raster image (preserves transparency)
        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            // Apply a correction filter (sharpen) to the entire image
            sourceImage.Filter(sourceImage.Bounds, new SharpenFilterOptions());

            // Prepare APNG creation options, ensuring alpha channel is kept
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = 100, // duration of the single frame in ms
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create an APNG image with the same dimensions as the source
            using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, sourceImage.Width, sourceImage.Height))
            {
                // Remove any default frame
                apngImage.RemoveAllFrames();

                // Add the filtered image as the sole frame
                apngImage.AddFrame(sourceImage);

                // Save the APNG file
                apngImage.Save();
            }
        }
    }
}