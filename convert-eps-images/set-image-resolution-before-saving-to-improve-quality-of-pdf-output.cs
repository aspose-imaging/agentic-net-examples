using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.pdf";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PDF save options with higher resolution
                PdfOptions pdfOptions = new PdfOptions
                {
                    // Set desired DPI (e.g., 300x300)
                    ResolutionSettings = new ResolutionSetting(300.0, 300.0)
                };

                // Save the image as PDF with the specified options
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
 * 1. When generating printable PDFs from high‑resolution PNG assets, a developer can use this code to set a 300 DPI resolution so the output meets print‑shop standards.
 * 2. When converting scanned documents stored as PNG files into searchable PDF files, setting the resolution ensures the PDF retains the original image clarity for OCR engines.
 * 3. When creating archival PDFs for legal or medical records, a developer needs to enforce a specific DPI to guarantee consistent image quality across different viewing devices.
 * 4. When building a C# web service that returns PDF invoices with embedded product images, adjusting the resolution before saving prevents pixelation on high‑resolution displays.
 * 5. When automating batch conversion of UI screenshots to PDF manuals, specifying the resolution helps maintain sharpness when the PDFs are zoomed or printed.
 */