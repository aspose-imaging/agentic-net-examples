// HOW-TO: Increase Brightness of Multiple CDR Files and Merge into Multi‑Page TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] inputPaths = new string[] { "input1.cdr", "input2.cdr", "input3.cdr" };
            string outputPath = "output.tif";

            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir);

            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            TiffImage tiffImage = null;

            foreach (string inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

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
                            raster.AdjustBrightness(50);
                            if (!raster.IsCached) raster.CacheData();

                            if (tiffImage == null)
                            {
                                tiffImage = (TiffImage)Image.Create(tiffOptions, raster.Width, raster.Height);
                                tiffImage.ActiveFrame.SavePixels(tiffImage.ActiveFrame.Bounds, raster.LoadPixels(raster.Bounds));
                            }
                            else
                            {
                                TiffFrame frame = new TiffFrame(tiffOptions, raster.Width, raster.Height);
                                frame.SavePixels(frame.Bounds, raster.LoadPixels(raster.Bounds));
                                tiffImage.AddPage(frame);
                            }
                        }
                    }
                }
            }

            if (tiffImage != null)
            {
                using (tiffImage)
                {
                    tiffImage.Save(outputPath);
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
 * 1. When a designer needs to batch‑adjust the brightness of several CorelDRAW (CDR) illustrations before archiving them as a single multipage TIFF document.
 * 2. When an automated workflow must convert CDR pages to raster images, enhance their visibility, and store the results in a searchable TIFF for printing or OCR.
 * 3. When a web service receives multiple CDR uploads, applies a uniform brightness boost, and returns a combined TIFF for easy preview or download.
 * 4. When a legacy system requires all CDR assets to be pre‑processed with increased brightness and packaged into one TIFF file for batch processing in a document management system.
 * 5. When a reporting tool needs to generate a multi‑page TIFF report from several brightened CDR charts to embed in PDFs or PowerPoint presentations.
 */
