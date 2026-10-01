// HOW-TO: Resize PNG to 1024x1024, Apply Median Filter and Save as PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output/output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                image.Resize(1024, 1024);

                var medianOptions = new MedianFilterOptions(3);
                image.Filter(image.Bounds, medianOptions);

                var pdfOptions = new PdfOptions();
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
 * 1. When you need to archive high‑resolution PNG screenshots as compact PDF files after noise reduction.
 * 2. When a document management system requires all images to be standardized to 1024 × 1024 pixels and stored in PDF for consistent viewing.
 * 3. When preparing product catalog images for printing, you may resize, denoise with a median filter, and convert them to PDF for the layout software.
 * 4. When an automated pipeline processes user‑uploaded PNGs, applying a median filter to remove artifacts before saving them as searchable PDFs.
 * 5. When creating legal evidence bundles, you might normalize image size, clean visual noise, and embed the result in a PDF for secure archival.
 */
