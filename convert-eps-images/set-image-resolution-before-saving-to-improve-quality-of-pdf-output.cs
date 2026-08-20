// HOW-TO: Set Image Resolution to 300 DPI When Converting BMP to PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\input.bmp";
        string outputPath = @"C:\Images\output.pdf";

        // Ensure any runtime exception is reported without crashing
        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PDF save options with higher resolution (e.g., 300 DPI)
                PdfOptions pdfOptions = new PdfOptions
                {
                    // Do not use the original image DPI; use the specified resolution instead
                    UseOriginalImageResolution = false,
                    // Set horizontal and vertical resolution to 300 DPI
                    ResolutionSettings = new ResolutionSetting(300.0, 300.0)
                };

                // Save the image as a PDF with the specified options
                image.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any error that occurs during processing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer must create a printable PDF from a BMP file and needs the output to meet a 300 DPI print quality requirement.
 * 2. When generating PDFs for archival purposes where all pages must have a consistent resolution regardless of the source image’s original DPI.
 * 3. When converting scanned documents to PDF and wants to ensure the resulting file is suitable for OCR engines that perform better with higher DPI images.
 * 4. When building a batch‑processing tool that standardizes image resolution before embedding them into PDFs for a publishing workflow.
 * 5. When overriding the original image DPI to match a corporate branding guideline that specifies a minimum resolution for all PDF assets.
 */
