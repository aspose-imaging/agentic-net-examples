using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = @"C:\Images\Input";
            string outputDir = @"C:\Images\Output";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Get all PNG files in the input directory
            string[] pngFiles = Directory.GetFiles(inputDir, "*.png");

            foreach (string inputPath in pngFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output PDF path
                string outputPath = Path.Combine(outputDir,
                    Path.GetFileNameWithoutExtension(inputPath) + ".pdf");

                // Ensure the output directory exists (unconditional as required)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the PNG image
                using (Image image = Image.Load(inputPath))
                {
                    // Resize to 500x500 pixels
                    image.Resize(500, 500);

                    // Prepare PDF export options
                    PdfOptions pdfOptions = new PdfOptions();

                    // Save as PDF
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
 * 1. When a retailer needs to generate product catalogs by converting a batch of high‑resolution PNG product photos into uniformly sized 500×500‑pixel PDF pages for printing.
 * 2. When a medical imaging system must archive patient scans stored as PNG files, resizing them to a standard thumbnail size and saving each as an individual PDF for secure electronic health record integration.
 * 3. When a marketing agency automates the preparation of social‑media assets by taking a folder of PNG graphics, scaling them to 500×500 pixels, and exporting each as a separate PDF for client review.
 * 4. When an e‑learning platform processes instructor‑uploaded PNG diagrams, normalizes their dimensions to 500×500 pixels, and converts them to PDF files to embed consistently in course modules.
 * 5. When a government agency digitizes scanned PNG documents, resizes them for uniformity, and creates individual PDF files for compliance‑ready archival and searchable records.
 */