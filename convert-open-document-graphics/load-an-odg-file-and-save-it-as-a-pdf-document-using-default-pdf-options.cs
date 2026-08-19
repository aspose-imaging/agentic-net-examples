// HOW-TO: Convert ODG File to PDF Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = "input.odg";
            string outputPath = "output\\converted.pdf";

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
                // Set up rasterization options for ODG
                OdgRasterizationOptions rasterizationOptions = new OdgRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.White,
                    PageSize = image.Size
                };

                // Set up PDF save options and attach rasterization options
                PdfOptions pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save the image as PDF
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
 * 1. When you need to programmatically generate printable PDF reports from OpenDocument graphics (ODG) files in a .NET application.
 * 2. When a document management system must archive ODG drawings as PDF to ensure universal viewing without requiring LibreOffice.
 * 3. When an automated workflow converts user‑uploaded ODG diagrams into PDF for email attachment or web preview.
 * 4. When a batch process migrates a library of ODG assets to PDF to reduce file size and simplify distribution.
 * 5. When a C# service renders ODG artwork with a white background and saves it as PDF for inclusion in larger PDF portfolios.
 */
