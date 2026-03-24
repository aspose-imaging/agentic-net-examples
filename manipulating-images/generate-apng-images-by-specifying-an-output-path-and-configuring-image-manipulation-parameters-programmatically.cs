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
        // Hardcoded input and output paths
        string inputPath = "not_animated.png";
        string outputPath = "output/raster_animation.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        const int animationDuration = 1000; // total animation duration in ms
        const int frameDuration = 70;       // each frame duration in ms

        // Load source raster image
        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            // Configure APNG creation options
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = (uint)frameDuration,
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create APNG image canvas
            using (ApngImage apngImage = (ApngImage)Image.Create(
                createOptions,
                sourceImage.Width,
                sourceImage.Height))
            {
                int numOfFrames = animationDuration / frameDuration;
                int numOfFrames2 = numOfFrames / 2;

                // Remove default frame
                apngImage.RemoveAllFrames();

                // Add first frame
                apngImage.AddFrame(sourceImage);

                // Add intermediate frames with gamma adjustment
                for (int frameIndex = 1; frameIndex < numOfFrames - 1; ++frameIndex)
                {
                    apngImage.AddFrame(sourceImage);
                    ApngFrame lastFrame = (ApngFrame)apngImage.Pages[apngImage.PageCount - 1];
                    float gamma = frameIndex >= numOfFrames2 ? numOfFrames - frameIndex - 1 : frameIndex;
                    lastFrame.AdjustGamma(gamma);
                }

                // Add last frame
                apngImage.AddFrame(sourceImage);

                // Save the APNG (output path already bound via Source)
                apngImage.Save();
            }
        }
    }
}