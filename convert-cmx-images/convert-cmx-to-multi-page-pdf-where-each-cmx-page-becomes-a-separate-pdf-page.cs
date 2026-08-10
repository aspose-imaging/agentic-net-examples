// HOW-TO: Convert CMX to Multi‑Page PDF with Each Page as Separate PDF Page in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input\\sample.cmx";
            string outputPath = "Output\\sample.pdf";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load CMX vector image
            using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
            {
                // Configure PDF export options
                PdfOptions pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None
                    }
                };

                // Save as multi‑page PDF (each CMX page becomes a PDF page)
                cmx.Save(outputPath, pdfOptions);
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
 * 1. When you need to archive a multi‑page CorelDRAW CMX drawing as a searchable PDF document.
 * 2. When a printing workflow requires converting each CMX page into individual PDF pages for batch printing.
 * 3. When you want to embed CMX vector artwork into a PDF report without losing vector quality.
 * 4. When a document management system only accepts PDF files, so CMX files must be transformed before upload.
 * 5. When automating the migration of legacy CMX assets to a PDF‑based digital asset library.
 */
