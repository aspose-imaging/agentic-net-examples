// HOW-TO: Resize EPS to 2000px Width and Export as PDF/A-1b in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.eps";
            string outputPath = "output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Aspose.Imaging.FileFormats.Eps.EpsImage epsImage = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(inputPath))
            {
                double scale = 2000.0 / epsImage.Width;
                int newHeight = (int)(epsImage.Height * scale);

                var rasterOptions = new EpsRasterizationOptions
                {
                    PageWidth = 2000,
                    PageHeight = newHeight
                };

                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                epsImage.Save(outputPath, pdfOptions);
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
 * 1. When you need to convert a high‑resolution EPS artwork to a PDF/A‑1b compliant document while limiting the width to 2000 pixels for web preview.
 * 2. When a printing workflow requires rasterizing vector EPS files to a fixed pixel width before archiving them as PDF/A‑1b for long‑term preservation.
 * 3. When an application must generate PDF reports from EPS logos that fit within a specific layout width without exceeding 2000 pixels.
 * 4. When you need to batch‑process EPS diagrams to PDF/A‑1b for compliance‑checked submissions, ensuring each output matches a 2000‑pixel width constraint.
 * 5. When a document management system imports EPS graphics and must store them as PDF/A‑1b files with a standardized width for consistent rendering across devices.
 */
