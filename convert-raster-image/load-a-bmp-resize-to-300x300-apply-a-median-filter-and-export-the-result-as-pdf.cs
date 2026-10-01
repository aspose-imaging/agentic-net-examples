// HOW-TO: Resize BMP to 300x300, Apply Median Filter, Save as PDF in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input\\input.bmp";
            string outputPath = "Output\\output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (RasterImage raster = (RasterImage)image)
                {
                    if (!raster.IsCached)
                        raster.CacheData();

                    raster.Resize(300, 300);
                    raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(3));

                    raster.Save(outputPath, new PdfOptions());
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
 * 1. When you need to convert legacy BMP scans into compact PDF documents while standardizing size for a web portal.
 * 2. When you must preprocess a bitmap image by reducing noise with a median filter before embedding it in a printable PDF report.
 * 3. When an automated batch job has to resize user‑uploaded BMP avatars to 300 × 300 pixels and store them as PDFs for archival.
 * 4. When integrating a document management system that only accepts PDF, you can transform BMP diagrams to PDF with consistent dimensions and filtered quality.
 * 5. When generating PDF catalogs from BMP product photos, applying a median filter ensures smoother edges after resizing to a fixed thumbnail size.
 */
