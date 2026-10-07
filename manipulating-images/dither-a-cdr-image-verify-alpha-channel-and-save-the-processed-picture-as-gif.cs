// HOW-TO: Dither CDR Image, Check Alpha Channel, and Save as GIF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.cdr";
            string outputPath = "output\\output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    PngOptions pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = new CdrRasterizationOptions
                        {
                            PageWidth = cdr.Width,
                            PageHeight = cdr.Height
                        }
                    };
                    cdr.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        raster.Dither(DitheringMethod.FloydSteinbergDithering, 8);
                        bool hasAlpha = raster.HasAlpha;
                        Console.WriteLine($"Alpha channel present: {hasAlpha}");
                        GifOptions gifOptions = new GifOptions();
                        raster.Save(outputPath, gifOptions);
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
 * 1. When converting a CorelDRAW (CDR) illustration to a web‑friendly GIF while preserving visual quality through Floyd‑Steinberg dithering.
 * 2. When you need to determine whether a rasterized CDR page contains transparency before deciding on a suitable output format.
 * 3. When an application must batch‑process CDR files, rasterize them to PNG, apply dithering, and store the results as GIF images.
 * 4. When integrating Aspose.Imaging into a C# service that validates the presence of an alpha channel in imported vector graphics.
 * 5. When generating low‑color GIF assets from high‑resolution CDR designs for email newsletters or legacy systems.
 */
