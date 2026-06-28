using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\sample.wmf";
        string outputPath = "Output\\sample.pdf";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    }
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
 * 1. When a developer needs to convert legacy WMF vector drawings from a Windows desktop application into PDF files for easy sharing while keeping the original line thickness and colors intact.
 * 2. When an automated report generator must embed WMF schematics into PDF documents without rasterizing the graphics, preserving vector quality for high‑resolution printing.
 * 3. When a batch‑processing tool has to migrate a folder of WMF icons to PDF format for inclusion in a digital asset management system while maintaining exact visual fidelity.
 * 4. When a web service receives WMF files uploaded by users and needs to return PDF previews that retain the original vector styling for preview thumbnails.
 * 5. When a C# application integrates Aspose.Imaging to export WMF technical diagrams to PDF for compliance documentation, ensuring that line weights and color palettes remain unchanged.
 */