// HOW-TO: Create 200x200 BMP Thumbnail PDF with Median Filter in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = "input/input.bmp";
            string outputPath = "output/thumbnail.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                image.Filter(image.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(3));
                image.Resize(200, 200, ResizeType.NearestNeighbourResample);
                image.Save(outputPath, new PdfOptions());
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
 * 1. When you need to generate a small PDF preview of a high‑resolution BMP while reducing noise with a median filter.
 * 2. When an application must convert scanned BMP documents into 200 × 200 pixel thumbnails for quick display in a web portal.
 * 3. When you want to automate batch processing of BMP images to create PDF thumbnails for email attachments.
 * 4. When a reporting tool requires a noise‑reduced, resized BMP image embedded as a PDF page.
 * 5. When you are building a document management system that stores image previews as PDF files after applying image smoothing.
 */
