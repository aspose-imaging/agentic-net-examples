// HOW-TO: Apply Median Filter to Multiple BMPs and Convert to PDF in Parallel C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
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

            string[] files = Directory.GetFiles(inputDirectory, "*.bmp");

            files.AsParallel().ForAll(inputPath =>
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                using (Image image = Image.Load(inputPath))
                {
                    RasterImage raster = image as RasterImage;
                    if (raster == null)
                    {
                        return;
                    }

                    // Apply median filter with size 3
                    var medianOptions = new MedianFilterOptions(3);
                    raster.Filter(raster.Bounds, medianOptions);

                    // Prepare output PDF path
                    string fileName = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputDirectory, fileName + ".pdf");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save to PDF file
                    using (PdfOptions pdfOptions = new PdfOptions())
                    {
                        raster.Save(outputPath, pdfOptions);
                    }

                    // Stream PDF to client (simulated by writing to a MemoryStream)
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (PdfOptions pdfOptions = new PdfOptions())
                        {
                            raster.Save(ms, pdfOptions);
                        }
                        Console.WriteLine($"Streamed PDF for {fileName}: {ms.Length} bytes");
                    }
                }
            });
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to clean up noisy BMP scans before sending them as PDFs to a web client.
 * 2. When a server must process a batch of BMP images concurrently to reduce latency in a high‑traffic application.
 * 3. When you want to apply a median filter to remove salt‑and‑pepper noise from medical or engineering BMP files before archiving them as PDFs.
 * 4. When an ASP.NET service streams filtered PDF documents on‑the‑fly to browsers without storing intermediate files.
 * 5. When you need to automate conversion of legacy BMP assets into searchable PDF reports while preserving image quality.
 */
