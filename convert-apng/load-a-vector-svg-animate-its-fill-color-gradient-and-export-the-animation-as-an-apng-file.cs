// HOW-TO: Create Animated PNG from SVG with Color Gradient in C# (Aspose.Imaging for .NET)
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
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = new Size(svgImage.Width, svgImage.Height)
                };
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                using (var ms = new MemoryStream())
                {
                    svgImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (RasterImage baseRaster = (RasterImage)Image.Load(ms))
                    {
                        int width = baseRaster.Width;
                        int height = baseRaster.Height;

                        var apngOptions = new ApngOptions
                        {
                            Source = new FileCreateSource(outputPath, false),
                            DefaultFrameTime = 100,
                            ColorType = PngColorType.TruecolorWithAlpha
                        };

                        using (ApngImage apngImage = (ApngImage)Image.Create(apngOptions, width, height))
                        {
                            apngImage.RemoveAllFrames();

                            const int totalFrames = 20;
                            for (int i = 0; i < totalFrames; i++)
                            {
                                byte r = (byte)(255 - (255 * i / (totalFrames - 1)));
                                byte b = (byte)(255 * i / (totalFrames - 1));
                                var overlayColor = Color.FromArgb(255, r, 0, b);

                                Graphics g = new Graphics(baseRaster);
                                g.Clear(overlayColor);

                                apngImage.AddFrame(baseRaster);
                            }

                            apngImage.Save();
                        }
                    }
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
 * 1. When you need to turn a vector SVG logo into a looping APNG animation that smoothly transitions its fill colors for use on web pages.
 * 2. When you want to generate lightweight animated icons from SVG assets for mobile apps without relying on JavaScript or CSS animations.
 * 3. When you must batch‑process design files to produce animated PNGs that preserve transparency and support true‑color gradients for marketing banners.
 * 4. When you are building a reporting tool that visualizes data by animating SVG charts into APNG files for inclusion in PDF or email attachments.
 * 5. When you require server‑side rendering of SVG illustrations into frame‑by‑frame APNG sequences for game UI elements or interactive tutorials.
 */
