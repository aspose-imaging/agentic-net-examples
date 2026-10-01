// HOW-TO: Batch Sharpen Raster Images and Save as PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = "input";
            string outputFolder = "output";

            Directory.CreateDirectory(outputFolder);

            string[] files = Directory.GetFiles(inputFolder);
            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + ".pdf");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    RasterImage raster = image as RasterImage;
                    if (raster == null)
                    {
                        Console.Error.WriteLine($"Not a raster image: {inputPath}");
                        continue;
                    }

                    raster.Filter(raster.Bounds, new SharpenFilterOptions());

                    PdfOptions pdfOptions = new PdfOptions();
                    image.Save(outputPath, pdfOptions);
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
 * 1. When you need to improve the clarity of a large set of scanned photos before archiving them as searchable PDFs.
 * 2. When an e‑commerce platform must automatically enhance product pictures and deliver them to customers in PDF catalogs.
 * 3. When a medical imaging workflow requires batch sharpening of radiology scans and conversion to PDF for electronic health records.
 * 4. When a publishing system has to process thousands of bitmap illustrations, apply a sharpening filter, and bundle each into a PDF for print‑ready proofs.
 * 5. When a document management solution must convert mixed‑format raster files to PDFs while applying a filter to compensate for low‑resolution scans.
 */
