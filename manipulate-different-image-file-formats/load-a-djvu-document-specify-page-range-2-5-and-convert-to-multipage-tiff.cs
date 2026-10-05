// HOW-TO: Convert DjVu Pages 2 To 5 To Multipage TIFF In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input\\document.djvu";
            string outputPath = "output\\range2-5.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.TiffLzwRgb);
                tiffOptions.MultiPageOptions = new DjvuMultiPageOptions(new IntRange(2, 5));
                djvu.Save(outputPath, tiffOptions);
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
 * 1. When you need to extract a specific range of pages from a DjVu archive and save them as a single multipage TIFF for archival or printing.
 * 2. When a document management system must convert selected DjVu pages (e.g., pages 2‑5) into a compressed LZW RGB TIFF to reduce file size while preserving image quality.
 * 3. When generating preview images for a web application that only requires a subset of DjVu pages, converting them into a TIFF that browsers can display without plugins.
 * 4. When automating batch processing of DjVu manuals, converting only the relevant chapters (pages 2‑5) into a multipage TIFF for inclusion in a PDF compilation.
 * 5. When integrating Aspose.Imaging into a C# workflow to programmatically convert DjVu page ranges into TIFF for downstream OCR or image analysis pipelines.
 */
