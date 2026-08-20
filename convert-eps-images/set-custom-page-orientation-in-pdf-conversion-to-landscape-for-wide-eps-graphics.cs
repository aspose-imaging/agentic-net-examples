// HOW-TO: Convert EPS to PDF with Landscape Orientation in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input/sample.eps";
            string outputPath = "Output/sample.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var image = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(inputPath))
            {
                float pageWidth = image.Width;
                float pageHeight = image.Height;

                // Ensure landscape orientation
                if (pageHeight > pageWidth)
                {
                    float temp = pageWidth;
                    pageWidth = pageHeight;
                    pageHeight = temp;
                }

                var pdfOptions = new PdfOptions
                {
                    PageSize = new SizeF(pageWidth, pageHeight),
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = pageWidth,
                        PageHeight = pageHeight
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
 * 1. When you need to generate printable PDFs from wide EPS illustrations while ensuring the pages are set to landscape for optimal layout.
 * 2. When an automated reporting system must convert vector EPS logos into PDF files that retain the original dimensions without rotating the artwork.
 * 3. When a web service processes user‑uploaded EPS files and must return PDFs that preserve the original aspect ratio in landscape mode.
 * 4. When creating batch scripts that convert a folder of EPS graphics to PDFs for large‑format printing that requires landscape pages.
 * 5. When integrating Aspose.Imaging into a C# application to rasterize EPS artwork into PDFs with custom page size and a white background for archival purposes.
 */
