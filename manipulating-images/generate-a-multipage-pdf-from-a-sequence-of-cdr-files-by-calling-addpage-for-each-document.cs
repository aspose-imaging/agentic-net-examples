// HOW-TO: Create Multi‑Page PDF from Multiple CDR Files in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath1 = @"C:\input1.cdr";
            string inputPath2 = @"C:\input2.cdr";
            string outputPath = @"C:\output\merged.pdf";

            if (!File.Exists(inputPath1))
            {
                Console.Error.WriteLine($"File not found: {inputPath1}");
                return;
            }
            if (!File.Exists(inputPath2))
            {
                Console.Error.WriteLine($"File not found: {inputPath2}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            List<RasterImage> rasterImages = new List<RasterImage>();

            using (CdrImage cdr1 = (CdrImage)Image.Load(inputPath1))
            {
                using (MemoryStream ms1 = new MemoryStream())
                {
                    cdr1.Save(ms1, new PngOptions
                    {
                        VectorRasterizationOptions = new CdrRasterizationOptions
                        {
                            PageWidth = cdr1.Width,
                            PageHeight = cdr1.Height
                        }
                    });
                    ms1.Position = 0;
                    RasterImage raster1 = (RasterImage)Image.Load(ms1);
                    rasterImages.Add(raster1);
                }
            }

            using (CdrImage cdr2 = (CdrImage)Image.Load(inputPath2))
            {
                using (MemoryStream ms2 = new MemoryStream())
                {
                    cdr2.Save(ms2, new PngOptions
                    {
                        VectorRasterizationOptions = new CdrRasterizationOptions
                        {
                            PageWidth = cdr2.Width,
                            PageHeight = cdr2.Height
                        }
                    });
                    ms2.Position = 0;
                    RasterImage raster2 = (RasterImage)Image.Load(ms2);
                    rasterImages.Add(raster2);
                }
            }

            using (Image multi = Image.Create(rasterImages.ToArray(), true))
            {
                multi.Save(outputPath, new PdfOptions());
            }

            foreach (var raster in rasterImages)
            {
                raster.Dispose();
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
 * 1. When you need to combine several CorelDRAW (.cdr) drawings into a single searchable PDF for client delivery.
 * 2. When an automated reporting system must convert vector CDR pages to raster PNGs before merging them into a PDF document.
 * 3. When a batch‑processing tool has to validate the existence of input CDR files and create the output folder dynamically.
 * 4. When you want to preserve the original dimensions of each CDR page while rasterizing them for PDF pagination.
 * 5. When integrating Aspose.Imaging into a C# application to generate a multipage PDF without using external command‑line tools.
 */
