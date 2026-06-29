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
        try
        {
            string inputPngPath = "Input/input.png";
            string outputSvgPath = "Output/output.svg";
            string outputPdfPath = "Output/output.pdf";

            if (!File.Exists(inputPngPath))
            {
                Console.Error.WriteLine($"File not found: {inputPngPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputSvgPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

            // Convert PNG to SVG
            using (Image pngImage = Image.Load(inputPngPath))
            {
                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions { PageSize = pngImage.Size }
                };
                pngImage.Save(outputSvgPath, svgOptions);
            }

            // Convert SVG to high‑resolution PDF
            using (Image svgImage = Image.Load(outputSvgPath))
            {
                var pdfOptions = new PdfOptions
                {
                    ResolutionSettings = new ResolutionSetting(300, 300),
                    VectorRasterizationOptions = new SvgRasterizationOptions { PageSize = svgImage.Size }
                };
                svgImage.Save(outputPdfPath, pdfOptions);
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
 * 1. When a developer needs to convert a raster PNG logo into a scalable SVG for responsive web design and then embed it in a high‑resolution PDF report.
 * 2. When an e‑commerce platform must generate printable product catalogs by turning product PNG images into vector SVGs and then creating PDF brochures at 300 dpi.
 * 3. When a medical imaging system requires lossless conversion of scanned PNG diagrams into SVG for annotation and then exporting them as high‑resolution PDF for regulatory documentation.
 * 4. When a desktop publishing tool automates the workflow of turning user‑uploaded PNG artwork into SVG vectors and subsequently producing print‑ready PDF files with precise page sizing.
 * 5. When a GIS application needs to rasterize map tiles stored as PNG, convert them to SVG for scaling, and finally generate a high‑resolution PDF map for offline distribution.
 */