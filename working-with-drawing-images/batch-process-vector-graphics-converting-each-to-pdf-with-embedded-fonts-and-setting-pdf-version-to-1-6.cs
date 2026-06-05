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
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string inputPath = Path.Combine(inputDirectory, "input.jpg");
            string outputPath = Path.Combine(outputDirectory, "output.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                image.Save(outputPath, new PdfOptions());
            }

            Console.WriteLine($"Conversion completed: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to automatically convert a folder of SVG or EPS design files into PDF documents that preserve the original typography by embedding all fonts and comply with PDF 1.6 standards for downstream printing workflows.
 * 2. When an enterprise application must generate archival PDFs from a batch of CAD‑exported vector drawings, ensuring the files are self‑contained with embedded fonts and compatible with PDF viewers that require version 1.6.
 * 3. When a web service processes user‑uploaded vector logos and returns PDF versions with embedded fonts so the logos can be used in corporate brochures without font substitution issues.
 * 4. When a reporting tool creates multi‑page PDF reports from vector chart images, embedding the chart fonts and setting the PDF version to 1.6 to meet regulatory document‑format requirements.
 * 5. When a CI/CD pipeline needs to validate that all vector assets in a repository are converted to PDF/1.6 with embedded fonts before they are shipped to a print vendor.
 */