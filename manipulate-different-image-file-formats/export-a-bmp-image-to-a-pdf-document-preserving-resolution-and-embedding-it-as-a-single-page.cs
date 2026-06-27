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
            // Hard‑coded input and output file paths
            string inputPath = @"C:\temp\input.bmp";
            string outputPath = @"C:\temp\output.pdf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PDF export options
                var pdfOptions = new PdfOptions
                {
                    // Preserve the original DPI resolution of the BMP image
                    UseOriginalImageResolution = true
                };

                // Save the image as a single‑page PDF
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
 * 1. When a developer needs to convert a high‑resolution BMP scan of an engineering drawing into a single‑page PDF for distribution while preserving the original DPI.
 * 2. When a Windows desktop application must generate printable PDFs from BMP screenshots captured in C# without losing image clarity.
 * 3. When an automated batch job has to archive BMP medical images as PDF documents, keeping the diagnostic resolution intact for compliance.
 * 4. When a document management system requires embedding BMP product photos into PDF catalogs, ensuring the images retain their native resolution.
 * 5. When a C# service integrates Aspose.Imaging to transform BMP map files into PDF pages for GIS reporting, maintaining accurate scale and detail.
 */