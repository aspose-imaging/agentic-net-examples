using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
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
            // Configure APNG creation options
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = 70, // frame duration in milliseconds
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create the APNG image canvas
            using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, sourceImage.Width, sourceImage.Height))
            {
                // Remove the default single frame
                apngImage.RemoveAllFrames();

                // Define total animation duration and calculate frame count
                const int animationDuration = 1000; // total duration in ms
                int frameCount = animationDuration / (int)createOptions.DefaultFrameTime;

                // Add frames (duplicate the source image for simplicity)
                for (int i = 0; i < frameCount; i++)
                {
                    apngImage.AddFrame(sourceImage);

                    // Optional: adjust gamma for visual effect on each frame
                    ApngFrame lastFrame = (ApngFrame)apngImage.Pages[apngImage.PageCount - 1];
                    float gamma = i % 2 == 0 ? 0.5f : 1.5f;
                    lastFrame.AdjustGamma(gamma);
                }

                // Save the APNG (output path already bound via FileCreateSource)
                apngImage.Save();
            }
        }
    }
}