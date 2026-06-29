using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Wrap the entire logic in a try-catch to handle unexpected errors gracefully.
        try
        {
            // Hardcoded input and output directories.
            string inputFolder = @"C:\InputWebP";
            string outputFolder = @"C:\OutputPDF";

            // Ensure the output directory exists (creates it if missing).
            Directory.CreateDirectory(outputFolder);

            // Get all WebP files in the input folder.
            string[] webpFiles = Directory.GetFiles(inputFolder, "*.webp");

            foreach (string inputPath in webpFiles)
            {
                // Verify that the input file actually exists.
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine the corresponding PDF output path.
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".pdf";
                string outputPath = Path.Combine(outputFolder, outputFileName);

                // Ensure the directory for the output file exists.
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the WebP image and save it as PDF.
                using (Image image = Image.Load(inputPath))
                {
                    var pdfOptions = new PdfOptions();
                    image.Save(outputPath, pdfOptions);
                }

                Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
            }
        }
        catch (Exception ex)
        {
            // Output any runtime errors without crashing the application.
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to use Aspose.Imaging for .NET to batch convert a folder of WebP product images into printable PDF reports.
 * 2. When an e‑commerce site must archive user‑uploaded WebP photos as PDF documents using C# and Aspose.Imaging to meet compliance requirements.
 * 3. When a content management system automates the conversion of WebP assets to PDF brochures by iterating over files with Aspose.Imaging’s Image.Load and PdfOptions.
 * 4. When a desktop application prepares a portfolio of WebP screenshots into PDF files for client presentations, leveraging Aspose.Imaging’s batch processing capabilities.
 * 5. When a migration script transforms legacy WebP marketing assets into PDF format to integrate with an existing PDF‑based workflow using Aspose.Imaging for .NET.
 */