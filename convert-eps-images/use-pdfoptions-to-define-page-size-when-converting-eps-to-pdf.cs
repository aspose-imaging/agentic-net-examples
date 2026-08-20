// HOW-TO: Convert EPS to PDF with Custom Page Size in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.eps";
        string outputPath = "Output/sample.pdf";

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
            // Load EPS image
            using (var image = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(inputPath))
            {
                // Configure PDF options with page size matching the EPS image dimensions
                var pdfOptions = new PdfOptions
                {
                    PageSize = new SizeF(image.Width, image.Height)
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
 * 1. When a developer needs to embed a vector EPS illustration into a PDF report and must preserve the original dimensions for accurate layout.
 * 2. When an automated document generation system converts EPS logos to PDF files that match the logo’s exact size for printing.
 * 3. When a batch conversion tool processes EPS artwork and requires each PDF page to be sized to the image’s width and height to avoid scaling artifacts.
 * 4. When a web service receives EPS files from users and returns PDF previews that retain the original page size for WYSIWYG preview.
 * 5. When integrating Aspose.Imaging into a C# application to create PDF invoices that include EPS graphics sized precisely to fit designated sections.
 */
