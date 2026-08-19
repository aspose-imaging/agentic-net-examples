// HOW-TO: Convert CorelDRAW CDR to PDF with Embedded Fonts in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.cdr";
            string outputPath = "Output/sample.pdf";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set default font to be embedded
            FontSettings.DefaultFontName = "Arial";

            // Load CDR image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PDF options with CDR rasterization settings
                PdfOptions pdfOptions = new PdfOptions();

                CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
                {
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None,
                    Positioning = PositioningTypes.DefinedByDocument
                };

                pdfOptions.VectorRasterizationOptions = rasterOptions;

                // Save as PDF with embedded fonts
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
 * 1. When you need to generate a PDF from a CorelDRAW CDR file while ensuring all text uses embedded fonts for consistent printing across devices.
 * 2. When automating a batch conversion pipeline that transforms design assets into PDF documents with precise rasterization settings in a .NET application.
 * 3. When creating a web service that receives CDR uploads and returns PDF files with fonts embedded to avoid missing‑font issues on client machines.
 * 4. When preserving the visual fidelity of vector text in CDR files by rasterizing them with specific smoothing and positioning options before saving as PDF.
 * 5. When integrating Aspose.Imaging into a C# workflow to programmatically convert legacy CorelDRAW files to PDF for archival or compliance purposes.
 */
