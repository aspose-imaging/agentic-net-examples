// HOW-TO: Combine CDR and TIFF Files into a Multi‑Page PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string cdrPath = "Input\\sample.cdr";
            string tiffPath = "Input\\sample.tif";
            string outputPath = "Output\\combined.pdf";

            if (!File.Exists(cdrPath))
            {
                Console.Error.WriteLine($"File not found: {cdrPath}");
                return;
            }

            if (!File.Exists(tiffPath))
            {
                Console.Error.WriteLine($"File not found: {tiffPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            var images = new List<Image>();

            Image cdrImage = Image.Load(cdrPath);
            Image tiffImage = Image.Load(tiffPath);
            images.Add(cdrImage);
            images.Add(tiffImage);

            using (Image result = Image.Create(images.ToArray(), true))
            {
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    result.Save(outputPath, pdfOptions);
                }
            }

            cdrImage.Dispose();
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
 * 1. When you need to merge a CorelDRAW illustration and a scanned TIFF page into a single PDF report for client delivery.
 * 2. When an automated document generation system must combine vector graphics (CDR) with raster scans (TIFF) into a multipage PDF without manual conversion.
 * 3. When a C# application has to create a printable PDF booklet that includes both design assets and high‑resolution scanned images.
 * 4. When integrating legacy CorelDRAW files with existing TIFF archives to produce a consolidated PDF for archiving or compliance purposes.
 * 5. When building a batch processing tool that consolidates mixed‑format source files into a single PDF using Aspose.Imaging’s IMultipageImage support.
 */
