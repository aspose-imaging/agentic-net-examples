// HOW-TO: Resize BMP Image with Nearest Neighbor and Convert to PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.bmp";
            string outputPath = "output/resized.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                int newWidth = image.Width / 2;
                int newHeight = image.Height / 2;
                image.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);
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

/*
 * Real-World Use Cases:
 * 1. When you need to shrink a large BMP file for faster loading in a web report and deliver it as a PDF document using Aspose.Imaging for .NET.
 * 2. When a legacy system outputs BMP scans that must be downscaled and packaged into PDF for archival compliance with C# code.
 * 3. When generating thumbnails of BMP graphics for inclusion in PDF catalogs without losing sharp edges, using nearest‑neighbor interpolation in C#.
 * 4. When converting BMP screenshots from a Windows application into a smaller PDF for email attachment size limits via Aspose.Imaging.
 * 5. When automating batch processing of BMP assets to create PDF versions with reduced dimensions for mobile device viewing in a .NET application.
 */
