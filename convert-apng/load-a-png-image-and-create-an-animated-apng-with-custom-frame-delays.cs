// HOW-TO: Create Animated APNG from PNG with Custom Frame Delay in C# (Aspose.Imaging for .NET)
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
        string inputPath = "input.png";
        string outputPath = "output.apng";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
            {
                var source = new FileCreateSource(outputPath, false);
                ApngOptions options = new ApngOptions
                {
                    Source = source,
                    DefaultFrameTime = 100,
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                using (ApngImage apngImage = (ApngImage)Image.Create(options, sourceImage.Width, sourceImage.Height))
                {
                    apngImage.RemoveAllFrames();

                    for (int i = 0; i < 5; i++)
                    {
                        apngImage.AddFrame(sourceImage);
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
 * 1. When you need to generate a looping animated PNG for web banners from a single static PNG.
 * 2. When you want to add consistent frame timing to an APNG sequence for a mobile game sprite sheet.
 * 3. When you must programmatically create an APNG for email newsletters that support animated images.
 * 4. When you are building a .NET tool that converts user‑uploaded PNGs into animated stickers with a fixed delay.
 * 5. When you need to automate the production of animated product previews from a base PNG in a CI pipeline.
 */
