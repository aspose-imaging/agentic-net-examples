using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input CMX files
            string[] inputPaths = new string[]
            {
                @"C:\Images\first.cmx",
                @"C:\Images\second.cmx",
                @"C:\Images\third.cmx"
            };

            // Verify each input file exists
            foreach (var path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Output composite PDF
            string outputPath = @"C:\Images\merged.pdf";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create PDF options
            PdfOptions pdfOptions = new PdfOptions();

            // Create a multipage image from the CMX files and save as PDF
            using (Image composite = Image.Create(inputPaths))
            {
                composite.Save(outputPath, pdfOptions);
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
 * 1. When a CAD engineer needs to combine several CMX vector drawings into a single PDF report while preserving the original layer order.
 * 2. When an architectural firm wants to merge multiple CorelDRAW CMX files into one composite document for client presentation without losing layer hierarchy.
 * 3. When a manufacturing workflow requires consolidating separate CMX schematics into a multipage PDF for inclusion in a quality‑control manual.
 * 4. When a GIS analyst must combine layered CMX map overlays into a single PDF file for easy distribution and printing.
 * 5. When a software developer automates the creation of a single PDF portfolio from multiple CMX design assets while ensuring each layer remains intact.
 */