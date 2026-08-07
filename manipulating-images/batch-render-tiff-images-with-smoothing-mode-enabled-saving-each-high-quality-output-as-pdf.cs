using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded list of input TIFF files
            string[] inputFiles = new[]
            {
                @"C:\Images\sample1.tif",
                @"C:\Images\sample2.tif",
                @"C:\Images\sample3.tif"
            };

            foreach (string inputPath in inputFiles)
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output PDF path (same name, .pdf extension, placed in C:\Output)
                string outputDirectory = @"C:\Output";
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".pdf";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the TIFF image
                using (Image image = Image.Load(inputPath))
                {
                    // Configure PDF export options with high‑quality smoothing
                    var pdfOptions = new PdfOptions
                    {
                        VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            SmoothingMode = SmoothingMode.HighQuality
                        }
                    };

                    // Save as PDF
                    image.Save(outputPath, pdfOptions);
                }
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
 * 1. When a developer needs to batch‑convert scanned TIFF documents into PDF files with high‑quality smoothing for archival or distribution.
 * 2. When an application must generate print‑ready PDFs from multi‑page TIFF medical images while preserving visual fidelity using Aspose.Imaging’s SmoothingMode.HighQuality.
 * 3. When a document management system requires automated conversion of TIFF invoices to PDF format with anti‑aliasing to ensure crisp text and graphics.
 * 4. When a GIS tool needs to export raster TIFF map tiles to PDF maps with smooth rendering for inclusion in analytical reports.
 * 5. When a legal firm wants to batch‑process TIFF evidence files into PDF packets, applying high‑quality smoothing to maintain detail for courtroom presentation.
 */