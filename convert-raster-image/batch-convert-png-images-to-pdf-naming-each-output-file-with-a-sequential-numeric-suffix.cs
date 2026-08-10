// HOW-TO: Batch Convert PNG Files to Sequentially Named PDF Documents in C# (Aspose.Imaging for .NET)
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
            // Hard‑coded input and output directories
            string inputDirectory = @"C:\Images\Input";
            string outputDirectory = @"C:\Images\Output";

            // Ensure the output directory exists (creates parent folders if needed)
            Directory.CreateDirectory(outputDirectory);

            // Get all PNG files in the input directory
            string[] pngFiles = Directory.GetFiles(inputDirectory, "*.png");

            // Prepare PDF export options (default constructor)
            PdfOptions pdfOptions = new PdfOptions();

            int index = 1;
            foreach (string inputPath in pngFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output file path with a sequential numeric suffix
                string outputPath = Path.Combine(outputDirectory, $"output_{index}.pdf");

                // Ensure the directory for the output file exists (covers cases where outputDirectory may have subfolders)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the PNG image
                using (Image image = Image.Load(inputPath))
                {
                    // Save the image as PDF using the prepared options
                    image.Save(outputPath, pdfOptions);
                }

                index++;
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
 * 1. When you need to generate a series of PDF reports from a folder of PNG screenshots, assigning each PDF a unique numeric filename.
 * 2. When automating the archival of scanned PNG images into PDF format for easier distribution and printing, while preserving order through sequential naming.
 * 3. When creating PDF invoices from PNG logos or graphics in bulk, ensuring each file is saved with a predictable numbered name for downstream processing.
 * 4. When preparing a batch of PNG design assets for client delivery as PDFs, and you want the output files to be automatically numbered to match a checklist.
 * 5. When integrating image-to-PDF conversion into a C# backend service that processes uploaded PNG files and stores the resulting PDFs with incremental filenames for version control.
 */
