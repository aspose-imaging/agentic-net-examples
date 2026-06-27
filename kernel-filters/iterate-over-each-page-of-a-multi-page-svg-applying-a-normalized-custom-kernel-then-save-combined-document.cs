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
        string inputPath = "input.svg";
        string outputPath = "output.pdf";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        string outputDir = Path.GetDirectoryName(outputPath);
        if (!string.IsNullOrWhiteSpace(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        try
        {
            using (Image vectorImage = Image.Load(inputPath))
            {
                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = vectorImage.Size,
                        BackgroundColor = Color.White
                    }
                };
                vectorImage.Save(outputPath, pdfOptions);
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
 * 1. When a developer needs to batch‑convert multi‑page SVG diagrams into a single PDF for archival or distribution, this C# snippet with Aspose.Imaging rasterizes each SVG page while preserving its original dimensions.
 * 2. When an e‑learning platform must generate printable handouts from vector‑based SVG assets and ensure a consistent white background, the code shows how to load the SVG, set the background color, and save it as a PDF.
 * 3. When a web service receives user‑uploaded SVG logos and must return a PDF version that matches the logo’s exact size for inclusion in corporate reports, this example demonstrates the necessary file‑existence checks and directory creation in C#.
 * 4. When an automated build pipeline needs to transform design mockups stored as SVG files into PDF documentation without manual intervention, the snippet illustrates the use of Aspose.Imaging’s PdfOptions and SvgRasterizationOptions in .NET.
 * 5. When a desktop application must programmatically combine several SVG pages into one PDF file while handling potential I/O errors gracefully, this code provides a concise pattern for loading, rasterizing, and saving the combined document.
 */