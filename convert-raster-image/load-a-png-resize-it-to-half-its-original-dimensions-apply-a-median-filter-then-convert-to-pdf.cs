using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.png";
        string outputPath = "Output/result.pdf";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (PngImage png = (PngImage)Image.Load(inputPath))
            {
                png.Resize(png.Width / 2, png.Height / 2);
                png.Filter(png.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(5));

                var pdfOptions = new PdfOptions();
                png.Save(outputPath, pdfOptions);
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
 * 1. When a developer needs to generate a smaller, noise‑reduced PDF preview from a high‑resolution PNG uploaded by users.
 * 2. When an e‑commerce platform must automatically shrink product photos and embed them in PDF catalogs while removing speckle noise.
 * 3. When a document management system converts scanned PNG images to PDF, scaling them to half size to save storage and applying a median filter to improve readability.
 * 4. When a reporting tool creates PDF reports that include PNG charts, resizing them for layout consistency and smoothing pixel artifacts with a median filter.
 * 5. When a mobile app backend processes user‑submitted PNG screenshots, reduces their dimensions, cleans up noise, and stores them as PDF files for archival.
 */