// HOW-TO: Batch Convert BMP Images to PDF with Sequential Filenames in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputFolder = @"C:\InputBmp";
        string outputFolder = @"C:\OutputPdf";

        try
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(outputFolder);

            // Get all BMP files in the input folder
            string[] bmpFiles = Directory.GetFiles(inputFolder, "*.bmp");
            int index = 1;

            foreach (string inputPath in bmpFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output PDF path with a sequential numeric suffix
                string outputPath = Path.Combine(outputFolder, $"image_{index}.pdf");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the BMP image and save it as PDF
                using (Image image = Image.Load(inputPath))
                {
                    var pdfOptions = new PdfOptions();
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
 * 1. When you need to generate a series of PDF reports from a folder of scanned BMP documents, assigning each PDF a numbered name automatically.
 * 2. When an application must archive legacy BMP graphics as PDF files for easier distribution while preserving the original order.
 * 3. When a batch processing script has to convert user‑uploaded BMP images to PDF for compliance with a PDF‑only workflow, naming them sequentially.
 * 4. When you want to prepare printable PDFs from a collection of BMP screenshots, ensuring each file is saved with a unique numeric suffix.
 * 5. When integrating Aspose.Imaging into a C# service that transforms BMP assets into PDF assets for storage in a version‑controlled repository.
 */
