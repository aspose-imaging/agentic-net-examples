// HOW-TO: Convert PNG to SVG and Then to High Resolution PDF in C# (Aspose.Imaging for .NET)
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
            string inputPngPath = "Input/sample.png";
            string intermediateSvgPath = "Output/sample.svg";
            string outputPdfPath = "Output/sample.pdf";

            // Validate PNG input file
            if (!File.Exists(inputPngPath))
            {
                Console.Error.WriteLine($"File not found: {inputPngPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(intermediateSvgPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

            // Convert PNG to SVG
            using (Image pngImage = Image.Load(inputPngPath))
            {
                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = pngImage.Size
                    }
                };
                pngImage.Save(intermediateSvgPath, svgOptions);
            }

            // Validate generated SVG file
            if (!File.Exists(intermediateSvgPath))
            {
                Console.Error.WriteLine($"File not found: {intermediateSvgPath}");
                return;
            }

            // Convert SVG to high‑resolution PDF
            using (Image svgImage = Image.Load(intermediateSvgPath))
            {
                var pdfOptions = new PdfOptions
                {
                    // Set high DPI for the PDF
                    ResolutionSettings = new ResolutionSetting(300, 300),
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = svgImage.Size
                    }
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
 * 1. When you need to embed a raster logo from a PNG file into a printable PDF with vector scalability, you can convert the PNG to SVG first and then render a high‑resolution PDF.
 * 2. When generating product catalogs where images must retain sharpness at 300 DPI, this code transforms PNG graphics into SVG vectors before creating a PDF suitable for professional printing.
 * 3. When an application must provide downloadable PDFs that preserve the original PNG dimensions and quality, converting to SVG ensures accurate page sizing and then rasterizing to PDF at high resolution.
 * 4. When automating a workflow that requires converting web‑optimized PNG assets into print‑ready PDFs, the intermediate SVG step allows vector‑based scaling and consistent layout.
 * 5. When creating archival documents that need both scalable SVG source files and high‑quality PDF outputs from a single PNG source, this process delivers both formats in one automated routine.
 */
