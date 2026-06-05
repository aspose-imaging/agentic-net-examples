using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.tif";
        string outputPath = @"C:\Images\output.pdf";

        // Ensure the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PDF save options with vector rasterization settings
                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        // Set smoothing mode to AntiAlias for smoother edges
                        SmoothingMode = Aspose.Imaging.SmoothingMode.AntiAlias,
                        // Use the original image size as the page size
                        PageSize = image.Size
                    }
                };

                // Save the image as PDF using the configured options
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
 * 1. When converting high‑resolution scanned TIFF blueprints to PDF for client delivery, a developer can enable AntiAlias smoothing to ensure the linework appears crisp and free of jagged edges.
 * 2. When generating PDF reports from TIFF medical images, setting SmoothingMode to AntiAlias helps preserve subtle details while producing print‑ready documents.
 * 3. When automating the archival of TIFF photographs into searchable PDF portfolios, applying AntiAlias smoothing improves visual quality for end‑users viewing the files on screen.
 * 4. When building a C# web service that transforms user‑uploaded TIFF invoices into PDF receipts, using AntiAlias smoothing prevents rough text and logo edges in the final PDF.
 * 5. When creating batch scripts to convert TIFF engineering diagrams to PDF for inclusion in technical manuals, enabling AntiAlias smoothing ensures the diagrams retain smooth contours and professional appearance.
 */