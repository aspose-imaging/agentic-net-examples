using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
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

            // Ensure the output directory exists (will also handle subfolders)
            Directory.CreateDirectory(outputFolder);

            // Get all TIFF files in the input folder
            var tiffFiles = Directory.GetFiles(inputFolder, "*.*", SearchOption.TopDirectoryOnly)
                                     .Where(f => f.EndsWith(".tif", StringComparison.OrdinalIgnoreCase) ||
                                                 f.EndsWith(".tiff", StringComparison.OrdinalIgnoreCase));

            foreach (var inputPath in tiffFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output PDF path (same file name, .pdf extension)
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".pdf";
                string outputPath = Path.Combine(outputFolder, outputFileName);

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the TIFF image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to TiffImage to access AdjustBrightness
                    TiffImage tiffImage = (TiffImage)image;

                    // Adjust brightness (example value: 50)
                    tiffImage.AdjustBrightness(50);

                    // Save as PDF
                    tiffImage.Save(outputPath, new PdfOptions());
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
 * 1. When a medical imaging department needs to improve the visibility of scanned X‑ray TIFF files and archive them as searchable PDF reports.
 * 2. When a publishing house wants to brighten scanned manuscript pages stored as TIFF and generate PDF proofs for editorial review.
 * 3. When a construction firm must enhance aerial survey TIFF images for better contrast before converting them to PDF for client presentations.
 * 4. When a government archive needs to batch‑process historical TIFF photographs, increase their brightness, and store the results as PDF for digital preservation.
 * 5. When an e‑commerce platform processes product catalog TIFF scans, adjusts brightness for consistent appearance, and creates PDF catalogs for distribution.
 */