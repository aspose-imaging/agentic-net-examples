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
            string inputPath = Path.Combine("Input", "sample.odg");
            string outputPath = Path.Combine("Output", "sample.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var rasterOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = image.Width,
                    PageHeight = image.Height
                };

                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

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
 * 1. When a graphic designer needs to archive OpenDocument Graphics (ODG) drawings as PDF files with embedded XMP metadata for easy searching in a digital asset management system.
 * 2. When a web application automatically converts user‑uploaded ODG illustrations to PDF for printing while preserving author and copyright information via XMP metadata.
 * 3. When a construction firm generates PDF blueprints from ODG CAD files and embeds project metadata so that project managers can filter documents by date, version, and engineer name.
 * 4. When an e‑learning platform batch‑processes ODG diagrams into searchable PDF handouts, adding XMP metadata to link each diagram to its corresponding course module.
 * 5. When a legal compliance tool transforms ODG contract schematics into PDF records and includes XMP metadata to retain document provenance and audit trails.
 */