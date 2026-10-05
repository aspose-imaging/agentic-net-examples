// HOW-TO: Center Crop Image To 400x400 And Save As PDF In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace ImagingNet
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "Input\\sample.png";
                string outputPath = "Output\\cropped.pdf";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    if (!image.IsCached)
                        image.CacheData();

                    int cropWidth = 400;
                    int cropHeight = 400;

                    int left = (image.Width - cropWidth) / 2;
                    int top = (image.Height - cropHeight) / 2;

                    if (left < 0) left = 0;
                    if (top < 0) top = 0;

                    Aspose.Imaging.Rectangle cropRect = new Aspose.Imaging.Rectangle(left, top, cropWidth, cropHeight);
                    image.Crop(cropRect);

                    using (PdfOptions pdfOptions = new PdfOptions())
                    {
                        image.Save(outputPath, pdfOptions);
                    }
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
 * 1. When you need to extract a 400 × 400 pixel region from the center of a PNG and deliver it as a PDF document.
 * 2. When generating printable thumbnails from large raster files for inclusion in PDF catalogs.
 * 3. When creating a centered preview of a scanned image and saving it as a PDF for archiving.
 * 4. When automating the conversion of product photos into fixed‑size PDF assets for e‑commerce platforms.
 * 5. When preparing a consistent page layout by cropping user‑uploaded images to a central square before embedding them in PDF invoices.
 */
