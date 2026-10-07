// HOW-TO: Create Animated APNG From SVG With Custom Size And Background In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output/output.apng";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int frameWidth = 200;
            int frameHeight = 200;
            Color backgroundColor = Color.White;

            using (Image svgImage = Image.Load(inputPath))
            {
                using (var memoryStream = new MemoryStream())
                {
                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = new SvgRasterizationOptions
                        {
                            PageWidth = frameWidth,
                            PageHeight = frameHeight,
                            BackgroundColor = backgroundColor
                        }
                    };
                    svgImage.Save(memoryStream, pngOptions);
                    memoryStream.Position = 0;

                    using (RasterImage raster = (RasterImage)Image.Load(memoryStream))
                    {
                        var apngOptions = new ApngOptions
                        {
                            Source = new FileCreateSource(outputPath, false),
                            DefaultFrameTime = 100,
                            ColorType = PngColorType.TruecolorWithAlpha
                        };

                        using (ApngImage apng = (ApngImage)Image.Create(apngOptions, frameWidth, frameHeight))
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                apng.AddFrame(raster);
                            }
                            apng.Save();
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
 * 1. When you need to generate a lightweight animated icon from a vector logo for a web UI, you can convert the SVG to an APNG with defined dimensions and a transparent or solid background using C#.
 * 2. When an application must produce frame‑by‑frame animations for mobile apps without relying on GIF, you can rasterize SVG graphics into PNG frames and bundle them into an APNG file programmatically.
 * 3. When you want to create a series of consistent‑size animated assets from a single SVG template for game sprites, this code lets you set the exact width, height, and background color before saving the APNG.
 * 4. When automating a build pipeline that converts designer‑provided SVG assets into animated PNGs for email newsletters, the snippet shows how to rasterize and assemble the APNG in .NET.
 * 5. When building a reporting tool that visualizes data changes as an animated diagram, you can render each SVG state to a PNG frame and combine them into an APNG with a uniform background using the provided code.
 */
