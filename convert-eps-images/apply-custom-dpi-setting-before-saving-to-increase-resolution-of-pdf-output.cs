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
        string inputPath = @"C:\Images\sample.png";
        string outputPath = @"C:\Images\output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PDF save options with custom DPI
                var pdfOptions = new PdfOptions
                {
                    // Do not inherit original image DPI
                    UseOriginalImageResolution = false,
                    // Set desired resolution (e.g., 300 DPI)
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
 * 1. When a developer needs to generate high‑resolution printable PDFs from PNG assets for marketing brochures, they can set a custom 300 DPI before saving.
 * 2. When converting scanned documents stored as PNG files into PDF for archival, a custom DPI ensures the PDF meets legal or industry standards for image clarity.
 * 3. When an e‑learning platform creates PDF handouts from lesson graphics, increasing the DPI prevents pixelation on large‑format displays and projectors.
 * 4. When a medical imaging application exports diagnostic images to PDF for radiology reports, setting a higher DPI preserves diagnostic detail required by clinicians.
 * 5. When a real‑estate website produces property flyers by converting PNG floor‑plans to PDF, applying a custom DPI guarantees sharpness when the PDFs are printed on large posters.
 */