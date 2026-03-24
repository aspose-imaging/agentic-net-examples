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
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load source raster image
        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            // Configure APNG creation options
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = 70, // 70 ms per frame
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create APNG image canvas
            using (ApngImage apngImage = (ApngImage)Image.Create(
                createOptions,
                sourceImage.Width,
                sourceImage.Height))
            {
                // Remove default frame
                apngImage.RemoveAllFrames();

                // Add multiple frames (duplicate source image)
                int frameCount = 5;
                for (int i = 0; i < frameCount; i++)
                {
                    apngImage.AddFrame(sourceImage);
                    // Optionally adjust gamma for visual variation
                    ApngFrame lastFrame = (ApngFrame)apngImage.Pages[apngImage.PageCount - 1];
                    lastFrame.AdjustGamma(i);
                }

                // Save the animated PNG
                apngImage.Save();
            }
        }
    }
}