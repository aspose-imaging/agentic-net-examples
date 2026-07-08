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
            string outputPath = "output.tiff";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DjvuImage image = (DjvuImage)Image.Load(inputPath))
            {
                int originalWidth = image.Width;
                int originalHeight = image.Height;
                Console.WriteLine($"Original size: {originalWidth}x{originalHeight}");

                int newWidth = originalWidth * 2; // proportional scaling factor of 2
                image.ResizeWidthProportionally(newWidth, ResizeType.NearestNeighbourResample);

                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                image.Save(outputPath, tiffOptions);
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
 * 1. When a developer needs to convert legacy DjVu documents into high‑resolution TIFF files for OCR or archival purposes, they can load the DjVu, double its dimensions proportionally, and save the result as a TIFF.
 * 2. When a publishing workflow requires enlarging DjVu pages to meet print‑ready specifications before exporting them as lossless TIFF images, this C# code provides the necessary proportional scaling and format conversion.
 * 3. When an e‑learning platform must generate larger preview images from compact DjVu lecture notes for responsive web display, the developer can retrieve the original size, apply proportional scaling, and output TIFF thumbnails.
 * 4. When a digital preservation system has to migrate DjVu files to a widely supported TIFF format while preserving aspect ratio, the snippet demonstrates how to resize width proportionally and save with Aspose.Imaging.
 * 5. When a medical imaging application needs to import DjVu scans, increase their resolution for detailed analysis, and store the result as a TIFF file compatible with downstream processing pipelines, this code handles the loading, scaling, and saving steps.
 */