// HOW-TO: Flip CDR Image Horizontally and Save as LZW Compressed TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.cdr";
            string outputPath = "output/output.tif";

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
                    cdr.Save(ms, new PngOptions
                    {
                        VectorRasterizationOptions = new CdrRasterizationOptions
                        {
                            PageWidth = cdr.Width,
                            PageHeight = cdr.Height
                        }
                    });
                    ms.Position = 0;

                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        raster.RotateFlip(RotateFlipType.RotateNoneFlipX);

                        TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.TiffLzwRgb);
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
 * 1. When you need to convert a CorelDRAW (.cdr) file to a lossless TIFF for archival while mirroring the image horizontally.
 * 2. When an application must generate LZW‑compressed TIFFs from vector CDR graphics for faster web delivery.
 * 3. When a batch process has to flip CDR pages before storing them in a TIFF format compatible with legacy printing systems.
 * 4. When you want to rasterize a CDR drawing to PNG in memory, apply a flip, and then output a compressed TIFF without creating intermediate files on disk.
 * 5. When integrating Aspose.Imaging into a C# workflow to transform vector designs into TIFFs with LZW compression for efficient storage.
 */
