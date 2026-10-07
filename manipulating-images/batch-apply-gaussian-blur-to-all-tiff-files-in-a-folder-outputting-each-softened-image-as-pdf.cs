// HOW-TO: Apply Gaussian Blur to TIFF Images and Save as PDF in C# (Aspose.Imaging for .NET)
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

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string extension = Path.GetExtension(inputPath).ToLowerInvariant();
                if (extension != ".tif" && extension != ".tiff")
                {
                    continue;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".pdf");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    RasterImage raster = (RasterImage)image;
                    raster.Filter(raster.Bounds, new GaussianBlurFilterOptions());

                    using (PdfOptions pdfOptions = new PdfOptions())
                    {
                        image.Save(outputPath, pdfOptions);
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
 * 1. When you need to soften scanned TIFF documents before converting them into searchable PDF reports.
 * 2. When automating a workflow that processes a folder of high‑resolution TIFF maps, applying a blur filter and exporting each as a PDF for web preview.
 * 3. When creating a batch script to reduce visual noise in medical TIFF images and archive the results as PDF files.
 * 4. When building a C# service that ingests TIFF photographs, applies a Gaussian blur for privacy, and stores the output as PDFs for compliance.
 * 5. When preparing a set of TIFF engineering drawings for client delivery, applying a uniform blur effect and converting them to PDF in a single operation.
 */
