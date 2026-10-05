// HOW-TO: Crop CorelDRAW File to 200x200 and Save as GIF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Png;

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

            using (Aspose.Imaging.FileFormats.Cdr.CdrImage cdr = (Aspose.Imaging.FileFormats.Cdr.CdrImage)Image.Load(inputPath))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = new SvgRasterizationOptions
                        {
                            PageWidth = cdr.Width,
                            PageHeight = cdr.Height
                        }
                    };
                    cdr.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        if (!raster.IsCached)
                            raster.CacheData();

                        var cropRect = new Rectangle(0, 0, 200, 200);
                        raster.Crop(cropRect);

                        var gifOptions = new GifOptions();
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
 * 1. When you need to generate a small thumbnail GIF from a large CorelDRAW illustration for web previews.
 * 2. When an automated pipeline must extract a fixed‑size region from a CDR design and convert it to an animated‑compatible GIF format.
 * 3. When a reporting tool requires a 200 × 200 GIF snapshot of a vector drawing to embed in PDF or email.
 * 4. When migrating legacy CDR assets to a web‑friendly format while ensuring the image fits a specific UI component size.
 * 5. When creating batch scripts that process multiple CorelDRAW files, crop a defined area, and output GIFs for use in mobile applications.
 */
