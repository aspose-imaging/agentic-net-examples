// HOW-TO: Convert ODG to PDF with Custom DPI and Page Margins in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "sample.odg";
        string outputPath = "sample.pdf";

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
            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options (margins and background)
                OdgRasterizationOptions rasterOptions = new OdgRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = image.Size,
                    BorderX = 50, // left/right margin in pixels
                    BorderY = 50  // top/bottom margin in pixels
                };

                // Configure PDF save options with custom DPI
                PdfOptions pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = rasterOptions,
                    ResolutionSettings = new ResolutionSetting(300, 300) // DPI X, DPI Y
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
 * 1. When a developer needs to generate printable PDFs from OpenDocument graphics while preserving layout by adding white margins and setting a high resolution for crisp output.
 * 2. When an application must batch‑process ODG files into PDF for archival purposes and requires a specific DPI to meet document‑management standards.
 * 3. When a reporting tool creates diagrams in ODG format and the final report must embed those diagrams as PDF pages with consistent margins for a professional look.
 * 4. When a web service receives user‑uploaded ODG drawings and must return a PDF preview that matches screen‑resolution settings and includes a border to avoid clipping.
 * 5. When a CAD‑like workflow converts vector ODG assets to PDF for printing on large‑format printers, needing 300 DPI resolution and defined page borders to align with printer margins.
 */
