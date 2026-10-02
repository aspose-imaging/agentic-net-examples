// HOW-TO: Increase Brightness of CDR by 15% and Save as TIFF in C# (Aspose.Imaging for .NET)
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
        try
        {
            string inputPath = "input.cdr";
            string outputPath = "output\\result.tiff";

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
                        raster.AdjustBrightness(38);
                        TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
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
 * 1. When a designer needs to brighten a CorelDRAW (CDR) illustration by about 15% before converting it to a high‑resolution TIFF for printing.
 * 2. When an automated workflow must rasterize vector CDR pages, adjust their exposure, and store the results as lossless TIFF files for archival.
 * 3. When a .NET application processes batch CDR assets, applies a uniform brightness boost, and outputs TIFFs compatible with downstream image‑processing pipelines.
 * 4. When a publishing system requires converting brightened CDR graphics to TIFF to embed them in PDFs or e‑books while preserving quality.
 * 5. When a developer wants to use Aspose.Imaging to programmatically increase the luminance of a CDR file and save the enhanced image in TIFF format for further analysis.
 */
