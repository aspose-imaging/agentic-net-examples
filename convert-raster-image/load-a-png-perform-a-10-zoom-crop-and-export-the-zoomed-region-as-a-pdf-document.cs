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
            string inputPath = @"C:\Images\input.png";
            string outputPath = @"C:\Images\output.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Calculate a 10% zoom crop (keep 90% of the original size, centered)
                int cropWidth = (int)(image.Width * 0.9);
                int cropHeight = (int)(image.Height * 0.9);
                int offsetX = (image.Width - cropWidth) / 2;
                int offsetY = (image.Height - cropHeight) / 2;

                var cropRect = new Rectangle(offsetX, offsetY, cropWidth, cropHeight);

                // Set up PDF export options
                var pdfOptions = new PdfOptions();

                // Save the cropped region as a PDF document
                image.Save(outputPath, pdfOptions, cropRect);
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
 * 1. When a developer needs to create a PDF brochure that shows a centered, slightly zoomed‑in view of a product PNG image for marketing materials.
 * 2. When an application must generate a printable PDF report from user‑uploaded PNG screenshots, cropping out the outer 10 % to focus on the main content.
 * 3. When a document management system requires converting high‑resolution PNG scans into PDF files while automatically removing a 10 % border for consistent layout.
 * 4. When a desktop utility has to batch‑process PNG icons, applying a 10 % zoom crop and saving each result as a PDF for inclusion in design specifications.
 * 5. When a C# service needs to preview a PNG map image in PDF format with a centered zoomed region to highlight a specific area for GIS analysis.
 */