using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input and output directories
            string inputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Input");
            string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Output");

            // Get all PSD files in the input directory
            string[] psdFiles = Directory.GetFiles(inputDirectory, "*.psd");

            foreach (string inputPath in psdFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output path with .pdf extension
                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".pdf");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load PSD image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage for adjustment
                    RasterImage raster = (RasterImage)image;
                    if (!raster.IsCached)
                    {
                        raster.CacheData();
                    }

                    // Apply contrast enhancement (example value: 30)
                    raster.AdjustContrast(30f);

                    // Save as PDF
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
 * 1. When a design studio needs to batch‑process client PSD mockups, boost their contrast for better print quality, and deliver the results as PDF portfolios.
 * 2. When an e‑learning platform converts layered Photoshop course slides into high‑contrast PDFs for clearer on‑screen viewing.
 * 3. When a marketing team automates the preparation of product catalog pages stored as PSD files, enhancing contrast to meet brand guidelines before exporting to PDF for distribution.
 * 4. When a legal firm archives scanned PSD documents, applies contrast adjustment to improve legibility, and stores them as searchable PDF files.
 * 5. When a photography workflow tool processes PSD files from a shoot, increases contrast to highlight details, and saves each image as a PDF for client review.
 */