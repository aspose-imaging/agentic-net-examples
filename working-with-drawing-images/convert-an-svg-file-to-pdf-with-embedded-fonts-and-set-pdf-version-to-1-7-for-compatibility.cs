// HOW-TO: Convert SVG to PDF with Embedded Fonts Using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.svg";
        string outputPath = "Output/sample.pdf";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                SvgImage svgImage = (SvgImage)image;

                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    pdfOptions.PdfDocumentInfo = new PdfDocumentInfo();
                    pdfOptions.VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = svgImage.Width,
                        PageHeight = svgImage.Height
                    };

                    svgImage.Save(outputPath, pdfOptions);
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
 * 1. When you need to generate a print‑ready PDF from an SVG logo while preserving the original fonts for accurate branding in a C# application.
 * 2. When a web service must convert user‑uploaded SVG diagrams to PDF documents that comply with PDF 1.7 standards for downstream processing.
 * 3. When an automated reporting tool creates PDF reports from vector graphics and requires the fonts to be embedded to avoid missing text on client machines.
 * 4. When a desktop utility batch‑processes a folder of SVG assets and outputs PDFs with consistent page size and white background using Aspose.Imaging in .NET.
 * 5. When integrating SVG to PDF conversion into a CI pipeline to ensure design files are archived in a universally viewable format with embedded fonts.
 */
