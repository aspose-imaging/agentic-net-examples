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
        string outputPath = "output_animation.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the source PNG image
        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            // Animation parameters
            const int animationDuration = 1000; // total duration in ms
            const int frameDuration = 200;      // each frame duration in ms

            // Create APNG options with custom frame delay
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = (uint)frameDuration,
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create the APNG canvas
            using (ApngImage apngImage = (ApngImage)Image.Create(
                createOptions,
                sourceImage.Width,
                sourceImage.Height))
            {
                int numOfFrames = animationDuration / frameDuration;
                if (numOfFrames < 1) numOfFrames = 1;

                // Remove the default frame
                apngImage.RemoveAllFrames();

                // Add frames with the specified delay
                for (int i = 0; i < numOfFrames; i++)
                {
                    apngImage.AddFrame(sourceImage, (uint)frameDuration);
                }

                // Save the animated APNG (output is already bound via FileCreateSource)
                apngImage.Save();
            }
        }
    }
}