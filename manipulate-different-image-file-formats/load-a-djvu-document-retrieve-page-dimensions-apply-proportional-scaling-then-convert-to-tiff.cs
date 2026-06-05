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
            string inputPath = "input/sample.djvu";
            string outputPath = "output/scaled.tiff";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
            {
                int originalWidth = djvuImage.Width;
                int originalHeight = djvuImage.Height;
                Console.WriteLine($"Original size: {originalWidth}x{originalHeight}");

                int newWidth = originalWidth * 2;
                djvuImage.ResizeWidthProportionally(newWidth, ResizeType.NearestNeighbourResample);

                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                djvuImage.Save(outputPath, tiffOptions);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a digital archiving system needs to ingest high‑resolution DjVu scans, double their size while preserving aspect ratio, and store the result as a TIFF for compatibility with downstream document management tools.
 * 2. When a publishing workflow requires converting multi‑page DjVu manuscripts into lossless TIFF images for print‑ready PDFs, and the images must be upscaled to meet minimum pixel dimensions.
 * 3. When a legal e‑discovery platform must extract page dimensions from DjVu evidence files, enlarge them proportionally for better readability, and save them as TIFFs for court‑approved submission.
 * 4. When a medical imaging application receives scanned DjVu reports, needs to increase their resolution for detailed analysis, and then converts them to TIFF to integrate with existing PACS systems.
 * 5. When a GIS (geographic information system) processes DjVu map tiles, scales them uniformly to match higher‑resolution basemaps, and outputs TIFF files for use in GIS software that does not support DjVu.
 */