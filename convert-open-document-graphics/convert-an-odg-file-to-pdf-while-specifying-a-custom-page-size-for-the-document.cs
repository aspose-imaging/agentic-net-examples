// HOW-TO: Convert ODG to PDF with Custom Page Size in C# (Aspose.Imaging for .NET)
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
            string inputPath = Path.Combine("Input", "sample.odg");
            string outputPath = Path.Combine("Output", "sample.pdf");

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
                    pdfOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = 800,
                        PageHeight = 600
                    };
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
 * 1. When you need to generate a PDF report from an ODG diagram and ensure the output fits a specific 800 × 600 pixel layout.
 * 2. When a web application must convert user‑uploaded ODG files to PDF while preserving a predefined page size for consistent printing.
 * 3. When automating batch processing of OpenDocument graphics to PDFs with a uniform page dimension for archival purposes.
 * 4. When integrating Aspose.Imaging into a C# service that creates PDFs from ODG files with a white background and custom page width and height.
 * 5. When developing a desktop tool that transforms ODG drawings into PDFs that match the exact size required by a downstream layout engine.
 */
