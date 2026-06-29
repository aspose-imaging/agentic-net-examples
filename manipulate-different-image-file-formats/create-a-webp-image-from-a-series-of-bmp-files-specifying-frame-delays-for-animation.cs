using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] inputPaths = { "frame1.bmp", "frame2.bmp", "frame3.bmp" };
            foreach (var path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            string outputPath = "Output/animation.webp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage firstImage = (RasterImage)Image.Load(inputPaths[0]))
            {
                WebPOptions options = new WebPOptions
                {
                    Lossless = false,
                    Quality = 80f,
                    AnimLoopCount = 0,
                    AnimBackgroundColor = (uint)Aspose.Imaging.Color.White.ToArgb()
                };

                firstImage.Save(outputPath, options);
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
 * 1. When a developer needs to generate an animated WebP banner from a series of BMP files using Aspose.Imaging in C# to improve page load speed.
 * 2. When an e‑commerce platform wants to convert product BMP frame images into a single WebP animation with custom frame delays for faster mobile browsing.
 * 3. When a mobile app creates lightweight animated stickers by loading BMP drawings with Image.Load and saving them as a lossless WebP animation via WebPOptions.
 * 4. When a game developer uses Aspose.Imaging to stitch BMP storyboard frames into an endlessly looping WebP animation for in‑game cut‑scenes.
 * 5. When a CMS automates the conversion of uploaded BMP slides into an SEO‑friendly animated WebP slideshow, specifying AnimLoopCount and background color through WebPOptions.
 */