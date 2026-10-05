// HOW-TO: Convert Wide EPS to Landscape PDF with Custom Page Size in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.eps";
            string outputPath = "Output\\sample.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                var epsImage = (Aspose.Imaging.FileFormats.Eps.EpsImage)image;

                int pageWidth = epsImage.Width;
                int pageHeight = epsImage.Height;
                if (pageWidth < pageHeight)
                {
                    int temp = pageWidth;
                    pageWidth = pageHeight;
                    pageHeight = temp;
                }

                var rasterOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.White,
                    PageWidth = pageWidth,
                    PageHeight = pageHeight
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
 * 1. When a developer needs to generate a landscape‑oriented PDF from a wide EPS illustration for printing large‑format banners.
 * 2. When an application must automatically adjust the PDF page dimensions to match the EPS width and height before saving.
 * 3. When a reporting tool has to embed vector EPS graphics into PDF reports while preserving a white background and correct orientation.
 * 4. When a workflow converts EPS files received from designers into PDF for archival storage with consistent page layout.
 * 5. When a batch process creates PDF portfolios from multiple EPS files and must ensure each PDF uses landscape orientation for better on‑screen viewing.
 */
