// HOW-TO: Dim CDR Image Brightness, Check Alpha Channel, Save as TIFF in C# (Aspose.Imaging for .NET)
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
        try
        {
            string inputPath = "input.cdr";
            string outputPath = "output/output.tiff";

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
                        // Reduce brightness
                        raster.AdjustBrightness(-50);

                        // Verify alpha channel
                        if (raster.HasAlpha)
                        {
                            Console.WriteLine("Alpha channel is present.");
                        }
                        else
                        {
                            Console.WriteLine("Alpha channel is not present.");
                        }

                        // Save as TIFF
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
 * 1. When you need to lower the brightness of a CorelDRAW (CDR) file before archiving it as a TIFF for print workflows.
 * 2. When you must confirm that a converted CDR image retains an alpha channel before further compositing.
 * 3. When an automated pipeline has to transform vector CDR pages into raster PNG, adjust lighting, and output lossless TIFF files.
 * 4. When a desktop application requires programmatic handling of CDR graphics to produce dimmed TIFF thumbnails with transparency information.
 * 5. When a server‑side service processes user‑uploaded CDR artwork, reduces its brightness, validates transparency, and stores the result in a TIFF repository.
 */
