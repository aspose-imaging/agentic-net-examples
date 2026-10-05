// HOW-TO: Resize Image to 1200px Width and Save as PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\image.png";
            string outputPath = "Output\\image.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image img = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)img;
                if (!raster.IsCached)
                {
                    raster.CacheData();
                }

                int newWidth = 1200;
                int newHeight = (int)(raster.Height * (newWidth / (double)raster.Width));

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
 * 1. When you need to convert a large PNG into a PDF that fits a 1200‑pixel width for faster web display while keeping the original aspect ratio.
 * 2. When an e‑commerce platform generates product catalogs by resizing product images to a uniform width and exporting them as PDFs for consistent presentation.
 * 3. When a reporting application creates printable PDFs from high‑resolution screenshots, scaling them to 1200 px wide to match typical browser dimensions.
 * 4. When a content‑management system automatically processes uploaded images, resizing them to 1200 px and saving them as PDFs for easy download and viewing.
 * 5. When a batch job prepares marketing assets by using Aspose.Imaging to resize raster images and output them as PDFs for email newsletters.
 */
