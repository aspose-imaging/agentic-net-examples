// HOW-TO: Flip DjVu Pages Horizontally and Convert to TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.djvu";
            string outputPath = "output\\output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                foreach (var page in djvu.Pages)
                {
                    page.RotateFlip(RotateFlipType.RotateNoneFlipX);
                }

                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
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
 * 1. When you need to prepare scanned DjVu documents for printing by mirroring each page and saving them as a multi‑page TIFF file.
 * 2. When a workflow requires converting archived DjVu files into TIFF format while applying a horizontal flip to correct page orientation.
 * 3. When integrating document processing that must transform DjVu pages for compatibility with software that only reads TIFF images.
 * 4. When automating batch conversion of DjVu manuals into TIFF for inclusion in a PDF generation pipeline, ensuring pages are flipped correctly.
 * 5. When developing a C# application that extracts DjVu pages, mirrors them, and stores the result as a single TIFF file for archival purposes.
 */
