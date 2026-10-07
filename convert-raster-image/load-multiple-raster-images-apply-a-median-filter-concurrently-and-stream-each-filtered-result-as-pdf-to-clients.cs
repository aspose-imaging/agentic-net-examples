// HOW-TO: Apply Median Filter to Multiple Images and Save as PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Threading.Tasks;
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

            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            Parallel.ForEach(files, inputPath =>
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".pdf");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (RasterImage raster = (RasterImage)Image.Load(inputPath))
                {
                    raster.Filter(raster.Bounds, new MedianFilterOptions(3));

                    using (PdfOptions pdfOptions = new PdfOptions())
                    {
                        raster.Save(outputPath, pdfOptions);
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
 * 1. When you need to denoise a batch of scanned photos and deliver each cleaned version as a PDF to a web client.
 * 2. When an automated service must process uploaded JPEG or PNG files, apply a median filter to reduce noise, and stream the results as PDFs without blocking the main thread.
 * 3. When a document management system requires converting multiple raster images into searchable PDFs while applying a median filter to improve visual quality.
 * 4. When you want to parallelize image preprocessing in a C# backend, applying a 3×3 median filter to each image before saving it as a PDF for archival.
 * 5. When a cloud API receives various image formats, needs to filter out speckles, and must return each processed image in PDF format using Aspose.Imaging.
 */
