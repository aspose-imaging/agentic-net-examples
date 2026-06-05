using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Temp\input.emf";
            string outputPath = @"C:\Temp\output.pdf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare vector rasterization options for EMF
                EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
                {
                    // Use the original image size as page size
                    PageSize = image.Size,
                    // High‑resolution rendering (e.g., 300 DPI)
                    // The DPI can be set via ResolutionSettings if needed
                    // Here we rely on default high quality rendering
                };

                // Configure PDF export options
                PdfOptions pdfOptions = new PdfOptions
                {
                    // Assign the rasterization options so fonts are embedded
                    VectorRasterizationOptions = rasterOptions,
                    // Optional: set PDF page size to match the EMF size
                    PageSize = image.Size
                };

                // Save the image as a PDF
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
 * 1. When a Windows desktop application needs to generate printable reports from vector‑based EMF charts and ensure the PDF output retains crisp lines and embedded fonts for accurate printing.
 * 2. When a document management system must archive legacy EMF diagrams as high‑resolution PDF files so they can be viewed on any platform without losing vector quality.
 * 3. When a batch‑processing service converts a folder of engineering schematics stored as EMF into PDF for distribution to clients, preserving exact dimensions and font rendering.
 * 4. When a web API receives user‑uploaded EMF logos and returns a PDF version with embedded fonts to meet corporate branding guidelines for marketing collateral.
 * 5. When an automated testing tool validates that EMF graphics are correctly rendered in PDF by rasterizing them at 300 DPI with Aspose.Imaging to compare visual fidelity across formats.
 */