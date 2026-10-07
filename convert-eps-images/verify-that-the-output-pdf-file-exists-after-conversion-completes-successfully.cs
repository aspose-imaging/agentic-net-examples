// HOW-TO: How to Convert JPG to PDF and Verify File Creation in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output paths
            string inputPath = "input.jpg";
            string outputPath = "output.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (string.IsNullOrEmpty(outputDir))
            {
                outputDir = ".";
            }
            Directory.CreateDirectory(outputDir);

            // Load image and convert to PDF
            using (Image image = Image.Load(inputPath))
            {
                PdfOptions pdfOptions = new PdfOptions();
                image.Save(outputPath, pdfOptions);
            }

            // Verify output PDF exists
            if (File.Exists(outputPath))
            {
                Console.WriteLine("PDF file created successfully.");
            }
            else
            {
                Console.Error.WriteLine("Failed to create PDF file.");
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
 * 1. When you need to generate a PDF report from user‑uploaded JPEG images and confirm the file was saved before sending a download link.
 * 2. When an automated batch job must convert scanned JPG photos to PDF archives while ensuring the output folder exists and the PDF was created successfully.
 * 3. When a web service processes incoming JPEG attachments, converts them to PDF with Aspose.Imaging, and validates the conversion to avoid returning broken files.
 * 4. When a desktop application offers an “Export as PDF” feature for images and must check that the exported PDF is present on disk before displaying a success message.
 * 5. When a CI/CD pipeline includes a step that transforms image assets to PDF format and needs to verify the artifact was produced to prevent downstream build failures.
 */
