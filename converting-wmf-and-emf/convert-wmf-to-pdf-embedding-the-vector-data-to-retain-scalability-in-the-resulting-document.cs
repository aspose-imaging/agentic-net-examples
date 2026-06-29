using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Temp\input.wmf";
            string outputPath = @"C:\Temp\output.pdf";

            // Verify that the input WMF file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the WMF image
            using (Image image = Image.Load(inputPath))
            {
                // Configure vector rasterization to preserve scalability
                var vectorOptions = new WmfRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Set PDF options with the vector rasterization options
                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = vectorOptions
                };

                // Save as PDF, embedding the vector data
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
 * 1. When a developer needs to generate printable reports from legacy Windows Metafile (WMF) diagrams while preserving crisp vector quality in PDF documents.
 * 2. When an application must batch‑convert WMF icons or schematics into searchable PDF files for archival in a document management system.
 * 3. When a CAD or engineering tool exports drawings as WMF and the downstream workflow requires scalable PDF output for client review.
 * 4. When a web service receives user‑uploaded WMF graphics and must return a PDF that retains the original vector resolution for high‑DPI displays.
 * 5. When a Windows desktop utility automates the creation of PDF manuals that embed WMF flowcharts without rasterizing them, ensuring they remain editable in vector‑aware PDF editors.
 */