using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output/output.pdf";

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

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Resize to 1024x768 pixels
                image.Resize(1024, 768);

                // Prepare PDF export options
                var pdfOptions = new PdfOptions();

                // Save the image directly as a PDF
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
 * 1. When a web application needs to generate printable PDFs from user‑uploaded PNG screenshots by resizing them to a standard 1024×768 layout.
 * 2. When an automated reporting tool must convert high‑resolution PNG charts into PDF pages that fit a predefined page size for consistent distribution.
 * 3. When a desktop utility processes batch PNG assets, scaling each to 1024×768 pixels before embedding them directly into PDF catalogs without intermediate files.
 * 4. When a mobile backend service receives PNG images from devices and must resize them to 1024×768 and return a PDF version for email attachment.
 * 5. When a document management system requires on‑the‑fly conversion of PNG logos to PDF format at a fixed resolution to meet archival standards.
 */