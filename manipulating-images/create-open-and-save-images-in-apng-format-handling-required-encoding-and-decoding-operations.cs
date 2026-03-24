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
                DefaultFrameTime = 100, // milliseconds per frame
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create the APNG image canvas
            using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, sourceImage.Width, sourceImage.Height))
            {
                // Remove the default empty frame
                apngImage.RemoveAllFrames();

                // Add multiple frames (here, 5 copies of the source image)
                for (int i = 0; i < 5; ++i)
                {
                    apngImage.AddFrame(sourceImage);
                    // Adjust gamma for visual variation
                    ApngFrame lastFrame = (ApngFrame)apngImage.Pages[apngImage.PageCount - 1];
                    lastFrame.AdjustGamma(i * 0.2f);
                }

                // Save the APNG (output path already bound via FileCreateSource)
                apngImage.Save();
            }
        }

        // Demonstrate opening the created APNG and re-saving with a different loop count
        string reoutputPath = "output_animation_looped.png";
        Directory.CreateDirectory(Path.GetDirectoryName(reoutputPath));

        if (!File.Exists(outputPath))
        {
            Console.Error.WriteLine($"File not found: {outputPath}");
            return;
        }

        using (Image loadedApng = Image.Load(outputPath))
        {
            // Save with NumPlays = 3 (animation will loop three times)
            loadedApng.Save(reoutputPath, new ApngOptions { NumPlays = 3 });
        }
    }
}