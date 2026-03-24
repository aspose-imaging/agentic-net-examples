using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output_animation.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source raster image
        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            // Animation parameters
            const int AnimationDuration = 1000; // total duration in ms
            const int FrameDuration = 70;       // each frame duration in ms

            // Configure APNG creation options
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = (uint)FrameDuration,
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create the APNG canvas bound to the output file
            using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, sourceImage.Width, sourceImage.Height))
            {
                int numOfFrames = AnimationDuration / FrameDuration;
                int numOfFrames2 = numOfFrames / 2;

                // Remove the default empty frame
                apngImage.RemoveAllFrames();

                // Add the first frame
                apngImage.AddFrame(sourceImage);

                // Add intermediate frames with gamma adjustments
                for (int frameIndex = 1; frameIndex < numOfFrames - 1; ++frameIndex)
                {
                    apngImage.AddFrame(sourceImage);
                    ApngFrame lastFrame = (ApngFrame)apngImage.Pages[apngImage.PageCount - 1];
                    float gamma = frameIndex >= numOfFrames2 ? numOfFrames - frameIndex - 1 : frameIndex;
                    lastFrame.AdjustGamma(gamma);
                }

                // Add the last frame
                apngImage.AddFrame(sourceImage);

                // Save the APNG (output is already bound)
                apngImage.Save();
            }
        }
    }
}