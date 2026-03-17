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
        // Input raster image and output APNG file paths
        string sourcePath = "not_animated.png";
        string outputPath = "animated_output.png";

        // Load the source raster image
        using (RasterImage sourceImage = (RasterImage)Image.Load(sourcePath))
        {
            // Configure APNG creation options; binding the output file via FileCreateSource
            ApngOptions apngOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = 70, // 70 ms per frame
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create the APNG canvas with the same dimensions as the source image
            using (ApngImage apngImage = (ApngImage)Image.Create(apngOptions, sourceImage.Width, sourceImage.Height))
            {
                // Remove the default frame that exists upon creation
                apngImage.RemoveAllFrames();

                // Add the first frame (original image)
                apngImage.AddFrame(sourceImage);

                // Add intermediate frames with varying adjustments
                int totalFrames = 10;
                for (int i = 1; i < totalFrames - 1; i++)
                {
                    // Append a new frame based on the source image
                    apngImage.AddFrame(sourceImage);

                    // Retrieve the newly added frame
                    ApngFrame frame = (ApngFrame)apngImage.Pages[apngImage.PageCount - 1];

                    // Apply varying visual modifications per frame
                    int brightness = i * 10;            // Incremental brightness
                    float gamma = 1.0f + i * 0.1f;      // Incremental gamma

                    frame.AdjustBrightness(brightness);
                    frame.AdjustGamma(gamma);
                }

                // Add the final frame (original image)
                apngImage.AddFrame(sourceImage);

                // Save the APNG; the file is already bound to the output path
                apngImage.Save();
            }
        }
    }
}