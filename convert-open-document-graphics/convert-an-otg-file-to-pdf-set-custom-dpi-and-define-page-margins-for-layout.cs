// HOW-TO: Convert OTG to PDF with Custom DPI and Page Margins in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.otg";
        string outputPath = "output.pdf";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the OTG image
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                // Configure rasterization options: page size and margins
                OtgRasterizationOptions rasterOptions = new OtgRasterizationOptions
                {
                    PageSize = image.Size,   // Preserve original aspect ratio
                    BorderX = 50,            // Horizontal margin (in pixels)
                    BorderY = 50             // Vertical margin (in pixels)
                };

                // Set up PDF save options with custom DPI
                PdfOptions pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = rasterOptions,
                    ResolutionSettings = new Aspose.Imaging.ResolutionSetting(300, 300) // DPI X and Y
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
 * 1. When you need to generate a printable PDF from an OTG vector graphic while preserving its original size and adding whitespace around the edges.
 * 2. When a reporting system must embed high‑resolution OTG diagrams into PDF documents for client distribution.
 * 3. When an automated batch job converts a folder of OTG files to PDFs with a specific 300 DPI setting for archival quality.
 * 4. When a web service creates PDFs from user‑uploaded OTG images and requires consistent margins to align with a predefined layout template.
 * 5. When a desktop application needs to ensure that OTG artwork is rasterized at a known resolution before saving as PDF for downstream printing workflows.
 */
