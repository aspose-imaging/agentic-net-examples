// HOW-TO: Create Animated PNG from SVG with Multiple Resolutions in C# (Aspose.Imaging for .NET)
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
        string inputPath = "input.svg";
        string outputPath = "output.apng";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image svgImage = Image.Load(inputPath))
            {
                int[] widths = new int[] { 200, 400, 600 };
                double aspect = (double)svgImage.Height / svgImage.Width;

                ApngOptions apngCreateOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    ColorType = PngColorType.TruecolorWithAlpha,
                    DefaultFrameTime = 200 // milliseconds per frame
                };

                using (ApngImage apng = (ApngImage)Image.Create(
                    apngCreateOptions,
                    widths[0],
                    (int)(widths[0] * aspect)))
                {
                    apng.RemoveAllFrames();

                    foreach (int w in widths)
                    {
                        int h = (int)(w * aspect);

                        PngOptions pngOptions = new PngOptions
                        {
                            VectorRasterizationOptions = new SvgRasterizationOptions
                            {
                                PageWidth = w,
                                PageHeight = h
                            }
                        };

                        using (MemoryStream ms = new MemoryStream())
                        {
                            svgImage.Save(ms, pngOptions);
                            ms.Position = 0;

                            using (RasterImage raster = (RasterImage)Image.Load(ms))
                            {
                                apng.AddFrame(raster);
                            }
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
 * 1. When you need to generate an animated PNG that shows a logo at several sizes for responsive web design.
 * 2. When you want to convert a vector illustration into a lightweight APNG for use in mobile app splash screens with frame‑by‑frame scaling.
 * 3. When you have to create a multi‑resolution animation for an e‑learning module that displays the same SVG graphic at increasing detail levels.
 * 4. When you need to automate the production of a series of PNG frames from an SVG and bundle them into an APNG for email newsletters.
 * 5. When you are building a C# tool that rasterizes SVG icons at different pixel dimensions and assembles them into a single animated PNG for UI hover effects.
 */
