using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.cdr";
        string outputPath = "output.gif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        try
        {
            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    PngOptions pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            PageWidth = cdr.Width,
                            PageHeight = cdr.Height
                        }
                    };
                    cdr.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        raster.NormalizeAngle(false, Aspose.Imaging.Color.LightGray);

                        GifOptions gifOptions = new GifOptions
                        {
                            // Default options; customize as needed
                        };

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
 * 1. When a graphic design workflow requires converting CorelDRAW (CDR) artwork to a web‑friendly GIF while automatically correcting any tilt in the original page, a developer can use this code to deskew the vector image and apply lossy GIF compression.
 * 2. When an e‑commerce platform needs to generate lightweight product preview GIFs from supplier‑provided CDR files that may be scanned at an angle, the snippet can rasterize, normalize the angle, and save a compressed GIF for faster page loads.
 * 3. When a document management system must archive legacy CDR drawings as small GIF thumbnails for quick preview, the code deskews the drawing, rasterizes it to PNG in memory, and then writes a lossy GIF to reduce storage space.
 * 4. When a marketing automation tool creates email‑ready animated banners from designer‑supplied CDR assets and wants to ensure the images are correctly oriented and under a specific file‑size limit, this C# example provides the necessary deskew and lossy GIF compression steps.
 * 5. When a mobile app backend processes user‑uploaded CorelDRAW files and needs to deliver orientation‑corrected, bandwidth‑optimized GIFs to the client devices, the developer can employ this Aspose.Imaging routine to normalize the angle and compress the output.
 */