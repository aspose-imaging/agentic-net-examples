// HOW-TO: Rotate CorelDRAW File 90 Degrees Clockwise and Save as PDF in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.cdr";
            string outputPath = "output/output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                image.RotateFlip(RotateFlipType.Rotate90FlipNone);
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
 * 1. When you need to automatically re‑orient scanned CorelDRAW drawings before generating printable PDFs in a batch workflow.
 * 2. When a web service must convert user‑uploaded CDR files to PDF while ensuring the artwork is displayed in landscape orientation.
 * 3. When generating PDF reports from legacy CorelDRAW assets that require a 90‑degree clockwise rotation to match corporate branding guidelines.
 * 4. When building a desktop utility that prepares CorelDRAW illustrations for mobile viewing by rotating them and exporting to PDF.
 * 5. When integrating Aspose.Imaging into a CI pipeline to rotate design files and produce PDF documentation without manual intervention.
 */
