// HOW-TO: Sharpen PNG Image and Save as PDF Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

public class Program
{
    public static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.pdf";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions());

                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    raster.Save(outputPath, pdfOptions);
                }
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
 * 1. When you need to improve the visual sharpness of a scanned PNG before embedding it into a PDF report.
 * 2. When generating printable PDFs from product photos that require a sharpened appearance to highlight details.
 * 3. When creating a PDF catalog where each raster image must be sharpened to enhance texture and edges.
 * 4. When converting screenshots to PDF pages while applying a sharpening filter to make text and UI elements clearer.
 * 5. When automating a document workflow that loads a PNG, sharpens it, and saves the result directly as a PDF using C#.
 */
