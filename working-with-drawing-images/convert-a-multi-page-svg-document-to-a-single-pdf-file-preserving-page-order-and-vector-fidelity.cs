// HOW-TO: Convert Multi‑Page SVG to Single PDF with Vector Fidelity in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\temp\multipage.svg";
            string outputPath = @"C:\temp\output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                PdfOptions exportOptions = new PdfOptions();

                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageWidth = image.Width,
                    PageHeight = image.Height,
                    BackgroundColor = Color.White,
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None
                };

                exportOptions.VectorRasterizationOptions = rasterOptions;

                image.Save(outputPath, exportOptions);
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
 * 1. When you need to generate a printable PDF from a multi‑page SVG design while keeping the original vector quality for high‑resolution output.
 * 2. When an application must batch‑process SVG assets and combine them into a single PDF report for distribution to clients.
 * 3. When you want to preserve the exact page order of a multi‑page SVG diagram when converting it to a PDF for documentation purposes.
 * 4. When you require a C# solution that uses Aspose.Imaging to convert SVG graphics to PDF without losing scalability or introducing raster artifacts.
 * 5. When you need to automate the creation of PDF portfolios from SVG files in a server‑side workflow, ensuring consistent background color and rendering settings.
 */
