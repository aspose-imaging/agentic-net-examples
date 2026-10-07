// HOW-TO: Apply Floyd Steinberg Dithering to CDR and Save as TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.cdr";
        string outputPath = "output.tiff";

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
                        raster.Dither(DitheringMethod.FloydSteinbergDithering, 8);
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
 * 1. When you need to convert a CorelDRAW (.cdr) file to a high‑contrast black‑and‑white TIFF for printing or archival, applying Floyd‑Steinberg dithering to preserve detail.
 * 2. When a batch process must rasterize vector CDR pages to PNG in memory before applying dithering and exporting to TIFF for compatibility with legacy imaging systems.
 * 3. When you want to reduce file size while maintaining visual quality by dithering a CDR image before saving it as a TIFF for use in document management workflows.
 * 4. When an application requires converting CDR graphics to a TIFF format that can be processed by OCR engines, using dithering to improve text legibility.
 * 5. When you need to programmatically handle missing CDR files gracefully and generate a dithered TIFF output only after successful rasterization in a C# .NET environment.
 */
