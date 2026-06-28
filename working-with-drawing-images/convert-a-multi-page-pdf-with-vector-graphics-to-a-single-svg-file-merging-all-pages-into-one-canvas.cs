using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.pdf";
            string outputPath = "output.svg";

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

            using (Image pdfImage = Image.Load(inputPath))
            {
                var svgOptions = new SvgOptions();
                pdfImage.Save(outputPath, svgOptions);
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
 * 1. When a developer needs to embed a multi‑page PDF brochure containing vector graphics into a web page as a single scalable SVG canvas for responsive design.
 * 2. When an application must convert engineering drawings stored in a PDF file into a single SVG file to allow interactive zoom and pan without losing vector quality.
 * 3. When a reporting tool generates multi‑page PDF invoices and the developer wants to merge them into one SVG for inclusion in an HTML email template.
 * 4. When a GIS system exports map data as a PDF and the developer needs to transform all pages into one SVG to overlay with other web‑based map layers.
 * 5. When a document management workflow requires consolidating a multi‑page PDF user manual into a single SVG asset for easy annotation in a C# desktop application.
 */