// HOW-TO: Convert JPEG to PDF and Verify Output File Exists in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.jpg";
            string outputPath = "Output/output.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image and convert to PDF
            using (Image image = Image.Load(inputPath))
            {
                var pdfOptions = new PdfOptions();
                image.Save(outputPath, pdfOptions);
            }

            // Verify that the PDF was created
            if (File.Exists(outputPath))
            {
                Console.WriteLine($"PDF file successfully created: {outputPath}");
            }
            else
            {
                Console.Error.WriteLine($"Failed to create PDF file: {outputPath}");
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
 * 1. When you need to generate a PDF report from a user‑uploaded JPEG image and confirm the file was created successfully.
 * 2. When automating batch processing of product photos to PDF for archival while ensuring each conversion succeeds.
 * 3. When integrating image‑to‑PDF conversion into a web service that must return an error if the PDF file is missing.
 * 4. When building a desktop utility that converts scanned JPEG documents to PDF and validates the output before further processing.
 * 5. When creating a scheduled task that transforms marketing JPEG assets into PDFs and logs any conversion failures.
 */
