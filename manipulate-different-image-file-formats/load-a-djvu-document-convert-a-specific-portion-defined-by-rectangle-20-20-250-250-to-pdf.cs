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

            // Verify input file exists
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

                // Set up PDF save options with DjVu multi‑page export settings
                var pdfOptions = new PdfOptions
                {
                    MultiPageOptions = new DjvuMultiPageOptions(0, exportArea) // page index 0
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
 * 1. When a developer needs to extract a specific region of a scanned DjVu document (e.g., a diagram or signature) and save it as a standalone PDF for easy sharing.
 * 2. When an application must generate a PDF preview of a selected area from a multi‑page DjVu file without converting the entire document.
 * 3. When a workflow requires converting a portion of a DjVu image (defined by coordinates) into a PDF to embed in a report or email attachment.
 * 4. When a document management system needs to isolate and archive a particular rectangular section of a DjVu file as a searchable PDF for compliance purposes.
 * 5. When a C# service automates the extraction of a defined rectangle from a DjVu page and outputs it as a PDF to integrate with downstream PDF processing tools.
 */