// HOW-TO: Convert ODG to Flattened PDF with White Background in C# (Aspose.Imaging for .NET)
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
            string inputPath = @"C:\Input\sample.odg";
            string outputPath = @"C:\Output\sample.pdf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Set up rasterization options to flatten the vector content
                OdgRasterizationOptions rasterOptions = new OdgRasterizationOptions
                {
                    BackgroundColor = Color.White,   // White background for the PDF
                    PageSize = image.Size            // Preserve original page size
                };

                // Configure PDF save options and attach rasterization options
                PdfOptions pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the flattened PDF
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
 * 1. When you need to archive OpenDocument graphics as a non‑editable PDF for legal or compliance records.
 * 2. When a reporting system must generate printable PDFs from ODG diagrams while ensuring all vector layers are rasterized into a single static image.
 * 3. When you want to embed ODG illustrations into a PDF brochure and remove interactive annotations to keep the layout consistent across viewers.
 * 4. When an automated workflow converts user‑uploaded ODG files to PDF with a white background to match corporate document templates.
 * 5. When a desktop application needs to batch‑process ODG drawings into flattened PDFs for distribution to clients who only have PDF readers.
 */
