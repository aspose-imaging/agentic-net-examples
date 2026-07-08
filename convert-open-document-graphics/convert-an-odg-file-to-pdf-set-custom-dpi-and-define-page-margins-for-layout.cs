using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.odg";
        string outputPath = "Output/sample.pdf";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var rasterOptions = new OdgRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = image.Size,
                    BorderX = 50, // left/right margin
                    BorderY = 50  // top/bottom margin
                };

                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = rasterOptions,
                    ResolutionSettings = new ResolutionSetting(300, 300) // custom DPI
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
 * 1. When a developer needs to generate printable PDF reports from OpenDocument Graphics (ODG) diagrams with a consistent 300 DPI resolution for high‑quality printing.
 * 2. When an application must convert user‑created ODG drawings into PDF files while preserving a white background and adding 50‑pixel margins to fit standard page layouts.
 * 3. When a document‑management system requires automated batch conversion of ODG assets to PDF with custom page size and border settings for archival purposes.
 * 4. When a web service needs to transform ODG files uploaded by clients into PDF format with specific DPI settings to ensure accurate scaling on different devices.
 * 5. When a desktop utility must export ODG illustrations to PDF while controlling rasterization options such as page size, background color, and margin borders for consistent branding.
 */