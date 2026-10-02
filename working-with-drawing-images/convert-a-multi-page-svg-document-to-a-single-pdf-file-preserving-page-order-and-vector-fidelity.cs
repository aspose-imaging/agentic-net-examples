// HOW-TO: Convert Multi‑Page SVG to Single PDF with Vector Fidelity in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;

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
                SvgImage svgImage = (SvgImage)image;

                PdfOptions pdfOptions = new PdfOptions();
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = svgImage.Width,
                    PageHeight = svgImage.Height
                };
                pdfOptions.VectorRasterizationOptions = rasterOptions;

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
 * 1. When you need to generate a printable PDF report from a multi‑page SVG diagram while keeping the original vector quality.
 * 2. When an application must batch‑convert SVG assets created by designers into a single PDF for easy distribution to clients.
 * 3. When you want to embed multi‑page SVG illustrations into a PDF portfolio without rasterizing the graphics.
 * 4. When a web service receives SVG files and must return a PDF document that preserves page order for compliance documentation.
 * 5. When automating the creation of PDF invoices that include vector‑based SVG logos and multi‑page charts in a .NET backend.
 */
