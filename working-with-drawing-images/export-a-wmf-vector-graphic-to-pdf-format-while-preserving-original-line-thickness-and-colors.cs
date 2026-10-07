// HOW-TO: Convert WMF Vector Image to PDF Preserving Line Thickness in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.wmf";
            string outputPath = "output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var pdfOptions = new PdfOptions();
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
 * 1. When a Windows desktop application needs to export legacy WMF diagrams as high‑fidelity PDFs for printing or sharing.
 * 2. When an automated report generator must embed vector‑based flowcharts from WMF files into PDF documents while keeping original line weights and colors.
 * 3. When a migration tool converts old WMF assets to PDF to ensure compatibility with modern viewers without rasterizing the graphics.
 * 4. When a web service receives WMF uploads and returns PDF versions that preserve the exact visual appearance for client preview.
 * 5. When a batch processing script converts multiple WMF icons to PDF for inclusion in documentation, maintaining crisp line thickness.
 */
