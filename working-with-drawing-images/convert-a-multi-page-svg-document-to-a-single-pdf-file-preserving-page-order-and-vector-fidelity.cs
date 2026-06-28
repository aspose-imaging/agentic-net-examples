using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/multipage.svg";
            string outputPath = "Output/output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    var vectorOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height,
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None
                    };
                    pdfOptions.VectorRasterizationOptions = vectorOptions;

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
 * 1. When a web application needs to generate printable reports by converting a multi‑page SVG diagram into a single PDF while keeping the original vector quality and page sequence.
 * 2. When an e‑learning platform wants to bundle several SVG slides into one downloadable PDF for offline viewing without rasterizing the graphics.
 * 3. When a CAD tool exports multi‑page SVG schematics and a developer must combine them into a PDF portfolio that preserves exact dimensions and colors.
 * 4. When a marketing automation script creates multi‑page SVG infographics and needs to deliver them as a single PDF attachment to email campaigns.
 * 5. When a document management system ingests SVG assets and requires a C# routine to archive them as a single PDF file with preserved vector fidelity for long‑term storage.
 */