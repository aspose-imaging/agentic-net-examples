// HOW-TO: Create APNG Animation From Multiple PNGs With Loop Count In C# (Aspose.Imaging for .NET)
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
            string inputPath1 = "frame1.png";
            string inputPath2 = "frame2.png";
            string inputPath3 = "frame3.png";
            string outputPath = "output\\animation.apng";

            if (!File.Exists(inputPath1)) { Console.Error.WriteLine($"File not found: {inputPath1}"); return; }
            if (!File.Exists(inputPath2)) { Console.Error.WriteLine($"File not found: {inputPath2}"); return; }
            if (!File.Exists(inputPath3)) { Console.Error.WriteLine($"File not found: {inputPath3}"); return; }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage img1 = (RasterImage)Image.Load(inputPath1))
            using (RasterImage img2 = (RasterImage)Image.Load(inputPath2))
            using (RasterImage img3 = (RasterImage)Image.Load(inputPath3))
            {
                int width = img1.Width;
                int height = img1.Height;

                ApngOptions options = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    DefaultFrameTime = 100,
                    NumPlays = 5,
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                using (ApngImage apng = (ApngImage)Image.Create(options, width, height))
                {
                    apng.RemoveAllFrames();
                    apng.AddFrame(img1);
                    apng.AddFrame(img2);
                    apng.AddFrame(img3);
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
 * 1. When you need to combine a series of PNG screenshots into a single animated APNG for a product tutorial, this code creates the animation and sets it to play a specific number of times.
 * 2. When generating lightweight animated icons for a desktop application, you can use this snippet to merge individual PNG frames into an APNG with a defined loop count and frame delay.
 * 3. When building a web‑based slideshow that requires an APNG file instead of GIF for better color depth, the example shows how to load PNG assets and assemble them with custom playback settings in C#.
 * 4. When automating the creation of animated badges for a CI/CD pipeline, the code demonstrates how to programmatically add PNG frames and control the number of repeats using Aspose.Imaging.
 * 5. When preparing marketing assets that need a precise number of animation cycles, this sample lets you load PNG images, set the default frame time, and export a looping APNG using .NET.
 */
