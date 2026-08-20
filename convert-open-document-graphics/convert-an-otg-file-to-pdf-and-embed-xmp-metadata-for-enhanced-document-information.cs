// HOW-TO: Convert OTG File To PDF With Aspose.Imaging In C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input\\sample.otg";
            string outputPath = "Output\\sample.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var pdfOptions = new PdfOptions();
                var vectorOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = image.Width,
                    PageHeight = image.Height
                };
                pdfOptions.VectorRasterizationOptions = vectorOptions;

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
 * 1. When a CAD or engineering application exports drawings as OTG and you need to generate printable PDF reports programmatically in a C# backend.
 * 2. When an automated document pipeline must convert OTG graphics to PDF for archival or sharing while preserving the original dimensions and white background.
 * 3. When a web service receives OTG images from users and must return PDF versions for viewing in standard browsers without requiring client‑side plugins.
 * 4. When you are building a batch conversion tool that processes multiple OTG files into PDFs using Aspose.Imaging’s vector rasterization options in .NET.
 * 5. When integrating OTG to PDF conversion into a C# application to create PDF invoices that embed vector graphics generated from design software.
 */
