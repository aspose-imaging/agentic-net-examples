// HOW-TO: Apply Median Filter to BMP and Save as PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.bmp";
            string outputPath = "Output\\result.pdf";

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
                    Console.Error.WriteLine("Loaded image is not a raster image.");
                    return;
                }

                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(3));

                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    raster.Save(outputPath, pdfOptions);
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
 * 1. When you need to reduce noise in a scanned BMP document before converting it to a searchable PDF.
 * 2. When a legacy system outputs BMP images that must be filtered and bundled as PDF reports in a .NET application.
 * 3. When preparing medical imaging BMP files for archival, applying a median filter to smooth artifacts and saving them as PDF for compliance.
 * 4. When generating printable PDFs from BMP graphics while preserving image quality by removing speckle noise with a median filter.
 * 5. When automating batch processing of BMP assets, applying noise reduction and exporting the results directly to PDF using C# and Aspose.Imaging.
 */
