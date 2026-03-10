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
            // Apply a Gaussian blur filter to the entire image
            sourceImage.Filter(
                sourceImage.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

            // Configure APNG creation options
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = 100, // frame duration in milliseconds
                ColorType = PngColorType.TruecolorWithAlpha,
                NumPlays = 3 // number of animation loops (0 = infinite)
            };

            // Create the APNG image canvas
            using (ApngImage apngImage = (ApngImage)Image.Create(
                createOptions,
                sourceImage.Width,
                sourceImage.Height))
            {
                // Remove the default single frame
                apngImage.RemoveAllFrames();

                // Add the filtered image as multiple frames for animation
                for (int i = 0; i < 5; i++)
                {
                    apngImage.AddFrame(sourceImage);
                }

                // Save the APNG file (output is already bound to the source)
                apngImage.Save();
            }
        }
    }
}