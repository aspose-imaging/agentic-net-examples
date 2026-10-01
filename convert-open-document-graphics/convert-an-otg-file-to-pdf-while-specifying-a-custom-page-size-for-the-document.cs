// HOW-TO: Convert OTG to PDF with Custom Page Size in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = Path.Combine("Input", "sample.otg");
        string outputPath = Path.Combine("Output", "result.pdf");

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                using (var pdfOptions = new PdfOptions())
                {
                    pdfOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Aspose.Imaging.Color.White,
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
 * 1. When you need to embed a vector‑based OTG illustration into a PDF report and must control the exact dimensions of the page.
 * 2. When generating printable PDFs from OTG assets for a marketing brochure that requires a specific 800 × 600 pixel layout.
 * 3. When automating a batch conversion of OTG files to PDF in a C# backend while ensuring a white background and consistent page size.
 * 4. When integrating Aspose.Imaging into a document‑generation service to render OTG graphics as PDF pages with custom width and height.
 * 5. When creating PDFs from OTG diagrams for an e‑learning platform where each page must match a predefined screen resolution.
 */
