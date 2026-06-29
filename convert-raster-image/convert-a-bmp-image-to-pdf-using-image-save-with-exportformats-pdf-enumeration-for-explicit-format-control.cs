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
            // Hardcoded input and output file paths
            string inputPath = @"C:\temp\input.bmp";
            string outputPath = @"C:\temp\output.pdf";

            // Verify that the input BMP file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up PDF export options
            PdfOptions pdfOptions = new PdfOptions();

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Save the image as PDF using the specified options
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
 * 1. When a developer needs to embed legacy BMP screenshots into a printable PDF report by calling Image.Save with PdfOptions for explicit format control.
 * 2. When an automated batch job must convert scanned BMP images from a medical imaging device into PDF files for electronic health record storage using Aspose.Imaging.
 * 3. When a Windows desktop application has to export user‑created BMP graphics as PDF to ensure cross‑platform viewing without requiring separate image viewers, using Image.Save with PdfOptions.
 * 4. When a server‑side service processes uploaded BMP logos and generates PDF invoices that include the logo without losing quality by saving the image as PDF.
 * 5. When a document management system must archive BMP technical drawings as PDF to reduce file size and enable searchable PDF archives via Aspose.Imaging's Image.Save method.
 */