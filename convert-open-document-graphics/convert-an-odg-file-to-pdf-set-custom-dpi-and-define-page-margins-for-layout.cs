// HOW-TO: Convert ODG to PDF with Custom DPI and Page Size in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = Path.Combine("Input", "sample.odg");
        string outputPath = Path.Combine("Output", "sample.pdf");

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    pdfOptions.ResolutionSettings = new Aspose.Imaging.ResolutionSetting(300, 300);
                    pdfOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Aspose.Imaging.Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
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
 * 1. When you need to generate printable PDF reports from ODG diagrams while preserving the original dimensions.
 * 2. When you must embed ODG drawings into a PDF document with a specific resolution for high‑quality printing.
 * 3. When an application has to batch‑convert ODG files to PDFs and control the output DPI to meet corporate standards.
 * 4. When you want to create PDFs from ODG graphics with a white background to avoid transparency issues in downstream viewers.
 * 5. When you need to programmatically set the PDF page size to match the ODG canvas so the content fits without scaling.
 */
