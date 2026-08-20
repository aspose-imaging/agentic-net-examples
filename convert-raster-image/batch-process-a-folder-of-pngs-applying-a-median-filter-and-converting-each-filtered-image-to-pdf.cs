// HOW-TO: Batch Apply Median Filter to PNGs and Convert to PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputFolder = @"C:\Images\Input";
            string outputFolder = @"C:\Images\Output";

            // Ensure the output root folder exists
            Directory.CreateDirectory(outputFolder);

            // Get all PNG files in the input folder
            string[] pngFiles = Directory.GetFiles(inputFolder, "*.png");

            foreach (string pngPath in pngFiles)
            {
                // Verify the input file exists
                if (!File.Exists(pngPath))
                {
                    Console.Error.WriteLine($"File not found: {pngPath}");
                    continue;
                }

                // Load the PNG image
                using (Image image = Image.Load(pngPath))
                {
                    // Cast to RasterImage to apply filters
                    RasterImage rasterImage = (RasterImage)image;

                    // Apply a median filter with size 5 to the whole image
                    rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

                    // Prepare the output PDF path
                    string outputPdfPath = Path.Combine(
                        outputFolder,
                        Path.GetFileNameWithoutExtension(pngPath) + ".pdf");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

                    // Save the filtered image as PDF
                    PdfOptions pdfOptions = new PdfOptions();
                    image.Save(outputPdfPath, pdfOptions);
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
 * 1. When you need to clean up a collection of scanned PNG documents by reducing noise before archiving them as searchable PDFs.
 * 2. When you want to automate the preparation of product images, applying a median filter to smooth edges and then generate PDF catalogs.
 * 3. When you must process a folder of PNG screenshots, remove speckles, and bundle each result into a PDF for reporting purposes.
 * 4. When a medical imaging workflow requires batch denoising of PNG scans and conversion to PDF for patient records.
 * 5. When you are building a document management system that receives PNG uploads, applies a median filter for quality, and stores them as PDF files.
 */
