// HOW-TO: Resize PNG to 500x500, Apply Gaussian Blur, Save as PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/input.png";
            string outputPath = "Output/output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                // Resize to 500x500 pixels
                image.Resize(500, 500);

                // Apply Gaussian blur filter
                RasterImage raster = (RasterImage)image;
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                // Save the result as PDF
                PdfOptions pdfOptions = new PdfOptions();
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
 * 1. When you need to generate a high‑resolution PDF thumbnail from a PNG by resizing it to a fixed 500 × 500 size and softening the image with a Gaussian blur.
 * 2. When creating printable PDF brochures that require PNG logos to be uniformly sized and lightly blurred for a subtle background effect.
 * 3. When automating a workflow that converts user‑uploaded PNG screenshots into standardized 500 × 500 PDF pages with a blur filter to protect sensitive details.
 * 4. When preparing image assets for a mobile app’s PDF documentation, ensuring each PNG is resized and blurred before embedding.
 * 5. When building a batch process that normalizes PNG icons to 500 × 500 pixels, applies a Gaussian blur for visual consistency, and saves them as PDF files for archival.
 */
