// HOW-TO: Apply Gaussian Blur to Scanned JPEG Before OCR in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input\\scanned.jpg";
        string outputPath = "output\\blurred.jpg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = image as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("The loaded image is not a raster image.");
                    return;
                }

                var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.0);
                raster.Filter(raster.Bounds, blurOptions);
                raster.Save(outputPath);
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
 * 1. When you need to reduce noise in scanned JPEG receipts before feeding them to an OCR engine, you can use this code to apply a Gaussian blur filter with Aspose.Imaging in C#.
 * 2. When processing batches of scanned TIFF or PNG forms, applying a Gaussian blur smooths uneven lighting and improves text recognition accuracy.
 * 3. When preparing historical handwritten documents for digitization, a Gaussian blur helps soften paper grain, making OCR results more reliable.
 * 4. When building a document‑processing pipeline that extracts data from photographed invoices, this code pre‑processes the images to enhance OCR performance.
 * 5. When developing a mobile app that captures and uploads scanned images for text extraction, you can blur the images server‑side to improve OCR consistency.
 */
