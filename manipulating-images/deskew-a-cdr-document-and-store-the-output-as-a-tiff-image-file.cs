// HOW-TO: Deskew CorelDRAW CDR and Save as TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.cdr";
            string outputPath = "output.tiff";

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
                    var rasterOptions = new TiffOptions(TiffExpectedFormat.Default)
                    {
                        VectorRasterizationOptions = new CdrRasterizationOptions
                        {
                            PageWidth = cdr.Width,
                            PageHeight = cdr.Height
                        }
                    };
                    cdr.Save(ms, rasterOptions);
                    ms.Position = 0;

                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        raster.NormalizeAngle(false, Color.LightGray);
                        var saveOptions = new TiffOptions(TiffExpectedFormat.Default);
                        raster.Save(outputPath, saveOptions);
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
 * 1. When a printing workflow receives scanned CorelDRAW (CDR) files that are slightly rotated, a developer can deskew them and convert to TIFF for reliable high‑resolution printing.
 * 2. When archiving design assets, you may need to normalize the orientation of CDR pages and store them as lossless TIFF images for long‑term preservation.
 * 3. When integrating CorelDRAW drawings into a document management system that only supports TIFF, this code automatically corrects skew and performs the format conversion in C#.
 * 4. When preparing CDR artwork for OCR or image analysis, deskewing the vector file and exporting it as a raster TIFF improves recognition accuracy.
 * 5. When building a batch‑processing tool that standardizes page size and orientation of multiple CDR files before sending them to a downstream imaging pipeline, this snippet handles the rasterization, deskew, and TIFF output.
 */
