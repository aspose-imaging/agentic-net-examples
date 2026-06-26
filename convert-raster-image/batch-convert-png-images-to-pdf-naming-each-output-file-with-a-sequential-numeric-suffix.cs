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
            string inputDirectory = @"C:\Images\Input";
            string outputDirectory = @"C:\Images\Output";

            // Get all PNG files in the input directory
            string[] pngFiles = Directory.GetFiles(inputDirectory, "*.png");

            int index = 1;
            foreach (string inputPath in pngFiles)
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output PDF file path with a sequential numeric suffix
                string outputPath = Path.Combine(outputDirectory, $"output_{index}.pdf");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the PNG image
                using (Image image = Image.Load(inputPath))
                {
                    // Set up PDF export options
                    var pdfOptions = new PdfOptions();

                    // Save the image as PDF
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
 * 1. When a developer needs to generate a printable PDF catalog from a folder of product PNG images, assigning each page a sequential file name.
 * 2. When an automated reporting system must archive daily screenshot PNGs as PDF documents with numeric suffixes for easy chronological sorting.
 * 3. When a document management workflow requires converting scanned PNG receipts into PDF files named in order to match accounting entry numbers.
 * 4. When a web application processes user‑uploaded PNG avatars in bulk and stores them as PDF files with incremental filenames for batch processing downstream.
 * 5. When a migration script moves legacy PNG assets into a PDF archive, creating sequentially numbered PDFs to preserve the original order for compliance audits.
 */