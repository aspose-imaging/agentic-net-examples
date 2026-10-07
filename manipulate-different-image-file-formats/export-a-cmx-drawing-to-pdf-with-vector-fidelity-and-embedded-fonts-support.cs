// HOW-TO: Convert CMX Drawing to PDF with Vector Fidelity in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.cmx";
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
 * 1. When a developer needs to export legacy CorelDRAW CMX files to PDF for sharing while preserving vector quality.
 * 2. When an application must generate printable PDFs from CMX drawings without rasterizing the artwork.
 * 3. When a workflow requires converting CMX diagrams to PDF to embed them in reports or documentation.
 * 4. When a server‑side service processes uploaded CMX files and returns PDF versions for client download.
 * 5. When a batch job needs to automate conversion of multiple CMX files to PDF while maintaining embedded fonts.
 */
