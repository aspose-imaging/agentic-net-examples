// HOW-TO: Resize PNG Image and Convert to PDF Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

public class Program
{
    public static void Main(string[] args)
    {
        string inputPath = "Input\\image.png";
        string outputPath = "Output\\result.pdf";

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = image as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
                    return;
                }

                if (!raster.IsCached) raster.CacheData();

                int newWidth = raster.Width * 2;
                int newHeight = raster.Height * 2;

                raster.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

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
 * 1. When you need to enlarge a PNG logo for print while preserving quality and embed it directly into a PDF report.
 * 2. When an automated batch job must take user‑uploaded PNG screenshots, double their dimensions, and generate a single PDF document for archival.
 * 3. When a web service creates printable invoices that include PNG graphics and must resize them before saving the final PDF.
 * 4. When a desktop application prepares marketing assets by scaling PNG images and packaging them as PDF handouts without using external tools.
 * 5. When a migration script converts legacy PNG files to PDF format after resizing them to meet a new layout specification.
 */
