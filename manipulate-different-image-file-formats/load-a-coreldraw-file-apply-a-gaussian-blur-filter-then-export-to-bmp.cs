// HOW-TO: Apply Gaussian Blur to CorelDRAW and Export as BMP in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.cdr";
        string outputPath = "output.bmp";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    var pngOptions = new PngOptions
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
                        var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions();
                        blurOptions.Radius = 5;
                        blurOptions.Sigma = 1.0f;

                        raster.Filter(raster.Bounds, blurOptions);

                        var bmpOptions = new BmpOptions();
                        raster.Save(outputPath, bmpOptions);
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
 * 1. When you need to programmatically soften vector artwork from a .cdr file before converting it to a bitmap for use in legacy Windows applications.
 * 2. When an automated pipeline must batch‑process CorelDRAW designs, apply a blur effect, and generate BMP assets for printing or archival.
 * 3. When a web service receives CDR uploads, applies a Gaussian blur for privacy masking, and returns the result as a BMP image.
 * 4. When integrating Aspose.Imaging into a C# desktop tool that converts vector graphics to raster formats while applying custom image filters.
 * 5. When creating thumbnails with a blur background from CorelDRAW files to embed in product catalogs that require BMP format.
 */
