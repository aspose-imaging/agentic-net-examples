// HOW-TO: Create Animated PNG From SVG With Gradient Fill Using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
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

            using (Image image = Image.Load(inputPath))
            {
                SvgImage svgImage = (SvgImage)image;
                int width = svgImage.Width;
                int height = svgImage.Height;

                ApngOptions apngOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    DefaultFrameTime = 100,
                    NumPlays = 0
                };

                using (ApngImage apng = (ApngImage)Image.Create(apngOptions, width, height))
                {
                    int frameCount = 10;
                    for (int i = 0; i < frameCount; i++)
                    {
                        int r = 255 - (i * 255 / (frameCount - 1));
                        int b = i * 255 / (frameCount - 1);
                        Color bgColor = Color.FromArgb(r, 0, b);

                        SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                        {
                            PageWidth = width,
                            PageHeight = height,
                            BackgroundColor = bgColor
                        };

                        PngOptions pngOptions = new PngOptions
                        {
                            VectorRasterizationOptions = rasterOptions
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
 * 1. When you need to generate a looping animated icon that smoothly transitions its fill colors for a web dashboard.
 * 2. When you want to convert vector illustrations into lightweight APNG files with a gradient animation for mobile applications.
 * 3. When you have an SVG logo and must create an animated loading spinner that fades from red to blue using C#.
 * 4. When you are building an email newsletter and require an animated PNG with a gradient background that is compatible with most email clients.
 * 5. When you need to programmatically produce frame‑by‑frame color‑shift animations from SVG assets for game UI elements.
 */
