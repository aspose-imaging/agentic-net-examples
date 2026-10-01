// HOW-TO: Resize BMP, Apply Median Filter, and Convert to PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.bmp";
        string outputPath = "output.pdf";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                image.Resize(640, 480);
                image.Filter(image.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(3));

                PdfOptions pdfOptions = new PdfOptions();
                image.Save(outputPath, pdfOptions);
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
 * 1. When you need to generate a smaller, noise‑reduced PDF report from high‑resolution BMP scans of engineering drawings.
 * 2. When a web service must accept user‑uploaded BMP images, downsize them to 640×480, clean up speckles with a median filter, and return a PDF for easy viewing.
 * 3. When automating archival of legacy BMP assets, you want to standardize their dimensions, remove grain, and store them as compact PDF files.
 * 4. When creating thumbnails for a document management system, you resize BMP photos, apply a median filter to improve visual quality, and embed them in PDF thumbnails.
 * 5. When preprocessing medical BMP images before PDF export, you resize to a consistent size and apply a median filter to reduce noise for clearer diagnostic documents.
 */
