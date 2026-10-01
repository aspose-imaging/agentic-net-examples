// HOW-TO: Batch Convert ODG and OTG Files to A4 PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            Directory.CreateDirectory(inputDirectory);
            Directory.CreateDirectory(outputDirectory);

            string[] files = Directory.GetFiles(inputDirectory, "*.*")
                .Where(f => f.EndsWith(".odg", StringComparison.OrdinalIgnoreCase) ||
                            f.EndsWith(".otg", StringComparison.OrdinalIgnoreCase))
                .ToArray();

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".pdf");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    using (PdfOptions pdfOptions = new PdfOptions())
                    {
                        pdfOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            PageWidth = 595,   // A4 width in points
                            PageHeight = 842,  // A4 height in points
                            BackgroundColor = Color.White
                        };
                        image.Save(outputPath, pdfOptions);
                    }
                }
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
 * 1. When a design team needs to archive multiple OpenDocument graphics (ODG) and OpenDocument templates (OTG) as searchable A4‑sized PDFs using C#.
 * 2. When an automated build process must convert a folder of mixed ODG/OTG drawings into PDF reports with a consistent page layout.
 * 3. When a document management system requires batch rasterization of vector drawings to PDF while preserving a white background and uniform page dimensions.
 * 4. When a Windows service has to process incoming ODG and OTG files and generate PDF invoices or specifications with consistent A4 pages.
 * 5. When a migration script moves legacy OpenDocument graphics to PDF format for compliance, ensuring each file is saved with the same page size via Aspose.Imaging in .NET.
 */
