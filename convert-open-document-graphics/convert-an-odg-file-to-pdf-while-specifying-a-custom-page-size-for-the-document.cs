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
            string inputPath = "Input/sample.odg";
            string outputPath = "Output/sample.pdf";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options with custom page size
                OdgRasterizationOptions rasterOptions = new OdgRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = new SizeF(800f, 600f) // custom width and height in points
                };

                // Set up PDF save options
                PdfOptions pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save as PDF
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
 * 1. When a developer needs to generate printable PDFs from OpenDocument Graphics (ODG) diagrams for inclusion in reports, and must control the exact page dimensions to match corporate branding guidelines.
 * 2. When an engineering application must export CAD‑like vector drawings stored as ODG files to PDF for client review, ensuring the output fits a predefined sheet size for easy printing.
 * 3. When a web service converts user‑uploaded ODG illustrations to PDF on the fly, using a custom page size to maintain consistent layout across different browsers and devices.
 * 4. When an automated document workflow requires batch conversion of ODG assets to PDF with a specific width and height in points to align with a publishing template.
 * 5. When a desktop utility needs to rasterize ODG content into a PDF with a white background and custom page dimensions for archival storage while preserving visual fidelity.
 */