// HOW-TO: Create APNG with Custom Loop Count and Frame Delay in C# (Aspose.Imaging for .NET)
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
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.apng";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
            {
                ApngOptions options = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    DefaultFrameTime = 100, // frame delay in milliseconds
                    NumPlays = 5, // custom loop count
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                using (ApngImage apng = (ApngImage)Image.Create(options, sourceImage.Width, sourceImage.Height))
                {
                    apng.RemoveAllFrames();
                    apng.AddFrame(sourceImage);
                    apng.Save();
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate an animated PNG that repeats a specific number of times instead of looping forever.
 * 2. When you want to control the speed of each frame in an APNG by setting a custom delay in milliseconds.
 * 3. When integrating Aspose.Imaging into a C# application to convert a static PNG into an animated PNG with defined playback settings.
 * 4. When creating lightweight web animations where precise loop counts and timing are required for user experience or branding guidelines.
 * 5. When automating batch processing of images to produce APNG files with consistent frame timing and loop behavior for mobile or game assets.
 */
