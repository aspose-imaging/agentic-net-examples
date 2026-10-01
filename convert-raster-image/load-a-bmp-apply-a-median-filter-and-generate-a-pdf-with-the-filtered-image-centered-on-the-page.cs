// HOW-TO: Apply Median Filter to BMP and Save as Centered PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "image.bmp");
            string outputPath = Path.Combine("Output", "filtered.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage bmp = (RasterImage)Image.Load(inputPath))
            {
                bmp.Filter(bmp.Bounds, new MedianFilterOptions(3));

                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    bmp.Save(outputPath, pdfOptions);
                }
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
 * 1. When you need to reduce noise in a BMP scan before embedding it in a PDF report.
 * 2. When you want to generate a printable PDF where the filtered image is automatically centered on the page.
 * 3. When you are converting legacy BMP assets to PDF while applying a 3×3 median filter to improve visual quality.
 * 4. When you need to automate batch processing of BMP files, applying a median filter and creating centered PDF documents for archiving.
 * 5. When you are building a C# application that prepares images for legal documents, requiring noise reduction and PDF output with centered layout.
 */
