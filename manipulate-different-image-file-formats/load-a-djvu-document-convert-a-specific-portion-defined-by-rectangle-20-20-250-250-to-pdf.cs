using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.djvu";
            string outputPath = "Output/portion.pdf";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DjVu document
            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                // Define the export rectangle (x, y, width, height)
                var exportArea = new Rectangle(20, 20, 250, 250);

                // Set up PDF save options with DjvuMultiPageOptions for page 0 and the export area
                var pdfOptions = new PdfOptions
                {
                    MultiPageOptions = new DjvuMultiPageOptions(0, exportArea)
                };

                // Save the specified portion to PDF
                djvu.Save(outputPath, pdfOptions);
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
 * 1. When a developer needs to extract a defined rectangular area from a DjVu document and convert that portion into a PDF for embedding in a client‑facing report, this code provides a straightforward solution.
 * 2. When an application must generate a printable PDF preview of a selected region of a scanned DjVu file, such as a signature block or diagram, the snippet shows how to load the DjVu, define the rectangle, and save it as PDF using Aspose.Imaging for .NET.
 * 3. When a workflow requires isolating a specific page segment from a large DjVu archive—like a map excerpt—and delivering it as a lightweight PDF to end users, the example demonstrates the necessary C# operations.
 * 4. When a developer is building a document‑processing service that needs to convert only a portion of a DjVu image (e.g., a form field) to PDF to reduce file size and preserve layout, this code illustrates the required rectangle and multi‑page options.
 * 5. When integrating Aspose.Imaging into a .NET application to programmatically crop a DjVu file and export the cropped area as a PDF for archival or compliance purposes, the provided code handles file validation, rectangle definition, and PDF saving in one flow.
 */