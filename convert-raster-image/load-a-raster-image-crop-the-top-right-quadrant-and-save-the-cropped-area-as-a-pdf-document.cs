// HOW-TO: Crop Top Right Quadrant of PNG and Save as PDF in C# (Aspose.Imaging for .NET)
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
                {
                    image.CacheData();
                }

                int halfWidth = image.Width / 2;
                int halfHeight = image.Height / 2;
                int x = halfWidth;
                int y = 0;
                int width = halfWidth;
                int height = halfHeight;

                Aspose.Imaging.Rectangle cropRect = new Aspose.Imaging.Rectangle(x, y, width, height);
                image.Crop(cropRect);

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
 * 1. When you need to extract the upper‑right quarter of a scanned PNG and embed it in a PDF report.
 * 2. When generating printable PDFs that contain only a specific region of a large raster image, such as a logo corner.
 * 3. When creating thumbnails or preview pages by cropping a portion of an image and converting it to PDF for documentation.
 * 4. When automating the conversion of selected image sections into PDF for archival or compliance purposes.
 * 5. When building a web service that receives PNG uploads, isolates the top‑right area, and returns a PDF file to the client.
 */
