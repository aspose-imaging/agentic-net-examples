// HOW-TO: Export PSD to PDF with Single Bit Text Rendering in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.psd";
            string outputPath = "Output/result.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                // Deskew operation is not directly supported for PSD images.
                // Placeholder for any required deskew logic.

                PdfOptions pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Aspose.Imaging.Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height,
                        TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel
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
 * 1. When you need to generate a printable PDF from a Photoshop PSD file while ensuring crisp, single‑bit text rendering for high‑contrast documents.
 * 2. When an application must convert layered PSD artwork into a flat PDF for archiving or sharing with users who do not have Photoshop.
 * 3. When you want to preserve the original PSD dimensions and background color when exporting to PDF in a .NET service.
 * 4. When you need to programmatically create PDFs from PSD files in a batch process, handling missing files and creating output folders automatically.
 * 5. When you require a simple C# solution that loads a PSD, optionally applies deskew logic, and saves it as a PDF with specific rasterization options.
 */
