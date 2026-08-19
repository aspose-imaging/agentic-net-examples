// HOW-TO: Create Animated PNG From Single PNG With 100ms Frame Delay In C# (Aspose.Imaging for .NET)
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
            const string inputPath = "input.png";
            const string outputPath = "output.apng";

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
                ApngOptions createOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    DefaultFrameTime = 100u,
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                using (ApngImage apngImage = (ApngImage)Image.Create(
                    createOptions,
                    sourceImage.Width,
                    sourceImage.Height))
                {
                    apngImage.RemoveAllFrames();

                    const int frameCount = 5;
                    for (int i = 0; i < frameCount; i++)
                    {
                        apngImage.AddFrame(sourceImage, 100u);
                    }

                    apngImage.Save();
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
 * 1. When you need to generate a simple looping animation for a web banner by repeating a single PNG image with a consistent 100 ms frame interval using Aspose.Imaging in C#.
 * 2. When you want to programmatically create an APNG file for mobile app assets where each frame shows the same icon for a short duration to meet platform animation guidelines.
 * 3. When you are building a reporting tool that embeds animated PNGs and must produce the animation from a static chart image with a fixed frame delay without external tools.
 * 4. When you need to automate the conversion of a static PNG logo into an animated PNG sprite for game UI, ensuring each frame displays for exactly 0.1 seconds.
 * 5. When you are testing image processing pipelines and require a deterministic APNG with multiple identical frames and a known 100 ms delay to validate rendering performance.
 */
