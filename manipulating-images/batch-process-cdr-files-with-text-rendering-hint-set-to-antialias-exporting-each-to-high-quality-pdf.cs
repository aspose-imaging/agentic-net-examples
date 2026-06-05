using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageLoadOptions;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputDirectory = @"C:\InputCdr";
        string outputDirectory = @"C:\OutputPdf";

        try
        {
            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Process each CDR file in the input directory
            foreach (string inputPath in Directory.GetFiles(inputDirectory, "*.cdr"))
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Determine output PDF path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".pdf");

                // Ensure the output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the CDR image with default load options
                using (Image image = Image.Load(inputPath, new CdrLoadOptions()))
                {
                    // Configure PDF export options with high‑quality rasterization
                    PdfOptions pdfOptions = new PdfOptions();
                    CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
                    {
                        TextRenderingHint = TextRenderingHint.AntiAlias,
                        SmoothingMode = SmoothingMode.AntiAlias
                    };
                    pdfOptions.VectorRasterizationOptions = rasterOptions;

                    // Save the page(s) to PDF
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
 * 1. When a design studio needs to convert a large collection of CorelDRAW (.cdr) artwork into print‑ready PDF files with smooth anti‑aliased text, they can use this batch‑processing code.
 * 2. When an automated document workflow must generate searchable PDFs from legacy CDR assets while preserving text clarity, developers can employ the Aspose.Imaging C# routine that sets TextRenderingHint.AntiAlias.
 * 3. When a cloud‑based conversion service has to rasterize multiple CDR files into high‑resolution PDFs for client download, this code provides the necessary directory traversal and anti‑alias rendering options.
 * 4. When a quality‑control script must ensure that all exported PDFs from CDR sources retain crisp vector text for regulatory submissions, the example demonstrates how to enforce anti‑aliasing during rasterization.
 * 5. When an enterprise needs to integrate bulk CorelDRAW to PDF conversion into a .NET application without manual intervention, the provided snippet shows how to load, configure, and save each file with anti‑aliased text rendering.
 */