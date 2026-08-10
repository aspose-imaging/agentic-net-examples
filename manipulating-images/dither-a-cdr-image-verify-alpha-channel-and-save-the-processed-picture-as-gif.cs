// HOW-TO: Dither CDR Image, Check Alpha Channel and Save as GIF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.cdr";
        string outputPath = "output.gif";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (CdrImage cdr = (CdrImage)Aspose.Imaging.Image.Load(inputPath))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            PageWidth = cdr.Width,
                            PageHeight = cdr.Height,
                            TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel,
                            SmoothingMode = Aspose.Imaging.SmoothingMode.None
                        }
                    };

                    cdr.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(ms))
                    {
                        raster.Dither(Aspose.Imaging.DitheringMethod.FloydSteinbergDithering, 8);
                        bool hasAlpha = raster.HasAlpha;
                        Console.WriteLine($"Alpha channel present: {hasAlpha}");

                        raster.Save(outputPath, new GifOptions());
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
 * 1. When you need to convert a CorelDRAW (.cdr) file to a web‑friendly GIF while applying Floyd‑Steinberg dithering to reduce colors.
 * 2. When you must verify whether the rasterized image retains an alpha channel before further processing or compositing.
 * 3. When you are generating low‑size static GIFs from vector graphics for email newsletters or legacy browsers.
 * 4. When you want to automate batch conversion of CDR files to GIF with consistent page dimensions and no smoothing.
 * 5. When you need to integrate Aspose.Imaging into a C# service that prepares print‑ready assets by rasterizing vector files and checking transparency.
 */
