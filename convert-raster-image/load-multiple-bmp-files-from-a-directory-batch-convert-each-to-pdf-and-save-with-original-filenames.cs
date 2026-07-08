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

            foreach (string inputPath in bmpFiles)
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output PDF path using the original file name
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".pdf");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the BMP image
                using (Image image = Image.Load(inputPath))
                {
                    // Prepare PDF export options
                    var pdfOptions = new PdfOptions();

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
 * 1. When a developer needs to automate the conversion of a large collection of legacy BMP scans into PDF documents for archival in a document management system.
 * 2. When an application must generate PDF reports from user‑uploaded BMP screenshots in a batch process without manual file handling.
 * 3. When a migration tool has to transform BMP assets stored in a folder into PDF format to reduce file size and improve cross‑platform compatibility.
 * 4. When a C# utility is required to process every BMP file in a directory and save each as a PDF using the original filename for downstream workflows.
 * 5. When a developer wants to use Aspose.Imaging’s PdfOptions to convert BMP images to PDF in a single script, preserving the naming convention for easy reference.
 */