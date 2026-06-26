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
            string inputDirectory = @"C:\InputBmp";
            string outputDirectory = @"C:\OutputPdf";

            // Get all BMP files in the input directory
            string[] bmpFiles = Directory.GetFiles(inputDirectory, "*.bmp");

            // Process each BMP file
            for (int i = 0; i < bmpFiles.Length; i++)
            {
                string inputPath = bmpFiles[i];

                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output PDF path with a sequential numeric suffix (starting at 1)
                string outputPath = Path.Combine(outputDirectory, $"{i + 1}.pdf");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the BMP image
                using (Image image = Image.Load(inputPath))
                {
                    // Set up PDF export options
                    PdfOptions pdfOptions = new PdfOptions();

                    // Save the image as PDF
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
 * 1. When a developer needs to archive a collection of scanned BMP documents as PDF files with simple numeric filenames for easy indexing, they can use this code.
 * 2. When an automated build pipeline must convert legacy BMP assets into PDF reports for compliance documentation, the batch conversion with sequential naming streamlines the process.
 * 3. When a desktop application must generate printable PDFs from user‑uploaded BMP images and store them in a folder with ordered numeric names, this snippet provides the required image processing logic.
 * 4. When a migration script has to transform a directory of BMP graphics into PDF format for a content‑management system while preserving order through sequential file names, the code handles the conversion efficiently.
 * 5. When a scheduled Windows service needs to process incoming BMP files, convert each to PDF, and save them with incremental numeric suffixes for downstream processing, this example demonstrates the necessary C# and Aspose.Imaging workflow.
 */