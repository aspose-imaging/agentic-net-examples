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
        string inputPath = "input.png";
        string outputPath = "output.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load source raster image
        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            // Apply smoothing filter to improve visual quality
            sourceImage.Filter(
                sourceImage.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.BilateralSmoothingFilterOptions(5));

            // Set up APNG creation options
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = 70, // milliseconds per frame
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create APNG image bound to the output file
            using (ApngImage apngImage = (ApngImage)Image.Create(
                createOptions,
                sourceImage.Width,
                sourceImage.Height))
            {
                // Remove default frame
                apngImage.RemoveAllFrames();

                // Define animation parameters
                const int animationDuration = 1000; // total duration in ms
                const int frameDuration = 70;       // per-frame duration in ms
                int numOfFrames = animationDuration / frameDuration;
                int halfFrames = numOfFrames / 2;

                // Add first frame
                apngImage.AddFrame(sourceImage);

                // Add intermediate frames with gamma adjustment for visual effect
                for (int frameIndex = 1; frameIndex < numOfFrames - 1; ++frameIndex)
                {
                    apngImage.AddFrame(sourceImage);
                    ApngFrame lastFrame = (ApngFrame)apngImage.Pages[apngImage.PageCount - 1];
                    float gamma = frameIndex >= halfFrames ? numOfFrames - frameIndex - 1 : frameIndex;
                    lastFrame.AdjustGamma(gamma);
                }

                // Add last frame
                apngImage.AddFrame(sourceImage);

                // Save the APNG (output is already bound via FileCreateSource)
                apngImage.Save();
            }
        }
    }
}