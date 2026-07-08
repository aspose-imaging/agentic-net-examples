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
            string inputPath = "input/sample.cmx";
            string outputPath = "output/result.pdf";

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
 * 1. When a C# application in a printing house receives multi‑page CMX artwork and must create a single PDF so clients can preview each page of the design.
 * 2. When a CAD team uses C# to archive legacy CorelDRAW CMX drawings as multi‑page PDFs, preserving each drawing as an individual PDF page for future reference.
 * 3. When a document management system built with .NET needs to import CMX files and store them as searchable, multi‑page PDFs that can be opened in any PDF viewer.
 * 4. When an automated C# batch process converts CMX technical schematics into a PDF manual, ensuring each schematic appears on its own PDF page for easy navigation.
 * 5. When a legal workflow in a .NET environment requires converting CMX evidence files into a single PDF document, with each page of the original CMX becoming a separate page in the PDF for court submission.
 */