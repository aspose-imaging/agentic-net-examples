// HOW-TO: Convert OTG to Flattened PDF in C# Using Aspose.Imaging (Aspose.Imaging for .NET)
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
            string inputPath = @"C:\Data\sample.otg";
            string outputPath = @"C:\Data\sample.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options for OTG
                OtgRasterizationOptions otgOptions = new OtgRasterizationOptions
                {
                    // Use the original image size as page size
                    PageSize = image.Size
                };

                // Set up PDF save options and attach rasterization options
                PdfOptions pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = otgOptions
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
 * 1. When you need to generate a non‑editable PDF report from an OTG design file in a C# application.
 * 2. When you must archive OTG drawings as static PDFs to ensure annotations are permanently flattened for compliance.
 * 3. When a document management system requires converting user‑uploaded OTG images to PDF for preview without preserving edit layers.
 * 4. When automating batch processing of OTG files to PDF on a server, preserving the original page size and removing interactive elements.
 * 5. When integrating Aspose.Imaging into a .NET workflow to rasterize vector OTG content into a PDF that can be opened by any PDF viewer.
 */
