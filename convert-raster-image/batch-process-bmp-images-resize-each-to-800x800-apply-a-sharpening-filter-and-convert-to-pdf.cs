// HOW-TO: Batch Resize BMP Images, Sharpen, and Convert to PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
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

            string[] files = Directory.GetFiles(inputDirectory, "*.*")
                                      .Where(f => Path.GetExtension(f).Equals(".bmp", StringComparison.OrdinalIgnoreCase))
                                      .ToArray();

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                using (RasterImage raster = (RasterImage)Image.Load(inputPath))
                {
                    if (!raster.IsCached)
                        raster.CacheData();

                    raster.Resize(800, 800);
                    raster.Filter(raster.Bounds, new SharpenFilterOptions());

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
 * 1. When you need to process a folder of BMP scans, resize them to a standard 800×800 size, sharpen for better readability, and generate a PDF for each file.
 * 2. When creating a batch workflow that prepares legacy BMP assets for web publishing by normalizing dimensions, enhancing details, and converting them to PDF for easier distribution.
 * 3. When automating the conversion of large collections of BMP screenshots into compact PDF documents while ensuring consistent image size and improved clarity.
 * 4. When building a desktop utility that takes user‑uploaded BMP drawings, applies a sharpening filter, resizes them, and outputs PDF files for printing or archiving.
 * 5. When integrating an image processing step into a document management system that must standardize BMP files, enhance edges, and store them as PDFs for compliance.
 */
