// HOW-TO: Adjust Gamma of Multiple CDR Files and Merge into Multi‑Page TIFF in C# (Aspose.Imaging for .NET)
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
            string[] inputPaths = { "input1.cdr", "input2.cdr", "input3.cdr" };
            string outputPath = "output.tif";

            foreach (var inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            string outDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(outDir))
            {
                Directory.CreateDirectory(outDir);
            }

            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            TiffImage tiffImage = null;
            float gammaValue = 1.2f;

            for (int i = 0; i < inputPaths.Length; i++)
            {
                string inputPath = inputPaths[i];

                using (var cdr = (CdrImage)Image.Load(inputPath))
                {
                    using (var ms = new MemoryStream())
                    {
                        var pngOptions = new PngOptions
                        {
                            VectorRasterizationOptions = new VectorRasterizationOptions
                            {
                                PageWidth = cdr.Width,
                                PageHeight = cdr.Height
                            }
                        };
                        cdr.Save(ms, pngOptions);
                        ms.Position = 0;

                        using (var raster = (RasterImage)Image.Load(ms))
                        {
                            raster.AdjustGamma(gammaValue);
                            if (!raster.IsCached) raster.CacheData();

                            int width = raster.Width;
                            int height = raster.Height;

                            if (i == 0)
                            {
                                tiffImage = (TiffImage)Image.Create(tiffOptions, width, height);
                            }
                            else
                            {
                                tiffImage.AddFrame(new TiffFrame(tiffOptions, width, height));
                            }

                            var frame = tiffImage.Frames[i];
                            frame.SavePixels(frame.Bounds, raster.LoadPixels(raster.Bounds));
                        }
                    }
                }
            }

            tiffImage.Save(outputPath);
            tiffImage.Dispose();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to correct the brightness of several CorelDRAW (CDR) drawings before creating a single multi‑page TIFF document for printing.
 * 2. When an application must batch‑process CDR files, apply a gamma correction, and combine the results into a TIFF for archival or PDF conversion.
 * 3. When a workflow requires converting vector CDR pages to raster PNG, adjusting gamma, and merging them into a multi‑page TIFF for use in document management systems.
 * 4. When you want to automate the preparation of CDR artwork for a publishing pipeline, ensuring consistent gamma across pages and outputting a single TIFF file.
 * 5. When a developer needs to validate the existence of input CDR files, apply image‑level gamma adjustment, and generate a combined TIFF without manually opening each file.
 */
