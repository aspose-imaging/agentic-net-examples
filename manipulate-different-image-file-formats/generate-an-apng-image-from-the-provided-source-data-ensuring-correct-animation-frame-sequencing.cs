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
        // Input raster image path (single-frame source)
        string inputPath = "input.png";
        // Output APNG file path
        string outputPath = "output.apng";

        // Animation timing settings
        const int animationDuration = 1000; // total animation duration in milliseconds
        const int frameDuration = 70;       // duration of each frame in milliseconds

        // Load the source image as a RasterImage
        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            // Set up options for creating the APNG
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = (uint)frameDuration,
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create an APNG image with the same dimensions as the source
            using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, sourceImage.Width, sourceImage.Height))
            {
                // Remove the default frame that exists after creation
                apngImage.RemoveAllFrames();

                // Determine the number of frames based on total duration and per-frame duration
                int numOfFrames = animationDuration / frameDuration;
                int halfFrames = numOfFrames / 2;

                // Add the first frame
                apngImage.AddFrame(sourceImage);

                // Add intermediate frames, adjusting gamma for visual effect
                for (int i = 1; i < numOfFrames - 1; ++i)
                {
                    apngImage.AddFrame(sourceImage);
                    ApngFrame lastFrame = (ApngFrame)apngImage.Pages[apngImage.PageCount - 1];
                    float gamma = i >= halfFrames ? numOfFrames - i - 1 : i;
                    lastFrame.AdjustGamma(gamma);
                }

                // Add the final frame
                apngImage.AddFrame(sourceImage);

                // Save the composed APNG to the specified output path
                apngImage.Save();
            }
        }
    }
}