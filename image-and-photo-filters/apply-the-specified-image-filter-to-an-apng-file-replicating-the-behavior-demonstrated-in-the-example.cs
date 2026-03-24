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

        const int AnimationDuration = 1000; // milliseconds
        const int FrameDuration = 70; // milliseconds

        // Load the source raster image
        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            // Set up APNG creation options
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = (uint)FrameDuration,
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create the APNG image canvas
            using (ApngImage apngImage = (ApngImage)Image.Create(
                createOptions,
                sourceImage.Width,
                sourceImage.Height))
            {
                // Remove the default single frame
                apngImage.RemoveAllFrames();

                int numOfFrames = AnimationDuration / FrameDuration;
                int halfFrames = numOfFrames / 2;

                // Add the first frame
                apngImage.AddFrame(sourceImage);

                // Add intermediate frames with gamma adjustment (acts as a filter)
                for (int frameIndex = 1; frameIndex < numOfFrames - 1; ++frameIndex)
                {
                    apngImage.AddFrame(sourceImage);
                    ApngFrame lastFrame = (ApngFrame)apngImage.Pages[apngImage.PageCount - 1];
                    float gamma = frameIndex >= halfFrames ? numOfFrames - frameIndex - 1 : frameIndex;
                    lastFrame.AdjustGamma(gamma);
                }

                // Add the final frame
                apngImage.AddFrame(sourceImage);

                // Save the APNG file
                apngImage.Save();
            }
        }
    }
}