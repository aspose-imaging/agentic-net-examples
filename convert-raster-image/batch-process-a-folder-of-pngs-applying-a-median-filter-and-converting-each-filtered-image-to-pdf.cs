// HOW-TO: Batch Apply Median Filter to PNGs and Convert to PDF in C# (Aspose.Imaging for .NET)
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
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.png");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                using (Image image = Image.Load(inputPath))
                {
                    RasterImage raster = (RasterImage)image;
                    raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(3));

                    string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".pdf");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (PdfOptions pdfOptions = new PdfOptions())
                    {
                        raster.Save(outputPath, pdfOptions);
                    }
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
 * 1. When you need to clean up a large set of scanned PNG receipts by removing noise before archiving them as searchable PDF documents.
 * 2. When you want to automatically enhance product photos stored as PNGs with a median filter and generate PDF catalogs for distribution.
 * 3. When a medical imaging workflow requires batch denoising of PNG X‑ray images and saving them as PDF reports for patient records.
 * 4. When a document management system must convert thousands of PNG screenshots into PDF files while applying a median filter to improve visual quality.
 * 5. When you are preparing PNG‑based engineering drawings for client review and need to batch‑process them with noise reduction and export to PDF in a .NET application.
 */
