// HOW-TO: Combine Multiple CDR Files Into a Single PDF in C# (Aspose.Imaging for .NET)
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
            // Input CDR files (hard‑coded)
            string[] inputPaths = new string[]
            {
                "input1.cdr",
                "input2.cdr",
                "input3.cdr"
            };

            // Verify each input file exists
            foreach (var path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Output PDF file (hard‑coded)
            string outputPath = "output.pdf";

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Create a multipage image from the CDR files
            using (Image multipageImage = Image.Create(inputPaths))
            {
                // Configure PDF options with CDR rasterization settings
                PdfOptions pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = new CdrRasterizationOptions
                    {
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None
                    }
                };

                // Save the combined PDF
                multipageImage.Save(outputPath, pdfOptions);
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
 * 1. When you need to merge several CorelDRAW (CDR) drawings into one PDF for client delivery while preserving the original page order.
 * 2. When automating a batch conversion that turns a series of CDR pages into a multi‑page PDF report using C#.
 * 3. When integrating Aspose.Imaging into a C# application to rasterize CDR files and create a combined PDF without manual editing.
 * 4. When generating printable PDFs from CDR assets on a server, eliminating the need to open each file in CorelDRAW.
 * 5. When building a web service that accepts multiple CDR uploads and returns a single combined PDF for archiving or distribution.
 */
