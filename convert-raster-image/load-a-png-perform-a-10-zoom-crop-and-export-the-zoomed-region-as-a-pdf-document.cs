// HOW-TO: Create PDF From Center Cropped 10% Zoom Of PNG In C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input\\image.png";
            string outputPath = "Output\\zoomed.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                if (!raster.IsCached)
                    raster.CacheData();

                int cropWidth = (int)(raster.Width * 0.1);
                int cropHeight = (int)(raster.Height * 0.1);
                int x = (raster.Width - cropWidth) / 2;
                int y = (raster.Height - cropHeight) / 2;

                Aspose.Imaging.Rectangle cropRect = new Aspose.Imaging.Rectangle(x, y, cropWidth, cropHeight);
                raster.Crop(cropRect);

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
 * 1. When you need to embed a focused portion of a PNG image into a PDF document for reports or presentations.
 * 2. When generating printable PDFs that contain only the central 10% of a PNG to highlight fine details.
 * 3. When creating thumbnail‑style PDF pages from large PNG assets by cropping a zoomed region.
 * 4. When converting scanned PNG diagrams into PDFs while removing surrounding whitespace through a centered crop.
 * 5. When automating batch processing to extract a zoomed region from multiple PNG files and save each as a PDF for archival.
 */
