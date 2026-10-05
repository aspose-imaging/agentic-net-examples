// HOW-TO: Resize PNG to Max Width 1200 and Convert to PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace ImageProcessingApp
{
    class Program
    {
        static void Main()
        {
            const string inputPath = "input.png";
            const string outputPath = "output.pdf";

            try
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string? outputDir = Path.GetDirectoryName(outputPath);
                Directory.CreateDirectory(outputDir ?? ".");

                using (Image image = Image.Load(inputPath))
                {
                    int originalWidth = image.Width;
                    int originalHeight = image.Height;

                    int newWidth = originalWidth > 1200 ? 1200 : originalWidth;
                    int newHeight = (int)Math.Round((double)originalHeight * newWidth / originalWidth);

                    if (newWidth != originalWidth)
                    {
                        image.Resize(newWidth, newHeight, ResizeType.LanczosResample);
                    }

                    var pdfOptions = new PdfOptions();
                    image.Save(outputPath, pdfOptions);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to shrink large PNG screenshots to a 1200‑pixel width for faster loading while preserving the original aspect ratio before embedding them in a PDF report.
 * 2. When generating printable PDFs from user‑uploaded PNG logos that must not exceed a specific width to fit page layouts.
 * 3. When automating batch conversion of high‑resolution PNG assets to PDF documents for archiving, ensuring each image is resized to a consistent maximum width.
 * 4. When creating PDF invoices that include product images originally stored as PNG files, and you must resize them to avoid overflow on the invoice template.
 * 5. When developing a web service that receives PNG files, resizes them to a 1200‑pixel limit, and returns a PDF version for downstream processing or storage.
 */
