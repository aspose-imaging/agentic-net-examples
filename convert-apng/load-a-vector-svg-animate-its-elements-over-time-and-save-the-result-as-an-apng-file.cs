// HOW-TO: Create Animated PNG from SVG with Frame Translation in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.apng";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image svgImage = Image.Load(inputPath))
            {
                int width = svgImage.Width;
                int height = svgImage.Height;

                const int totalFrames = 10;
                const int frameDuration = 100; // milliseconds per frame

                ApngOptions apngOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    DefaultFrameTime = (uint)frameDuration,
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                using (ApngImage apng = (ApngImage)Image.Create(apngOptions, width, height))
                {
                    apng.RemoveAllFrames();

                    for (int i = 0; i < totalFrames; i++)
                    {
                        // Create a blank raster canvas for the current frame
                        using (RasterImage frame = (RasterImage)Image.Create(
                            new BmpOptions { Source = new StreamSource(new MemoryStream()) },
                            width,
                            height))
                        {
                            Graphics graphics = new Graphics(frame);
                            graphics.Clear(Color.Transparent);

                            // Simple animation: translate the SVG drawing over time
                            int offsetX = (i * 10) % width;
                            int offsetY = (i * 5) % height;

                            graphics.DrawImage(svgImage, new Point(offsetX, offsetY));

                            apng.AddFrame(frame);
                        }
                    }

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
 * 1. When you need to convert a vector SVG illustration into a looping animated PNG for web banners or UI assets while preserving transparency.
 * 2. When you want to programmatically generate frame‑by‑frame animations from SVG graphics for email newsletters that only support APNG.
 * 3. When you have to create a series of raster frames from a scalable SVG and export them as a single APNG file for mobile game sprites using C#.
 * 4. When you need to apply simple motion effects, such as translating an SVG element over time, and save the result as an APNG without using external animation tools.
 * 5. When you are building an automated pipeline that reads SVG files, animates them with custom frame durations, and outputs high‑quality APNG files for digital signage.
 */
