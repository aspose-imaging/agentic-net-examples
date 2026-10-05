// HOW-TO: Increase TIFF Image Contrast by 30 Percent and Save as PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = Path.Combine("Input", "sample.tif");
        string outputPath = Path.Combine("Output", "result.pdf");
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
                RasterImage raster = (RasterImage)image;
                raster.AdjustContrast(30f);
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
 * 1. When you need to enhance the readability of scanned TIFF documents before distributing them as PDF reports.
 * 2. When a batch process must boost the contrast of medical imaging TIFF files and archive them in PDF format for electronic health records.
 * 3. When an application converts high‑resolution TIFF photographs to PDF while applying a 30 % contrast increase to improve visual impact.
 * 4. When a document management system requires on‑the‑fly contrast correction of uploaded TIFF files before saving them as searchable PDFs.
 * 5. When a developer wants to use Aspose.Imaging in C# to programmatically adjust TIFF image contrast and generate PDF outputs for printing.
 */
