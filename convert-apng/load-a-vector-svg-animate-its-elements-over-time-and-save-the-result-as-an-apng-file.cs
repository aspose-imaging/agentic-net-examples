// HOW-TO: Create Animated PNG from SVG with Moving Elements in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.svg";
            string outputPath = "output.apng";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int frameCount = 10;
            int width, height;

            using (Image svgImage = Image.Load(inputPath))
            {
                width = svgImage.Width;
                height = svgImage.Height;

                ApngOptions apngOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    DefaultFrameTime = 100,
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                using (ApngImage apng = (ApngImage)Image.Create(apngOptions, width, height))
                {
                    for (int i = 0; i < frameCount; i++)
                    {
                        string tempPath = Path.Combine(Path.GetTempPath(), $"frame_{i}.png");
                        Source tempSource = new FileCreateSource(tempPath, false);
                        PngOptions pngOptions = new PngOptions { Source = tempSource };

                        using (RasterImage frame = (RasterImage)Image.Create(pngOptions, width, height))
                        {
                            Graphics graphics = new Graphics(frame);
                            graphics.Clear(Color.Transparent);

                            int offsetX = (width * i) / frameCount;
                            graphics.DrawImage(svgImage, new Point(offsetX, 0));

                            apng.AddFrame(frame);
                        }

                        if (File.Exists(tempPath))
                        {
                            File.Delete(tempPath);
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
 * 1. When you need to generate a looping APNG banner that slides an SVG logo across the frame for web advertising.
 * 2. When you want to programmatically create an animated icon by shifting parts of an SVG over multiple frames in a .NET application.
 * 3. When you have to export a vector illustration as a high‑quality animated PNG for use in mobile apps without losing transparency.
 * 4. When you need to automate the production of frame‑by‑frame animations from SVG assets for email newsletters that support APNG.
 * 5. When you are building a reporting tool that visualizes data trends by moving SVG charts across successive APNG frames.
 */
