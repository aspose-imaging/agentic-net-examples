// HOW-TO: Create Animated PNG From SVG At Multiple Resolutions In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputSvg = "input.svg";
            string outputApng = "output.apng";

            if (!File.Exists(inputSvg))
            {
                Console.Error.WriteLine($"File not found: {inputSvg}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputApng);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            var sizes = new (int width, int height)[]
            {
                (200, 200),
                (400, 400),
                (600, 600)
            };

            var frames = new List<Aspose.Imaging.RasterImage>();

            using (Aspose.Imaging.Image vectorImage = Aspose.Imaging.Image.Load(inputSvg))
            {
                foreach (var size in sizes)
                {
                    using (var ms = new MemoryStream())
                    {
                        var pngOptions = new PngOptions
                        {
                            VectorRasterizationOptions = new SvgRasterizationOptions
                            {
                                PageWidth = size.width,
                                PageHeight = size.height,
                                BackgroundColor = Aspose.Imaging.Color.White
                            }
                        };
                        vectorImage.Save(ms, pngOptions);
                        ms.Position = 0;
                        var raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(ms);
                        frames.Add(raster);
                    }
                }
            }

            var apngOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputApng, false)
            };

            using (Aspose.Imaging.Image apngBase = Aspose.Imaging.Image.Create(apngOptions, frames[0].Width, frames[0].Height))
            {
                var apng = (Aspose.Imaging.FileFormats.Apng.ApngImage)apngBase;
                apng.RemoveAllFrames();
                foreach (var frame in frames)
                {
                    apng.AddFrame(frame);
                }
                apng.Save();
            }

            foreach (var frame in frames)
            {
                frame.Dispose();
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
 * 1. When you need to generate a responsive animated icon that scales smoothly on high‑DPI screens by converting an SVG into an APNG with frames at 200×200, 400×400, and 600×600 pixels.
 * 2. When a web application must serve a single animated image file that shows the same graphic at increasing sizes for a step‑by‑step tutorial or product showcase.
 * 3. When you want to create a lightweight animated logo for mobile apps where each frame is a rasterized version of the original vector at a specific resolution to balance quality and file size.
 * 4. When an e‑learning platform requires an APNG that animates a diagram at different zoom levels, and you need to automate the SVG‑to‑APNG conversion in C# using Aspose.Imaging.
 * 5. When a game UI needs an animated sprite generated from a vector asset, and you must produce multiple resolution frames in a single APNG to support various screen resolutions without storing separate files.
 */
