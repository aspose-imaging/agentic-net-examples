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

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image and save as PDF
            using (Image image = Image.Load(inputPath))
            {
                var pdfOptions = new PdfOptions();
                image.Save(outputPath, pdfOptions);
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
 * 1. When a web service receives user‑uploaded JPEG images and must convert them to PDF while ensuring missing files or write‑permission errors are logged for troubleshooting.
 * 2. When an automated batch job processes a folder of scanned photos, converting each to PDF and needs to capture and record any failures caused by corrupted image data or unavailable output directories.
 * 3. When a desktop application allows users to export edited pictures as PDF documents and must gracefully handle situations such as insufficient disk space or invalid image formats by writing error messages to the console or log file.
 * 4. When a CI/CD pipeline validates image‑to‑PDF conversion as part of a build step and requires exception handling to abort the build while providing clear error details for debugging.
 * 5. When an enterprise document management system integrates Aspose.Imaging to archive JPEG assets as PDFs and must log exceptions like access violations or unsupported color profiles to comply with audit requirements.
 */