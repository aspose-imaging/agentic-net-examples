// HOW-TO: Deskew CDR Image, Apply Gaussian Blur, Save as TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.cdr";
        string outputPath = "output.tif";

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
                        raster.NormalizeAngle(false, Color.White);

                        var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions
                        {
                            Radius = 5,
                            Sigma = 1.5f
                        };
                        raster.Filter(raster.Bounds, blurOptions);

                        var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                        raster.Save(outputPath, tiffOptions);
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
 * 1. When a developer needs to correct the rotation of a CorelDRAW (CDR) file and then create a blurred version for a print‑ready TIFF archive.
 * 2. When converting legacy CDR artwork to TIFF for OCR processing while smoothing edges with a Gaussian blur.
 * 3. When generating preview thumbnails of vector drawings where the image must be deskewed and blurred before being saved as a high‑resolution TIFF.
 * 4. When preparing CDR graphics for a document workflow that requires a normalized orientation and a soft‑focus effect in TIFF format.
 * 5. When building an automated pipeline that ingests CDR files, removes skew, applies a blur filter, and stores the result as a TIFF for downstream imaging applications.
 */
