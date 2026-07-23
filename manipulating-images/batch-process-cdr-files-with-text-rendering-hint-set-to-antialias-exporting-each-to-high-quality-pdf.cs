using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = @"C:\InputCdr";
            string outputDir = @"C:\OutputPdf";

            // Get all CDR files in the input directory
            string[] cdrFiles = Directory.GetFiles(inputDir, "*.cdr");

            foreach (string inputPath in cdrFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output PDF path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileNameWithoutExt + ".pdf");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the CDR image
                using (Image image = Image.Load(inputPath))
                {
                    // Configure PDF export options
                    PdfOptions pdfOptions = new PdfOptions();
                    CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
                    {
                        TextRenderingHint = TextRenderingHint.AntiAlias,
                        SmoothingMode = SmoothingMode.AntiAlias,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    };

                    pdfOptions.VectorRasterizationOptions = rasterOptions;

                    // Save as high‑quality PDF
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
 * 1. When a graphic design studio needs to convert an entire folder of CorelDRAW (.cdr) artwork into high‑quality PDF documents with anti‑aliased text for client review, they can use this C# Aspose.Imaging batch conversion code.
 * 2. When an automated publishing pipeline must generate print‑ready PDFs from legacy CDR files while preserving crisp text rendering, developers can employ the code to rasterize each page with TextRenderingHint.AntiAlias.
 * 3. When a document management system needs to archive multiple CDR drawings as searchable PDFs without manual intervention, the snippet provides a way to loop through files, set smoothing options, and save them in .pdf format.
 * 4. When a Windows service is tasked with nightly conversion of newly uploaded CDR assets to PDF for web preview, the example shows how to load each image, configure CdrRasterizationOptions, and output anti‑aliased PDFs using Aspose.Imaging for .NET.
 * 5. When a QA engineer wants to verify that text in converted PDFs retains visual fidelity across different screen resolutions, they can run this batch process to produce PDFs with anti‑aliasing and compare the results programmatically.
 */