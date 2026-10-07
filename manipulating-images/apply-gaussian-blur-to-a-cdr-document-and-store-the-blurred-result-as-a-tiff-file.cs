// HOW-TO: Convert CorelDRAW CDR to TIFF Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.cdr";
        string outputPath = "output.tiff";

        try
        {
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
 * 1. When you need to programmatically convert a CorelDRAW CDR file into a high‑resolution TIFF for printing or archival purposes using Aspose.Imaging in C#.
 * 2. When an application must rasterize vector CDR pages to a lossless PNG in memory before further processing or format conversion.
 * 3. When you want to automate the creation of TIFF images from CDR documents without writing intermediate files to disk.
 * 4. When integrating a workflow that extracts vector graphics from CorelDRAW files and stores them as TIFFs for compatibility with legacy imaging systems.
 * 5. When you need to ensure the output TIFF preserves the original CDR dimensions and quality by using Aspose.Imaging’s rasterization options in a .NET environment.
 */
